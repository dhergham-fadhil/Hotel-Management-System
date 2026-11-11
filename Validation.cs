using System.Text.RegularExpressions;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Shared, framework-independent input validation rules.
    /// </summary>
    internal static class Validation
    {
        /// <summary>
        /// Accepts 7 to 15 characters made of digits, spaces, hyphens and an optional leading '+',
        /// and requires at least 7 digits.
        /// </summary>
        public static bool IsValidMobile(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            string trimmed = value.Trim();

            if (!Regex.IsMatch(trimmed, @"^\+?[0-9\s\-]{7,15}$"))
                return false;

            return Regex.Matches(trimmed, @"\d").Count >= 7;
        }

        /// <summary>
        /// Basic e-mail shape check: something@something.tld
        /// </summary>
        public static bool IsValidEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$");
        }

        /// <summary>
        /// Password policy: at least 8 characters, with at least one letter and one digit.
        /// </summary>
        public static bool IsValidPassword(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
                return false;

            return Regex.IsMatch(value, "[A-Za-z]") && Regex.IsMatch(value, "[0-9]");
        }

        /// <summary>
        /// User names may contain letters, digits, dots, underscores and hyphens.
        /// </summary>
        public static bool IsValidUserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(value.Trim(), @"^[A-Za-z0-9._\-]{3,150}$");
        }

        public static bool HasMaxLength(string value, int maxLength)
        {
            return value != null && value.Trim().Length <= maxLength;
        }
    }
}
