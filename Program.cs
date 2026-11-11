using System;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Global safety net: log unexpected errors instead of crashing silently.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Sign in first, then run the main window. "Logout" closes the menu
            // and returns here so another user can sign in without restarting.
            while (true)
            {
                StaffUser user;

                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK || login.AuthenticatedUser == null)
                        return;

                    user = login.AuthenticatedUser;
                }

                using (MainHotelMenu menu = new MainHotelMenu(user))
                {
                    Application.Run(menu);

                    if (!menu.LogoutRequested)
                        return;
                }
            }
        }

        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.Error(e.Exception);

            MessageBox.Show(
                "An unexpected error occurred. The details were written to the log file.",
                "Unexpected Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error(e.ExceptionObject as Exception);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
