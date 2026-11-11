using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Handles all room-related database operations: allocation, updates,
    /// deletion, and room number existence checks.
    /// </summary>
    internal static class RoomRepository
    {
        /// <summary>
        /// Allocates a free room to a new customer inside a single transaction.
        /// The customer is inserted, and the room status is updated to 'Busy'
        /// only if the room is still free. Rolls back the insert if the room
        /// is no longer available.
        /// </summary>
        internal static async Task<bool> AllocateRoomAsync(
            int roomId,
            string name,
            string mobile,
            string nationality,
            string gender,
            DateTime dateOfBirth,
            string idProof,
            string address,
            DateTime checkIn,
            out string error)
        {
            error = null;

            const string insertSql = @"
                INSERT INTO Customers
                    (Customer_Name, Customer_Mobile, Customer_Nationality,
                     Customer_Gender, Customer_DateOfBirth, Customer_ID_Proof,
                     Customer_Address, Customer_CheckIn, Customer_Room_ID,
                     Customer_Rate)
                VALUES
                    (@name, @mobile, @nationality,
                     @gender, @dob, @idProof,
                     @address, @checkIn, @roomId,
                     (SELECT Price FROM Rooms WHERE Room_ID = @roomId))";

            const string updateSql = @"
                UPDATE Rooms
                SET Status = 'Busy'
                WHERE Room_ID = @roomId AND Status = 'Free'";

            try
            {
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
                {
                    con.Open();

                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(insertSql, con, tx))
                            {
                                cmd.Parameters.Add("@name", SqlDbType.VarChar, 75).Value = name;
                                cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 25).Value = mobile;
                                cmd.Parameters.Add("@nationality", SqlDbType.VarChar, 25).Value = nationality;
                                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 50).Value = gender;
                                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = dateOfBirth;
                                cmd.Parameters.Add("@idProof", SqlDbType.VarChar, 30).Value = idProof;
                                cmd.Parameters.Add("@address", SqlDbType.VarChar, 350).Value = address;
                                cmd.Parameters.Add("@checkIn", SqlDbType.Date).Value = checkIn;
                                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand(updateSql, con, tx))
                            {
                                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                                // If the room is no longer free, roll back the insert.
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    tx.Rollback();
                                    error = "This room is no longer available.";
                                    return false;
                                }
                            }

                            tx.Commit();
                            return true;
                        }
                        catch (SqlException ex)
                        {
                            try { tx.Rollback(); } catch { /* already rolled back */ }

                            SqlRepository.Logger.Error(ex);
                            error = SqlRepository.GetFriendlyMessage(ex);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                try { /* tx.Rollback already attempted */ } catch { }
                SqlRepository.Logger.Error(ex);
                error = SqlRepository.GetFriendlyMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Checks whether a room number already exists in the database.
        /// </summary>
        internal static async Task<bool> RoomNumberExistsAsync(string roomNo)
        {
            const string query = "SELECT COUNT(*) FROM Rooms WHERE Room_NO = @roomNo";

            try
            {
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@roomNo", SqlDbType.VarChar, 20).Value = roomNo;

                    con.Open();
                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return Convert.ToInt32(result) > 0;
                }
            }
            catch (SqlException ex)
            {
                SqlRepository.Logger.Error(ex);
                return false;
            }
        }

        /// <summary>
        /// Updates a room's details. An occupied room must stay Busy, otherwise
        /// the room would become allocatable while a guest is still checked in.
        /// </summary>
        internal static async Task<bool> UpdateRoomAsync(int roomId, string status, out string error)
        {
            error = null;

            const string query = "UPDATE Rooms SET Status = @status WHERE Room_ID = @roomId";

            try
            {
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@status", SqlDbType.VarChar, 10).Value = status;
                    cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                    con.Open();

                    int rowsAffected = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                SqlRepository.Logger.Error(ex);
                error = SqlRepository.GetFriendlyMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Deletes a room. An occupied room must stay Busy, otherwise
        /// the room would become allocatable while a guest is still checked in.
        /// </summary>
        internal static async Task<bool> DeleteRoomAsync(int roomId, out string error)
        {
            error = null;

            // First check if the room has active (non-checked-out) customers
            const string checkSql = @"
                SELECT COUNT(*) 
                FROM Customers 
                WHERE Customer_Room_ID = @roomId 
                  AND Customer_IsCheckOut = 'No'";

            try
            {
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
                using (SqlCommand cmd = new SqlCommand(checkSql, con))
                {
                    cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                    con.Open();
                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    int activeCount = Convert.ToInt32(result);

                    if (activeCount > 0)
                    {
                        error = $"Cannot delete room {roomId}: there are {activeCount} active guest(s) checked in.";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                SqlRepository.Logger.Error(ex);
                error = SqlRepository.GetFriendlyMessage(ex);
                return false;
            }

            // Now delete the room
            const string deleteSql = "DELETE FROM Rooms WHERE Room_ID = @roomId";

            try
            {
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
                using (SqlCommand cmd = new SqlCommand(deleteSql, con))
                {
                    cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                    con.Open();

                    int rowsAffected = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                SqlRepository.Logger.Error(ex);
                error = SqlRepository.GetFriendlyMessage(ex);
                return false;
            }
        }
    }
}