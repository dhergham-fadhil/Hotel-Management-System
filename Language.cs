using System;
using System.IO;

namespace Hotel_Managment_System
{
    /// <summary>
    /// Languages supported by the user interface. Database values are always
    /// stored in English; this only controls what the user sees.
    /// </summary>
    public enum AppLanguage
    {
        Arabic,
        English
    }

    /// <summary>
    /// Central language switch. Call <see cref="T"/> with the Arabic and
    /// English versions of a text and the manager returns the right one.
    /// The choice is persisted under %AppData% so it survives restarts.
    /// </summary>
    public static class Language
    {
        private static readonly string SettingsFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "HotelManagementSystem");

        private static readonly string SettingsFile = Path.Combine(
            SettingsFolder, "language.txt");

        /// <summary>Raised after <see cref="Set"/> changes the language.</summary>
        public static event EventHandler Changed;

        static Language()
        {
            Current = Load();
        }

        public static AppLanguage Current { get; private set; }

        public static bool IsArabic
        {
            get { return Current == AppLanguage.Arabic; }
        }

        /// <summary>Returns the text matching the current language.</summary>
        public static string T(string arabic, string english)
        {
            return IsArabic ? arabic : english;
        }

        /// <summary>Switches language and notifies every open screen.</summary>
        public static void Set(AppLanguage language)
        {
            if (Current == language)
                return;

            Current = language;
            Save(language);

            EventHandler handler = Changed;
            if (handler != null)
                handler(null, EventArgs.Empty);
        }

        private static AppLanguage Load()
        {
            try
            {
                if (File.Exists(SettingsFile))
                {
                    string value = File.ReadAllText(SettingsFile).Trim();

                    if (string.Equals(value, "en", StringComparison.OrdinalIgnoreCase))
                        return AppLanguage.English;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            // The application ships in Arabic.
            return AppLanguage.Arabic;
        }

        private static void Save(AppLanguage language)
        {
            try
            {
                Directory.CreateDirectory(SettingsFolder);
                File.WriteAllText(SettingsFile,
                    language == AppLanguage.English ? "en" : "ar");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }

    /// <summary>
    /// Implemented by every screen that has translatable text so the main
    /// window can refresh it immediately when the language changes.
    /// </summary>
    public interface ILocalizable
    {
        void ApplyLanguage();
    }
}
