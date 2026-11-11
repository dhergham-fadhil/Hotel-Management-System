using System;

namespace Hotel_Managment_System
{
    /// <summary>
    /// The signed-in staff member. Created only after a successful login.
    /// </summary>
    internal sealed class StaffUser
    {
        public StaffUser(int staffId, string name, string userName, string role)
        {
            StaffId = staffId;
            Name = name ?? string.Empty;
            UserName = userName ?? string.Empty;
            Role = string.IsNullOrWhiteSpace(role) ? "Staff" : role;
        }

        public int StaffId { get; }

        public string Name { get; }

        public string UserName { get; }

        public string Role { get; }

        public bool IsAdmin
        {
            get { return string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase); }
        }
    }
}
