using System;
using System.Drawing;
using System.Windows.Forms;
using Hotel_Managment_System.Resources.HotelManagment;

namespace Hotel_Managment_System
{
    public partial class MainHotelMenu : Form
    {
        private readonly StaffUser currentUser;

        public MainHotelMenu()
        {
            InitializeComponent();
        }

        internal MainHotelMenu(StaffUser user) : this()
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            currentUser = user;
        }

        public bool LogoutRequested { get; private set; }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sign out of the current account?", "Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            LogoutRequested = true;
            Close();
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;

            // Dispose the previous screen so its GDI handles are released.
            while (UC_Panel.Controls.Count > 0)
            {
                Control previous = UC_Panel.Controls[0];
                UC_Panel.Controls.Remove(previous);
                previous.Dispose();
            }

            UC_Panel.Controls.Add(uc);
            uc.BringToFront();
        }

        private void NavigationButton_Click(object sender, EventArgs e)
        {
            UserControl control = null;

            if (sender == btnRooms)
            {
                control = new UC_Rooms();
            }
            else if (sender == btnCustomers)
            {
                control = new UC_Customers();
            }
            else if (sender == btnStaff)
            {
                if (!currentUser.IsAdmin)
                {
                    MessageBox.Show("You do not have permission to manage staff.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                control = new UC_Staff();
            }
            else if (sender == btnBookings)
            {
                control = new UC_Booking();
            }
            else if (sender == btnGuests)
            {
                control = new UC_Guests();
            }

            if (control != null)
                AddUserControl(control);
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void MainHotelMenu_Load(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show("No active session was found. Please sign in again.",
                    "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            ApplyTheme();

            labelUser.Text = currentUser.Name + "  (" + currentUser.Role + ")";

            if (!currentUser.IsAdmin)
            {
                btnStaff.Visible = false;
            }

            // Open on the dashboard so the user sees the hotel overview first.
            btnBookings.Checked = true;
            btnBookings.PerformClick();
        }

        private void ApplyTheme()
        {
            // Header
            panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            labelHotel.ForeColor = Theme.AccentGold;
            labelHotel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelUser.ForeColor = Color.FromArgb(243, 246, 249);
            labelUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Close button
            Theme.StyleDangerButton(btnClose);

            // Sidebar
            panelSidebar.BackColor = Theme.Sidebar;

            // Navigation buttons
            Theme.StyleNavButton(btnBookings, true);
            Theme.StyleNavButton(btnRooms, false);
            Theme.StyleNavButton(btnCustomers, false);
            Theme.StyleNavButton(btnGuests, false);
            Theme.StyleNavButton(btnStaff, false);
            Theme.StyleNavButton(btnLogout, false);

            // Content area
            UC_Panel.BackColor = Theme.Background;
        }
    }
}
