using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        internal static bool AllocateRoom(
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
                using (SqlConnection con = SqlRepository.GetConnection())
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
        /// Returns true when the room number is already used by another room.
        /// Pass 0 for excludeRoomId when adding a new room.
        /// </summary>
        internal static bool RoomNumberExists(string roomNo, int excludeRoomId)
        {
            const string query = @"
                SELECT Room_ID
                FROM Rooms
                WHERE Room_NO = @roomNo
                  AND (@excludeRoomId <= 0 OR Room_ID <> @excludeRoomId)";

            DataTable table = SqlRepository.GetData(query,
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo },
                new SqlParameter("@excludeRoomId", SqlDbType.Int) { Value = excludeRoomId });

            return table.Rows.Count > 0;
        }

        /// <summary>
        /// Updates a room's details. An occupied room must stay Busy, otherwise
        /// the room would become allocatable while a guest is still checked in.
        /// </summary>
        internal static bool UpdateRoom(
            int roomId,
            string roomNo,
            string roomType,
            string bed,
            decimal price,
            string status,
            out string error)
        {
            error = null;

            const string updateSql = @"
                UPDATE Rooms
                SET Room_NO = @roomNo,
                    Room_Type = @roomType,
                    Bed = @bed,
                    Price = @price,
                    Status = @status
                WHERE Room_ID = @roomId";

            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            if (!RoomExists(con, tx, roomId))
                            {
                                tx.Rollback();
                                error = "Room not found.";
                                return false;
                            }

                            if (RoomHasActiveCustomer(con, tx, roomId) && status != "Busy")
                            {
                                tx.Rollback();
                                error = "This room is occupied. Check out the guest before changing its status.";
                                return false;
                            }

                            using (SqlCommand cmd = new SqlCommand(updateSql, con, tx))
                            {
                                cmd.Parameters.Add("@roomNo", SqlDbType.VarChar, 10).Value = roomNo;
                                cmd.Parameters.Add("@roomType", SqlDbType.VarChar, 10).Value = roomType;
                                cmd.Parameters.Add("@bed", SqlDbType.VarChar, 10).Value = bed;
                                cmd.Parameters.Add("@price", SqlDbType.Decimal).Precision = 10;
                                cmd.Parameters["@price"].Scale = 2;
                                cmd.Parameters["@price"].Value = price;
                                cmd.Parameters.Add("@status", SqlDbType.VarChar, 5).Value = status;
                                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    tx.Rollback();
                                    error = "Room not found.";
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
        /// Deletes a room when it is free and has no customer history.
        /// History is kept for reporting, so a used room cannot be removed.
        /// </summary>
        internal static bool DeleteRoom(int roomId, out string error)
        {
            error = null;

            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            if (!RoomExists(con, tx, roomId))
                            {
                                tx.Rollback();
                                error = "Room not found.";
                                return false;
                            }

                            if (RoomHasActiveCustomer(con, tx, roomId))
                            {
                                tx.Rollback();
                                error = "This room is occupied. Check out the guest first.";
                                return false;
                            }

                            if (RoomIsBusy(con, tx, roomId))
                            {
                                tx.Rollback();
                                error = "This room is marked Busy. Set it to Free before deleting it.";
                                return false;
                            }

                            if (RoomHasCustomerHistory(con, tx, roomId))
                            {
                                tx.Rollback();
                                error = "This room has customer history and cannot be deleted. Keep it for reporting.";
                                return false;
                            }

                            using (SqlCommand cmd = new SqlCommand(
                                "DELETE FROM Rooms WHERE Room_ID = @roomId", con, tx))
                            {
                                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    tx.Rollback();
                                    error = "Room not found.";
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

        private static bool RoomExists(SqlConnection con, SqlTransaction tx, int roomId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Room_ID FROM Rooms WITH (UPDLOCK, HOLDLOCK) WHERE Room_ID = @roomId", con, tx))
            {
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                return cmd.ExecuteScalar() != null;
            }
        }

        private static bool RoomIsBusy(SqlConnection con, SqlTransaction tx, int roomId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Status FROM Rooms WHERE Room_ID = @roomId", con, tx))
            {
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                return Convert.ToString(cmd.ExecuteScalar()) == "Busy";
            }
        }

        private static bool RoomHasActiveCustomer(SqlConnection con, SqlTransaction tx, int roomId)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Customers
                WHERE Customer_Room_ID = @roomId
                  AND Customer_IsCheckOut = 'No'", con, tx))
            {
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static bool RoomHasCustomerHistory(SqlConnection con, SqlTransaction tx, int roomId)
        {
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Customers WHERE Customer_Room_ID = @roomId", con, tx))
            {
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}