using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Hotel_Managment_System.Resources.HotelManagment;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Handles authentication-related operations: user verification,
    /// password verification with PBKDF2, legacy password upgrade,
    /// and staff password resets.
    /// </summary>
    internal static class AuthRepository
    {
        /// <summary>
        /// Validates a user name / password pair against the Staff table.
        /// Returns null when the credentials are invalid or the database fails
        /// (databaseError is set in the latter case).
        /// Legacy plain-text passwords are replaced with a PBKDF2 hash after a successful login.
        /// </summary>
        internal static StaffUser AuthenticateUser(string userName, string password, out bool databaseError)
        {
            databaseError = false;

            const string query = @"SELECT Staff_ID, Staff_Name, Staff_UserName, Staff_Password, Staff_Role
                FROM Staff WHERE Staff_UserName = @userName";

            DataTable table = new DataTable();

            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
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
                SqlRepository.ShowDatabaseError(ex);
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

        /// <summary>
        /// Upgrades a staff member's password hash from plain text to PBKDF2
        /// after a successful login. Logs errors but does not throw.
        /// </summary>
        internal static void UpgradePasswordHash(int staffId, string password)
        {
            const string query = "UPDATE Staff SET Staff_Password = @password WHERE Staff_ID = @staffId";

            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 150)
                    {
                        Value = PasswordHasher.Hash(password)
                    });
                    cmd.Parameters.Add(new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // The login itself succeeded; the upgrade will be retried next time.
                try { SqlRepository.Logger.Error(ex); } catch { /* best effort */ }
            }
        }

        /// <summary>
        /// Replaces a staff member's password with a fresh PBKDF2 hash.
        /// The policy is enforced here as well as in the UI so the data layer
        /// cannot be called with a weak password.
        /// </summary>
        internal static bool ResetStaffPassword(int staffId, string newPassword, out string error)
        {
            error = null;

            if (staffId <= 0)
            {
                error = "Select a staff member.";
                return false;
            }

            if (!Validation.IsValidPassword(newPassword))
            {
                error = "Password must be at least 8 characters and contain a letter and a digit.";
                return false;
            }

            if (newPassword.Length > 128)
            {
                error = "Password cannot exceed 128 characters.";
                return false;
            }

            const string query = "UPDATE Staff SET Staff_Password = @password WHERE Staff_ID = @staffId";

            try
            {
                using (SqlConnection con = SqlRepository.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 150)
                    {
                        Value = PasswordHasher.Hash(newPassword)
                    });
                    cmd.Parameters.Add(new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                        return true;

                    error = "Staff member not found.";
                    return false;
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