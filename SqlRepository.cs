using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Low-level SQL Server operations with async support.
    /// </summary>
    internal static class SqlRepository
    {
        /// <summary>
        /// Creates a new SqlConnection using the HotelDb connection string from App.config.
        /// Throws a ConfigurationErrorsException if the string is missing.
        /// </summary>
        internal static SqlConnection GetConnection()
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
        /// Asynchronously creates a new SqlConnection using the HotelDb connection string from App.config.
        /// </summary>
        internal static async Task<SqlConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["HotelDb"];

            if (settings == null)
            {
                throw new ConfigurationErrorsException(
                    "Connection string 'HotelDb' was not found in App.config.");
            }

            var con = new SqlConnection(settings.ConnectionString);
            await con.OpenAsync(cancellationToken).ConfigureAwait(false);
            return con;
        }

        /// <summary>
        /// Adds an array of SqlParameter to the command (null‑safe).
        /// </summary>
        internal static void AddParameters(SqlCommand cmd, params SqlParameter[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
        }

        /// <summary>
        /// Shows a database error message using a MessageBox and logs it.
        /// Returns the friendly message string for convenience.
        /// </summary>
        internal static string ShowDatabaseError(SqlException ex)
        {
            // Log to file (Logger is internal elsewhere; we just call the static method here).
            try { Logger.Error(ex); } catch { /* best effort */ }

            MessageBox.Show(
                GetFriendlyMessage(ex),
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return GetFriendlyMessage(ex);
        }

        /// <summary>
        /// Maps common SQL error numbers to Arabic user‑friendly messages.
        /// </summary>
        internal static string GetFriendlyMessage(SqlException ex)
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

        /// <summary>
        /// Executes a non‑query inside a transaction and returns the affected rows count.
        /// If an exception occurs the transaction is rolled back and the method returns -1.
        /// </summary>
        internal static async Task<int> ExecuteNonQueryWithTransactionAsync(
            SqlConnection con,
            SqlTransaction tx,
            string sql,
            params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con, tx))
                {
                    AddParameters(cmd, parameters);
                    return await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
            catch (SqlException)
            {
                try { tx.Rollback(); } catch { /* already rolled back */ }
                return -1;
            }
        }

        /// <summary>
        /// Executes a scalar query inside a transaction and returns the parsed value.
        /// Returns default(T) on failure.
        /// </summary>
        internal static async Task<T> ExecuteScalarWithTransactionAsync<T>(
            SqlConnection con,
            SqlTransaction tx,
            string sql,
            params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, con, tx))
                {
                    AddParameters(cmd, parameters);
                    var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    return result != null ? (T)Convert.ChangeType(result, typeof(T)) : default;
                }
            }
            catch (SqlException)
            {
                try { tx.Rollback(); } catch { /* already rolled back */ }
                return default;
            }
        }
    }
}