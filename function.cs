using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    internal class function
    {
        private SqlConnection getConnection()
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["HotelDb"];

            if (settings == null)
            {
                throw new ConfigurationErrorsException(
                    "Connection string 'HotelDb' was not found in App.config.");
            }

            return new SqlConnection(settings.ConnectionString);
        }

        /// <summary>
        /// Executes a SELECT statement and returns the result as a DataTable.
        /// Always returns a table (empty when a database error occurs).
        /// </summary>
        public DataTable getData(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = getConnection())
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
        /// </summary>
        public int setData(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = getConnection())
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
        public bool AllocateRoom(
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
                     Customer_Address, Customer_CheckIn, Customer_Room_ID)
                VALUES
                    (@name, @mobile, @nationality,
                     @gender, @dob, @idProof,
                     @address, @checkIn, @roomId)";

            const string updateSql = @"
                UPDATE Rooms
                SET Status = 'Busy'
                WHERE Room_ID = @roomId AND Status = 'Free'";

            try
            {
                using (SqlConnection con = getConnection())
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

                            Logger.Error(ex);
                            error = GetFriendlyMessage(ex);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                error = GetFriendlyMessage(ex);
                return false;
            }
        }

        /// <summary>
        /// Returns the values of the first column of a SELECT statement.
        /// The reader and connection are always disposed before returning.
        /// </summary>
        public List<string> getForCombo(string query, params SqlParameter[] parameters)
        {
            List<string> items = new List<string>();

            try
            {
                using (SqlConnection con = getConnection())
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
        public DataTable GetDashboardStatistics()
        {
            const string query = @"
                SELECT 'TotalRooms' AS Metric, COUNT(*) AS Value FROM Rooms
                UNION ALL SELECT 'FreeRooms', COUNT(*) FROM Rooms WHERE Status = 'Free'
                UNION ALL SELECT 'BusyRooms', COUNT(*) FROM Rooms WHERE Status = 'Busy'
                UNION ALL SELECT 'TotalCustomers', COUNT(*) FROM Customers
                UNION ALL SELECT 'ActiveCustomers', COUNT(*) FROM Customers WHERE Customer_IsCheckOut = 'No'
                UNION ALL SELECT 'TotalStaff', COUNT(*) FROM Staff";

            return getData(query);
        }

        /// <summary>
        /// Returns the most recent check-ins, newest first.
        /// </summary>
        public DataTable GetRecentCustomers(int count)
        {
            const string query = @"
                SELECT TOP (@count)
                    c.Customer_Name AS [Customer],
                    r.Room_NO AS [Room],
                    c.Customer_CheckIn AS [Check In],
                    CASE WHEN c.Customer_IsCheckOut = 'No' THEN 'Active' ELSE 'Checked Out' END AS [Status]
                FROM Customers c
                INNER JOIN Rooms r ON r.Room_ID = c.Customer_Room_ID
                ORDER BY c.Customer_ID DESC";

            return getData(query,
                new SqlParameter("@count", SqlDbType.Int) { Value = count });
        }

        private static void AddParameters(SqlCommand cmd, SqlParameter[] parameters)
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
                default:
                    return "A database error occurred. Please try again.";
            }
        }
    }
}
