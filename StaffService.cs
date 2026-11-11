using System;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Provides services for staff management operations.
    /// Currently supports password reset for staff members.
    /// </summary>
    internal static class StaffService
    {
        /// <summary>
        /// Replaces a staff member's password with a fresh PBKDF2 hash.
        /// The policy is enforced (minimum 8 characters, at least one letter and one digit,
        /// maximum 128 characters). Delegates to AuthRepository for the actual data operation.
        /// </summary>
        internal static bool ResetStaffPassword(int staffId, string newPassword, out string error)
        {
            return AuthRepository.ResetStaffPassword(staffId, newPassword, out error);
        }
    }
}