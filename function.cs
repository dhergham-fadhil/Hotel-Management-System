using System;
using System.Collections.Generic;
using System.Configuration;
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
    }

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
        /// Validates a user name / password pair.
        /// Returns null when the credentials are invalid or the database fails
        /// (databaseError is set in the latter case).
        /// Legacy plain-text passwords are replaced with a PBKDF2 hash after a successful login.
        /// </summary>
        public StaffUser AuthenticateUser(string userName, string password, out bool databaseError)
        {
            databaseError = false;

            const string query = @"
                SELECT Staff_ID, Staff_Name, Staff_UserName, Staff_Password, Staff_Role
                FROM Staff
                WHERE Staff_UserName = @userName";

            DataTable table = new DataTable();

            try
            {
                using (SqlConnection con = getConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.Add(new SqlParameter("@userName", SqlDbType.VarChar, 150)
                    {
                        Value = userName
                    });

                    adapter.Fill(table);
                }
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
                databaseError = true;
                return null;
            }

            if (table.Rows.Count == 0)
            {
                // Keep the response time similar to a real verification.
                PasswordHasher.VerifyDummy(password);
                return null;
            }

            DataRow row = table.Rows[0];
            string storedPassword = Convert.ToString(row["Staff_Password"]);
            PasswordVerificationResult result = PasswordHasher.Verify(storedPassword, password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            int staffId = Convert.ToInt32(row["Staff_ID"]);

            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                UpgradePasswordHash(staffId, password);
            }

            return new StaffUser(
                staffId,
                Convert.ToString(row["Staff_Name"]),
                Convert.ToString(row["Staff_UserName"]),
                Convert.ToString(row["Staff_Role"]));
        }

        private void UpgradePasswordHash(int staffId, string password)
        {
            const string query = "UPDATE Staff SET Staff_Password = @password WHERE Staff_ID = @staffId";

            try
            {
                using (SqlConnection con = getConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 150)
                    {
                        Value = PasswordHasher.Hash(password)
                    });
                    cmd.Parameters.Add(new SqlParameter("@staffId", SqlDbType.Int)
                    {
                        Value = staffId
                    });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // The login itself succeeded; the upgrade will be retried next time.
                Logger.Error(ex);
            }
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
        /// Checks a guest out, writes the final bill, and frees the room.
        /// The whole operation runs in one transaction; the customer row is
        /// locked so two operators cannot check out the same guest twice.
        /// </summary>
        public bool CheckoutCustomer(
            int customerId,
            DateTime checkoutDate,
            out CheckoutResult result,
            out string error)
        {
            result = null;
            error = null;

            const string selectSql = @"
                SELECT
                    c.Customer_Name,
                    c.Customer_CheckIn,
                    c.Customer_IsCheckOut,
                    c.Customer_Room_ID,
                    c.Customer_Rate,
                    r.Room_NO,
                    r.Price
                FROM Customers c WITH (UPDLOCK, HOLDLOCK)
                INNER JOIN Rooms r ON r.Room_ID = c.Customer_Room_ID
                WHERE c.Customer_ID = @customerId";

            const string updateCustomerSql = @"
                UPDATE Customers
                SET Customer_CheckOut = @checkOut,
                    Customer_IsCheckOut = 'Yes',
                    Customer_Total = @total
                WHERE Customer_ID = @customerId
                  AND Customer_IsCheckOut = 'No'";

            const string updateRoomSql = @"
                UPDATE Rooms
                SET Status = CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM Customers
                        WHERE Customer_Room_ID = @roomId
                          AND Customer_IsCheckOut = 'No')
                    THEN 'Busy'
                    ELSE 'Free'
                END
                WHERE Room_ID = @roomId";

            try
            {
                using (SqlConnection con = getConnection())
                {
                    con.Open();

                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        try
                        {
                            string customerName;
                            DateTime checkIn;
                            int roomId;
                            string roomNo;
                            decimal rate;

                            using (SqlCommand cmd = new SqlCommand(selectSql, con, tx))
                            {
                                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        reader.Close();
                                        tx.Rollback();
                                        error = "Customer not found.";
                                        return false;
                                    }

                                    if (Convert.ToString(reader["Customer_IsCheckOut"]) == "Yes")
                                    {
                                        reader.Close();
                                        tx.Rollback();
                                        error = "This guest has already been checked out.";
                                        return false;
                                    }

                                    customerName = Convert.ToString(reader["Customer_Name"]);
                                    checkIn = Convert.ToDateTime(reader["Customer_CheckIn"]).Date;
                                    roomId = Convert.ToInt32(reader["Customer_Room_ID"]);
                                    roomNo = Convert.ToString(reader["Room_NO"]);
                                    rate = reader["Customer_Rate"] == DBNull.Value
                                        ? Convert.ToDecimal(reader["Price"])
                                        : Convert.ToDecimal(reader["Customer_Rate"]);
                                }
                            }

                            DateTime checkOut = checkoutDate.Date;

                            if (checkOut < checkIn)
                            {
                                tx.Rollback();
                                error = "Check-out date cannot be before the check-in date.";
                                return false;
                            }

                            if (checkOut > DateTime.Today)
                            {
                                tx.Rollback();
                                error = "Check-out date cannot be in the future.";
                                return false;
                            }

                            int nights = (checkOut - checkIn).Days;
                            if (nights < 1)
                                nights = 1;

                            decimal total = nights * rate;

                            using (SqlCommand cmd = new SqlCommand(updateCustomerSql, con, tx))
                            {
                                cmd.Parameters.Add("@checkOut", SqlDbType.Date).Value = checkOut;
                                cmd.Parameters.Add("@total", SqlDbType.Decimal).Precision = 12;
                                cmd.Parameters["@total"].Scale = 2;
                                cmd.Parameters["@total"].Value = total;
                                cmd.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;

                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    tx.Rollback();
                                    error = "This guest has already been checked out.";
                                    return false;
                                }
                            }

                            using (SqlCommand cmd = new SqlCommand(updateRoomSql, con, tx))
                            {
                                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = roomId;
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();

                            result = new CheckoutResult
                            {
                                CustomerId = customerId,
                                CustomerName = customerName,
                                RoomNo = roomNo,
                                CheckIn = checkIn,
                                CheckOut = checkOut,
                                Nights = nights,
                                Rate = rate,
                                Total = total
                            };

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
        /// Returns true when the room number is already used by another room.
        /// Pass 0 for excludeRoomId when adding a new room.
        /// </summary>
        public bool RoomNumberExists(string roomNo, int excludeRoomId)
        {
            const string query = @"
                SELECT Room_ID
                FROM Rooms
                WHERE Room_NO = @roomNo
                  AND (@excludeRoomId <= 0 OR Room_ID <> @excludeRoomId)";

            DataTable table = getData(query,
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo },
                new SqlParameter("@excludeRoomId", SqlDbType.Int) { Value = excludeRoomId });

            return table.Rows.Count > 0;
        }

        /// <summary>
        /// Updates a room's details. An occupied room must stay Busy, otherwise
        /// the room would become allocatable while a guest is still checked in.
        /// </summary>
        public bool UpdateRoom(
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
                using (SqlConnection con = getConnection())
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
        /// Deletes a room when it is free and has no customer history.
        /// History is kept for reporting, so a used room cannot be removed.
        /// </summary>
        public bool DeleteRoom(int roomId, out string error)
        {
            error = null;

            try
            {
                using (SqlConnection con = getConnection())
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
                }
            }
            catch (SqlException ex)
            {
                Logger.Error(ex);
                error = GetFriendlyMessage(ex);
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
        /// Returns the most recent stays, newest first. Active guests show an
        /// estimate; checked-out guests show their stored final bill.
        /// </summary>
        public DataTable GetRecentCustomers(int count)
        {
            const string query = @"
                SELECT TOP (@count)
                    c.Customer_Name AS [Customer],
                    r.Room_NO AS [Room],
                    c.Customer_CheckIn AS [Check In],
                    c.Customer_CheckOut AS [Check Out],
                    CASE
                        WHEN c.Customer_IsCheckOut = 'No' THEN
                            CASE WHEN DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE)) < 1
                                 THEN 1
                                 ELSE DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE))
                            END
                        ELSE
                            CASE WHEN DATEDIFF(DAY, c.Customer_CheckIn, c.Customer_CheckOut) < 1
                                 THEN 1
                                 ELSE DATEDIFF(DAY, c.Customer_CheckIn, c.Customer_CheckOut)
                            END
                    END AS [Nights],
                    CASE
                        WHEN c.Customer_IsCheckOut = 'No' THEN
                            (CASE WHEN DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE)) < 1
                                  THEN 1
                                  ELSE DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE))
                             END) * ISNULL(c.Customer_Rate, r.Price)
                        ELSE c.Customer_Total
                    END AS [Bill],
                    CASE WHEN c.Customer_IsCheckOut = 'No' THEN 'Active' ELSE 'Checked Out' END AS [Status]
                FROM Customers c
                INNER JOIN Rooms r ON r.Room_ID = c.Customer_Room_ID
                ORDER BY c.Customer_ID DESC";

            return getData(query,
                new SqlParameter("@count", SqlDbType.Int) { Value = count });
        }

        /// <summary>
        /// Returns the guests who are still checked in, with the current
        /// estimate based on the rate captured at check-in.
        /// </summary>
        public DataTable GetActiveCustomers()
        {
            const string query = @"
                SELECT
                    c.Customer_ID,
                    c.Customer_Name AS [Customer],
                    c.Customer_Mobile AS [Mobile],
                    r.Room_NO AS [Room],
                    c.Customer_CheckIn AS [Check In],
                    CASE WHEN DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE)) < 1
                         THEN 1
                         ELSE DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE))
                    END AS [Nights],
                    ISNULL(c.Customer_Rate, r.Price) AS [Rate],
                    (CASE WHEN DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE)) < 1
                          THEN 1
                          ELSE DATEDIFF(DAY, c.Customer_CheckIn, CAST(GETDATE() AS DATE))
                     END) * ISNULL(c.Customer_Rate, r.Price) AS [Est. Total]
                FROM Customers c
                INNER JOIN Rooms r ON r.Room_ID = c.Customer_Room_ID
                WHERE c.Customer_IsCheckOut = 'No'
                ORDER BY c.Customer_CheckIn, c.Customer_ID";

            return getData(query);
        }

        /// <summary>
        /// Returns the completed-stay revenue totals used by the dashboard.
        /// </summary>
        public DataTable GetBillingSummary()
        {
            const string query = @"
                SELECT
                    ISNULL(SUM(Customer_Total), 0) AS TotalRevenue,
                    ISNULL(SUM(CASE WHEN Customer_CheckOut = CAST(GETDATE() AS DATE)
                                    THEN Customer_Total ELSE 0 END), 0) AS TodayRevenue,
                    ISNULL(SUM(CASE WHEN Customer_IsCheckOut = 'Yes' THEN 1 ELSE 0 END), 0) AS CompletedStays
                FROM Customers";

            return getData(query);
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
                case 207:
                    return "The database schema is out of date. Run the scripts in database/migrations.";
                default:
                    return "A database error occurred. Please try again.";
            }
        }
    }
}
