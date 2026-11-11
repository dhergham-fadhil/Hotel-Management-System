using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Hotel_Managment_System
{
    internal enum PasswordVerificationResult
    {
        Failed,
        Success,
        SuccessRehashNeeded
    }

    /// <summary>
    /// PBKDF2-HMAC-SHA256 password hashing.
    /// Stored format: PBKDF2$iterations$base64(salt)$base64(hash)
    /// </summary>
    internal static class PasswordHasher
    {
        private const string Prefix = "PBKDF2";
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        // Used to keep the login response time similar when the user does not exist.
        private static readonly string DummyHash = Hash("dummy-password-for-timing");

        public static string Hash(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] salt = new byte[SaltSize];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = Derive(password, salt, Iterations);

            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}${1}${2}${3}",
                Prefix,
                Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public static bool IsHashed(string value)
        {
            return !string.IsNullOrEmpty(value)
                && value.StartsWith(Prefix + "$", StringComparison.Ordinal);
        }

        public static PasswordVerificationResult Verify(string storedValue, string providedPassword)
        {
            if (string.IsNullOrEmpty(storedValue))
                return PasswordVerificationResult.Failed;

            string provided = providedPassword ?? string.Empty;

            // Legacy rows: compare in constant time, then ask the caller to rehash.
            if (!IsHashed(storedValue))
            {
                return FixedTimeEquals(
                    Encoding.UTF8.GetBytes(storedValue),
                    Encoding.UTF8.GetBytes(provided))
                    ? PasswordVerificationResult.SuccessRehashNeeded
                    : PasswordVerificationResult.Failed;
            }

            string[] parts = storedValue.Split('$');
            if (parts.Length != 4)
                return PasswordVerificationResult.Failed;

            if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int iterations)
                || iterations <= 0)
                return PasswordVerificationResult.Failed;

            byte[] salt;
            byte[] expected;

            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expected = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return PasswordVerificationResult.Failed;
            }

            byte[] actual = Derive(provided, salt, iterations);

            if (!FixedTimeEquals(expected, actual))
                return PasswordVerificationResult.Failed;

            return iterations == Iterations
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.SuccessRehashNeeded;
        }

        /// <summary>
        /// Runs a real verification even when the user name does not exist,
        /// so response time does not reveal valid user names.
        /// </summary>
        public static void VerifyDummy(string providedPassword)
        {
            Verify(DummyHash, providedPassword);
        }

        private static byte[] Derive(string password, byte[] salt, int iterations)
        {
            using (Rfc2898DeriveBytes pbkdf2 =
                new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
                return false;

            int difference = 0;
            for (int i = 0; i < left.Length; i++)
            {
                difference |= left[i] ^ right[i];
            }

            return difference == 0;
        }
    }
}
