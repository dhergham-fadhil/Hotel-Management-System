using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Staff : UserControl
    {
        private readonly function fn = new function();

        public UC_Staff()
        {
            InitializeComponent();
        }

        private void ClearALL()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            cmBoxGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateStaffInput(out string userName))
                return;

            if (UserNameExists(userName))
            {
                Fail("This user name is already taken.", txtUserName);
                return;
            }

            const string query = @"
                INSERT INTO Staff
                    (Staff_Name, Staff_Mobile, Staff_Gender, Staff_Email, Staff_UserName, Staff_Password)
                VALUES
                    (@name, @mobile, @gender, @email, @userName, @password)";

            // TODO: hash the password before storing it (Phase 3).
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.VarChar, 75) { Value = txtName.Text.Trim() },
                new SqlParameter("@mobile", SqlDbType.VarChar, 25) { Value = txtMobileNo.Text.Trim() },
                new SqlParameter("@gender", SqlDbType.VarChar, 50) { Value = cmBoxGender.Text },
                new SqlParameter("@email", SqlDbType.VarChar, 120) { Value = txtEmail.Text.Trim() },
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = userName },
                new SqlParameter("@password", SqlDbType.VarChar, 150) { Value = txtPassword.Text }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("Staff registered.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearALL();
            }
            else if (affected == 0)
            {
                MessageBox.Show("No staff record was added.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateStaffInput(out string userName)
        {
            userName = (txtUserName.Text ?? string.Empty).Trim();

            string name = (txtName.Text ?? string.Empty).Trim();
            if (name.Length == 0)
                return Fail("Staff name is required.", txtName);
            if (name.Length < 2)
                return Fail("Staff name must be at least 2 characters.", txtName);
            if (name.Length > 75)
                return Fail("Staff name cannot exceed 75 characters.", txtName);

            if (!Validation.IsValidMobile(txtMobileNo.Text))
                return Fail("Enter a valid mobile number (7-15 digits).", txtMobileNo);

            if (cmBoxGender.SelectedIndex < 0)
                return Fail("Select a gender.", cmBoxGender);

            string email = (txtEmail.Text ?? string.Empty).Trim();
            if (!Validation.IsValidEmail(email))
                return Fail("Enter a valid e-mail address.", txtEmail);
            if (email.Length > 120)
                return Fail("E-mail cannot exceed 120 characters.", txtEmail);

            if (!Validation.IsValidUserName(userName))
                return Fail("User name must be 3-150 characters (letters, digits, dot, underscore, hyphen).",
                    txtUserName);

            if (!Validation.IsValidPassword(txtPassword.Text))
                return Fail("Password must be at least 8 characters and contain a letter and a digit.",
                    txtPassword);

            return true;
        }

        private bool UserNameExists(string userName)
        {
            DataTable table = fn.getData(
                "SELECT Staff_ID FROM Staff WHERE Staff_UserName = @userName",
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = userName });

            return table.Rows.Count > 0;
        }

        private void LoadStaff(Guna2DataGridView grid)
        {
            // Never select Staff_Password: it must not be shown on screen.
            const string query = @"
                SELECT Staff_ID, Staff_Name, Staff_Mobile, Staff_Gender, Staff_Email, Staff_UserName
                FROM Staff
                ORDER BY Staff_ID";

            grid.DataSource = fn.getData(query);
        }

        private void tabStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabStaff.SelectedIndex == 1)
            {
                LoadStaff(DGV_StaffDetails);
            }
            else if (tabStaff.SelectedIndex == 2)
            {
                LoadStaff(DGV_StaffDelete);
            }
        }

        private void staffDeletebtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStaffDeleteID.Text.Trim(), out int staffId))
            {
                MessageBox.Show("Enter a valid staff ID.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffDeleteID.Focus();
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            const string query = "DELETE FROM Staff WHERE Staff_ID = @staffId";

            SqlParameter[] parameters =
            {
                new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("Record deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtStaffDeleteID.Clear();
                LoadStaff(DGV_StaffDetails);
                LoadStaff(DGV_StaffDelete);
            }
            else if (affected == 0)
            {
                MessageBox.Show("Staff ID not found.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }
    }
}
