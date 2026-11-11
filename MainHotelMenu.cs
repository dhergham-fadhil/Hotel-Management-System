using System;
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

            if (sender == roomsbtn)
            {
                control = new UC_Rooms();
            }
            else if (sender == customersbtn)
            {
                control = new UC_Customers();
            }
            else if (sender == staffbtn)
            {
                if (!currentUser.IsAdmin)
                {
                    MessageBox.Show("You do not have permission to manage staff.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                control = new UC_Staff();
            }
            else if (sender == bookingsbtn)
            {
                control = new UC_Booking();
            }
            else if (sender == guestsbtn)
            {
                control = new UC_Guests();
            }

            if (control != null)
                AddUserControl(control);
        }

        private void roomsbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void customersbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void staffbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void bookingsbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void guestsbtn_Click(object sender, EventArgs e)
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

            labelUser.Text = currentUser.Name + "  (" + currentUser.Role + ")";

            if (!currentUser.IsAdmin)
            {
                staffbtn.Visible = false;
                guestsbtn.Location = new System.Drawing.Point(630, 0);
            }

            // Open on the dashboard so the user sees the hotel overview first.
            roomsbtn.Checked = false;
            bookingsbtn.Checked = true;
            bookingsbtn.PerformClick();
        }
    }
}
