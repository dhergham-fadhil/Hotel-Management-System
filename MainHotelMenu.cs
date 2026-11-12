using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Hotel_Managment_System.Resources.HotelManagment;

namespace Hotel_Managment_System
{
    public partial class MainHotelMenu : Form
    {
        private readonly StaffUser currentUser;
        private Guna2Button btnLanguage;

        public MainHotelMenu()
        {
            InitializeComponent();
            CreateLanguageButton();
        }

        internal MainHotelMenu(StaffUser user) : this()
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            currentUser = user;
        }

        public bool LogoutRequested { get; private set; }

        private void CreateLanguageButton()
        {
            btnLanguage = new Guna2Button();
            btnLanguage.BorderRadius = 12;
            btnLanguage.Cursor = Cursors.Hand;
            btnLanguage.FillColor = Color.Transparent;
            btnLanguage.FocusedColor = Color.Empty;
            btnLanguage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLanguage.ForeColor = Theme.AccentGold;
            btnLanguage.HoverState.FillColor = Color.FromArgb(30, 41, 59);
            btnLanguage.HoverState.ForeColor = Color.White;
            btnLanguage.TextAlign = HorizontalAlignment.Center;
            btnLanguage.Click += languagebtn_Click;

            panelSidebar.Controls.Add(btnLanguage);

            // Set bounds after adding: WinForms scales Guna controls on add.
            btnLanguage.Bounds = new Rectangle(20, 548, 220, 44);
            btnLanguage.BringToFront();
        }

        private void languagebtn_Click(object sender, EventArgs e)
        {
            Language.Set(Language.IsArabic ? AppLanguage.English : AppLanguage.Arabic);
            ApplyLanguage();
        }

        private void Language_Changed(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            labelHotel.Text = Language.T("إدارة الفندق", "Hotel Management");

            btnBookings.Text = Language.T("لوحة القيادة", "Dashboard");
            btnRooms.Text = Language.T("الغرف", "Rooms");
            btnCustomers.Text = Language.T("العملاء", "Customers");
            btnGuests.Text = Language.T("النزلاء", "Guests");
            btnStaff.Text = Language.T("الموظفون", "Staff");
            btnLogout.Text = Language.T("تسجيل الخروج", "Log out");

            if (btnLanguage != null)
                btnLanguage.Text = Language.IsArabic ? "English" : "العربية";

            if (currentUser != null)
            {
                string role = Language.IsArabic
                    ? Localization.RoleToArabic(currentUser.Role)
                    : currentUser.Role;

                labelUser.Text = currentUser.Name + "  (" + role + ")";
            }

            // Refresh the screen that is currently open.
            for (int i = 0; i < UC_Panel.Controls.Count; i++)
            {
                ILocalizable localizable = UC_Panel.Controls[i] as ILocalizable;
                if (localizable != null)
                    localizable.ApplyLanguage();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Language.Changed -= Language_Changed;
            base.OnFormClosed(e);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Language.T("هل تريد تسجيل الخروج من الحساب الحالي؟",
                               "Sign out of the current account?"),
                    Language.T("تسجيل الخروج", "Logout"),
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
                    MessageBox.Show(
                        Language.T("ليس لديك صلاحية إدارة الموظفين.",
                                   "You do not have permission to manage staff."),
                        Language.T("تم رفض الوصول", "Access Denied"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(
                    Language.T("لا توجد جلسة نشطة. يرجى تسجيل الدخول مرة أخرى.",
                               "No active session was found. Please sign in again."),
                    Language.T("خطأ في الجلسة", "Session Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            Language.Changed += Language_Changed;

            ApplyTheme();
            ApplyLanguage();

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
