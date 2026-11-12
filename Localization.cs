namespace Hotel_Managment_System
{
    /// <summary>
    /// Bridges the English values stored in the database with the Arabic text
    /// shown in the user interface.
    ///
    /// The database columns are VARCHAR, so the dictionary values must stay in
    /// English. Every screen displays the Arabic labels and converts them back
    /// before writing to SQL, which keeps legacy rows readable.
    /// </summary>
    public static class Localization
    {
        private static string Clean(string value)
        {
            return (value ?? string.Empty).Trim();
        }

        // ------------------------------------------------------------------
        // Gender
        // ------------------------------------------------------------------
        public static string GenderToArabic(string value)
        {
            switch (Clean(value))
            {
                case "Male": return "ذكر";
                case "Female": return "أنثى";
                case "Other": return "آخر";
                case "I Rather Do Not Answer": return "أفضل عدم الإجابة";
                default: return Clean(value);
            }
        }

        public static string GenderToDatabase(string value)
        {
            switch (Clean(value))
            {
                case "ذكر": return "Male";
                case "أنثى": return "Female";
                case "آخر": return "Other";
                case "أفضل عدم الإجابة": return "I Rather Do Not Answer";
                default: return Clean(value);
            }
        }

        // ------------------------------------------------------------------
        // Staff role
        // ------------------------------------------------------------------
        public static string RoleToArabic(string value)
        {
            switch (Clean(value))
            {
                case "Admin": return "مدير";
                case "Staff": return "موظف";
                default: return Clean(value);
            }
        }

        public static string RoleToDatabase(string value)
        {
            switch (Clean(value))
            {
                case "مدير": return "Admin";
                case "موظف": return "Staff";
                default: return Clean(value);
            }
        }

        // ------------------------------------------------------------------
        // Room type
        // ------------------------------------------------------------------
        public static string RoomTypeToArabic(string value)
        {
            switch (Clean(value))
            {
                case "Single": return "فردية";
                case "Double": return "مزدوجة";
                case "Twin": return "توأم";
                case "Triple": return "ثلاثية";
                case "Suite": return "جناح";
                default: return Clean(value);
            }
        }

        public static string RoomTypeToDatabase(string value)
        {
            switch (Clean(value))
            {
                case "فردية": return "Single";
                case "مزدوجة": return "Double";
                case "توأم": return "Twin";
                case "ثلاثية": return "Triple";
                case "جناح": return "Suite";
                default: return Clean(value);
            }
        }

        // ------------------------------------------------------------------
        // Bed type
        // ------------------------------------------------------------------
        public static string BedToArabic(string value)
        {
            switch (Clean(value))
            {
                case "Single": return "فردي";
                case "Double": return "مزدوج";
                case "Queen": return "كوين";
                case "King": return "كينغ";
                case "Twin": return "توأم";
                case "Bunk": return "بطابقين";
                default: return Clean(value);
            }
        }

        public static string BedToDatabase(string value)
        {
            switch (Clean(value))
            {
                case "فردي": return "Single";
                case "مزدوج": return "Double";
                case "كوين": return "Queen";
                case "كينغ": return "King";
                case "توأم": return "Twin";
                case "بطابقين": return "Bunk";
                default: return Clean(value);
            }
        }

        // ------------------------------------------------------------------
        // Room status
        // ------------------------------------------------------------------
        public static string StatusToArabic(string value)
        {
            switch (Clean(value))
            {
                case "Free": return "شاغرة";
                case "Busy": return "مشغولة";
                default: return Clean(value);
            }
        }

        public static string StatusToDatabase(string value)
        {
            switch (Clean(value))
            {
                case "شاغرة": return "Free";
                case "مشغولة": return "Busy";
                default: return Clean(value);
            }
        }

        // ------------------------------------------------------------------
        // Language-aware display helpers
        //
        // The database always stores English values. These helpers render the
        // value in the language currently selected and also provide the item
        // lists used by the combo boxes.
        // ------------------------------------------------------------------
        public static string GenderDisplay(string value)
        {
            return Language.IsArabic ? GenderToArabic(value) : Clean(value);
        }

        public static string RoleDisplay(string value)
        {
            return Language.IsArabic ? RoleToArabic(value) : Clean(value);
        }

        public static string RoomTypeDisplay(string value)
        {
            return Language.IsArabic ? RoomTypeToArabic(value) : Clean(value);
        }

        public static string BedDisplay(string value)
        {
            return Language.IsArabic ? BedToArabic(value) : Clean(value);
        }

        public static string StatusDisplay(string value)
        {
            return Language.IsArabic ? StatusToArabic(value) : Clean(value);
        }

        public static string ActivityDisplay(string value)
        {
            if (!Language.IsArabic)
                return Clean(value);

            switch (Clean(value))
            {
                case "Active": return "نشط";
                case "Checked Out": return "غادر";
                default: return Clean(value);
            }
        }

        public static string[] GenderItems()
        {
            return Language.IsArabic
                ? new[] { "ذكر", "أنثى", "آخر", "أفضل عدم الإجابة" }
                : new[] { "Male", "Female", "Other", "I Rather Do Not Answer" };
        }

        public static string[] RoleItems()
        {
            // Staff first so a new staff account defaults to the Staff role.
            return Language.IsArabic
                ? new[] { "موظف", "مدير" }
                : new[] { "Staff", "Admin" };
        }

        public static string[] RoomTypeItems()
        {
            return Language.IsArabic
                ? new[] { "فردية", "مزدوجة", "توأم", "ثلاثية", "جناح" }
                : new[] { "Single", "Double", "Twin", "Triple", "Suite" };
        }

        public static string[] BedItems()
        {
            return Language.IsArabic
                ? new[] { "فردي", "مزدوج", "كوين", "كينغ", "توأم", "بطابقين" }
                : new[] { "Single", "Double", "Queen", "King", "Twin", "Bunk" };
        }

        public static string[] StatusItems()
        {
            return Language.IsArabic
                ? new[] { "شاغرة", "مشغولة" }
                : new[] { "Free", "Busy" };
        }
    }
}
