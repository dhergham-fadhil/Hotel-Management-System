using System;
using System.IO;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Minimal file logger.
    /// Errors are appended to:
    /// %LOCALAPPDATA%\HotelManagementSystem\logs\error-yyyy-MM-dd.log
    /// </summary>
    internal static class Logger
    {
        private static readonly object SyncRoot = new object();

        public static void Error(Exception exception)
        {
            if (exception == null)
                return;

            try
            {
                string directory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "HotelManagementSystem",
                    "logs");

                Directory.CreateDirectory(directory);

                string file = Path.Combine(
                    directory,
                    "error-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");

                string line = DateTime.Now.ToString("s") + " | " + exception + Environment.NewLine;

                lock (SyncRoot)
                {
                    File.AppendAllText(file, line);
                }
            }
            catch
            {
                // Logging must never crash the application.
            }
        }
    }
}
