using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Handles all customer-related database operations: check-out, and dashboard queries.
    /// </summary>
    internal static class CustomerRepository
    {
        /// <summary>
        /// Checks a guest out, writes the final bill, and frees the room.
        /// The whole operation runs in one transaction; the customer row is
        /// locked so two operators cannot check out the same guest twice.
        /// </summary>
        internal static async Task<bool> CheckoutCustomerAsync(
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
                using (SqlConnection con = await SqlRepository.GetConnectionAsync().ConfigureAwait(false))
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
        /// Returns KPI values shown on the dashboard as Metric / Value rows.
        /// </summary>
        internal static async Task<DataTable> GetDashboardStatisticsAsync()
        {
            const string query = @"
                SELECT 'TotalRooms' AS Metric, COUNT(*) AS Value FROM Rooms
                UNION ALL SELECT 'FreeRooms', COUNT(*) FROM Rooms WHERE Status = 'Free'
                UNION ALL SELECT 'BusyRooms', COUNT(*) FROM Rooms WHERE Status = 'Busy'
                UNION ALL SELECT 'TotalCustomers', COUNT(*) FROM Customers
                UNION ALL SELECT 'ActiveCustomers', COUNT(*) FROM Customers WHERE Customer_IsCheckOut = 'No'
                UNION ALL SELECT 'TotalStaff', COUNT(*) FROM Staff";

            return await SqlRepository.GetDataAsync(query).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the most recent stays, newest first. Active guests show an
        /// estimate; checked-out guests show their stored final bill.
        /// </summary>
        internal static async Task<DataTable> GetRecentCustomersAsync(int count)
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

            return await SqlRepository.GetDataAsync(query,
                new SqlParameter("@count", SqlDbType.Int) { Value = count }).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the guests who are still checked in, with the current
        /// estimate based on the rate captured at check-in.
        /// </summary>
        internal static async Task<DataTable> GetActiveCustomersAsync()
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

            return await SqlRepository.GetDataAsync(query).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the completed-stay revenue totals used by the dashboard.
        /// </summary>
        internal static async Task<DataTable> GetBillingSummaryAsync()
        {
            const string query = @"
                SELECT
                    ISNULL(SUM(Customer_Total), 0) AS TotalRevenue,
                    ISNULL(SUM(CASE WHEN Customer_CheckOut = CAST(GETDATE() AS DATE)
                                    THEN Customer_Total ELSE 0 END), 0) AS TodayRevenue,
                    ISNULL(SUM(CASE WHEN Customer_IsCheckOut = 'Yes' THEN 1 ELSE 0 END), 0) AS CompletedStays
                FROM Customers";

            return await SqlRepository.GetDataAsync(query).ConfigureAwait(false);
        }
    }
}