using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    /// <summary>
    /// The final bill produced by a successful check-out.
    /// </summary>
    internal sealed class CheckoutResult
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string RoomNo { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Nights { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
    }internal class function

        /// <summary>
        /// Validates a user name / password pair.
        /// Returns null when the credentials are invalid or the database fails
        /// (databaseError is set in the latter case).
        /// Legacy plain-text passwords are replaced with a PBKDF2 hash after a successful login.
        /// </summary>
        public StaffUser AuthenticateUser(string userName, string password, out bool databaseError)
        {
            return AuthRepository.AuthenticateUser(userName, password, out databaseError);
        }        /// <summary>
        /// Executes a SELECT statement and returns the result as a DataTable.
        /// Always returns a table (empty when a database error occurs).
        /// </summary>
        public DataTable getData(string query, params SqlParameter[] parameters)


        {
            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    AddParameters(cmd, parameters);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
                return new DataTable();
            }
        }

        /// <summary>
        /// Executes INSERT / UPDATE / DELETE and returns the number of affected rows,


        /// or -1 when a database error occurs.
        /// </summary>        public int setData(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    AddParameters(cmd, parameters);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
                return -1;
            }
        }




        /// <summary>
        /// Allocates a free room to a new customer inside a single transaction.
        /// Returns false with a friendly message when the room is no longer free
        /// or when any statement fails.
        /// </summary>
        /// <summary>
        /// Checks a guest out, writes the final bill, and frees the room.
        /// The whole operation runs in one transaction; the customer row is
        /// locked so two operators cannot check out the same guest twice.
        /// </summary>
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                error = GetFriendlyMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Updates a room's details. An occupied room must stay Busy, otherwise
        /// the room would become allocatable while a guest is still checked in.
        /// </summary>        /// <summary>
        /// Deletes a room when it is free and has no customer history.
        /// History is kept for reporting, so a used room cannot be removed.
        /// </summary>
        public bool DeleteRoom(int roomId, out string error)


        {
            error = null;

            try
            {                using (SqlConnection con = SqlRepository.GetConnection())
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

                            Logger.Error(ex);
                            error = GetFriendlyMessage(ex);
                            return false;
                        }
                    }
                }        }


            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Customers WHERE Customer_Room_ID = @roomId", con, tx))
            {
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        /// <summary>
        /// Replaces a staff member's password with a fresh PBKDF2 hash.        /// <summary>
        /// Replaces a staff member's password with a fresh PBKDF2 hash.
        /// The policy is enforced by AuthRepository; this method delegates to it.
        /// </summary>
        public bool ResetStaffPassword(int staffId, string newPassword, out string error)
        {
            return AuthRepository.ResetStaffPassword(staffId, newPassword, out error);        }

        /// <summary>
        /// Returns the values of the first column of a SELECT statement.
        /// The reader and connection are always disposed before returning.
        /// </summary>
        public List<string> getForCombo(string query, params SqlParameter[] parameters)


        {
            List<string> items = new List<string>();            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    AddParameters(cmd, parameters);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.FieldCount > 0 && reader.GetValue(0) != DBNull.Value)
                                items.Add(Convert.ToString(reader.GetValue(0)));
                        }
                    }
                }
            }
            catch (SqlException ex)


            {
                ShowDatabaseError(ex);
            }

            return items;
        }

        /// <summary>
        /// Returns the KPI values shown on the dashboard as Metric / Value rows.
        /// </summary>
        {
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
        }

        private static void ShowDatabaseError(SqlException ex)
        {
            Logger.Error(ex);

            MessageBox.Show(
                GetFriendlyMessage(ex),
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static string GetFriendlyMessage(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2601:
                case 2627:
                    return "This record already exists.";
                case 547:
                    return "This operation conflicts with related data.";
                case 2628:
                case 8152:
                    return "One of the values is too long. Please shorten it and try again.";
                case 207:
                    return "The database schema is out of date. Run the scripts in database/migrations.";
                default:
                    return "A database error occurred. Please try again.";
            }
        }
    }
}
