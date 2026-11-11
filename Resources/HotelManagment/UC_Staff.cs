using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            ApplyTheme();
        }

        private void ClearALL()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            cmBoxGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cmBoxRole.SelectedIndex = 0;
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateStaffInput(out string userName, out string role))
                return;

            if (UserNameExists(userName))
            {
                Fail("This user name is already taken.", txtUserName);
                return;
            }

            const string query = @"
                INSERT INTO Staff
                    (Staff_Name, Staff_Mobile, Staff_Gender, Staff_Email, Staff_UserName, Staff_Password, Staff_Role)
                VALUES
                    (@name, @mobile, @gender, @email, @userName, @password, @role)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.VarChar, 75) { Value = txtName.Text.Trim() },
                new SqlParameter("@mobile", SqlDbType.VarChar, 25) { Value = txtMobileNo.Text.Trim() },
                new SqlParameter("@gender", SqlDbType.VarChar, 50) { Value = cmBoxGender.Text },
                new SqlParameter("@email", SqlDbType.VarChar, 120) { Value = txtEmail.Text.Trim() },
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = userName },
                new SqlParameter("@password", SqlDbType.VarChar, 150) { Value = PasswordHasher.Hash(txtPassword.Text) },
                new SqlParameter("@role", SqlDbType.VarChar, 20) { Value = role }
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

        private bool ValidateStaffInput(out string userName, out string role)
        {
            userName = (txtUserName.Text ?? string.Empty).Trim();
            role = (cmBoxRole.Text ?? string.Empty).Trim();

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

            if (txtPassword.Text.Length > 128)
                return Fail("Password cannot exceed 128 characters.", txtPassword);

            if (role != "Admin" && role != "Staff")
                return Fail("Select a role.", cmBoxRole);

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
                SELECT Staff_ID, Staff_Name, Staff_Mobile, Staff_Gender, Staff_Email, Staff_UserName, Staff_Role
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
            else if (tabStaff.SelectedIndex == 3)
            {
                LoadResetStaff();
            }
        }

        private void LoadResetStaff()
        {
            DataTable table = fn.getData(
                "SELECT Staff_ID, Staff_UserName, Staff_Name FROM Staff ORDER BY Staff_ID");

            cmBoxResetStaff.Items.Clear();

            foreach (DataRow row in table.Rows)
            {
                cmBoxResetStaff.Items.Add(
                    Convert.ToInt32(row["Staff_ID"]) + " - " + Convert.ToString(row["Staff_UserName"]));
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (cmBoxResetStaff.SelectedIndex < 0)
            {
                MessageBox.Show("Select a staff member.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selection = cmBoxResetStaff.SelectedItem.ToString();

            if (!int.TryParse(selection.Split('-')[0], out int staffId))
            {
                MessageBox.Show("Select a staff member.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!Validation.IsValidPassword(newPassword))
            {
                MessageBox.Show("Password must be at least 8 characters and contain a letter and a digit.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length > 128)
            {
                MessageBox.Show("Password cannot exceed 128 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The two passwords do not match.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!fn.ResetStaffPassword(staffId, newPassword, out string error))
            {
                MessageBox.Show(error ?? "The password could not be reset.", "Reset Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Password reset successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearResetForm();
        }

        private void ClearResetForm()
        {
            cmBoxResetStaff.SelectedIndex = -1;
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
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

            DataTable target = fn.getData(
                "SELECT Staff_Role FROM Staff WHERE Staff_ID = @staffId",
                new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

            if (target.Rows.Count == 0)
            {
                MessageBox.Show("Staff ID not found.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetRole = Convert.ToString(target.Rows[0]["Staff_Role"]);

            if (targetRole == "Admin")
            {
                DataTable otherAdmins = fn.getData(
                    "SELECT COUNT(*) AS AdminCount FROM Staff WHERE Staff_Role = 'Admin' AND Staff_ID <> @staffId",
                    new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

                int adminCount = otherAdmins.Rows.Count == 0
                    ? 0
                    : Convert.ToInt32(otherAdmins.Rows[0]["AdminCount"]);

                if (adminCount == 0)
                {
                    MessageBox.Show("You cannot delete the last administrator account.",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show("Are you sure?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            const string query = "DELETE FROM Staff WHERE Staff_ID = @staffId";

            int affected = fn.setData(query,
                new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

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

        private void ApplyTheme()
        {
            // Form fields
            Theme.StyleInput(txtName);
            Theme.StyleInput(txtMobileNo);
            Theme.StyleInput(txtEmail);
            Theme.StyleInput(txtUserName);
            Theme.StyleInput(txtPassword);

            Theme.StyleCombo(cmBoxGender);
            Theme.StyleCombo(cmBoxRole);

            Theme.StyleActionButton(registerbtn, true);

            // Buttons
            Theme.StyleDangerButton(staffDeletebtn);
            Theme.StyleActionButton(btnResetPassword, true);

            // Inputs for delete/reset
            Theme.StyleInput(txtStaffDeleteID);

            // Labels
            label1.ForeColor = Theme.TextSecondary;
            label2.ForeColor = Theme.TextSecondary;
            label4.ForeColor = Theme.TextSecondary;
            label8.ForeColor = Theme.TextSecondary;
            label9.ForeColor = Theme.TextSecondary;
            label10.ForeColor = Theme.TextSecondary;
            label11.ForeColor = Theme.TextSecondary;
            label3.ForeColor = Theme.TextSecondary;
            label6.ForeColor = Theme.TextSecondary;
            labelResetTitle.ForeColor = Theme.TextSecondary;
            labelResetStaff.ForeColor = Theme.TextSecondary;
            labelNewPassword.ForeColor = Theme.TextSecondary;
            labelConfirmPassword.ForeColor = Theme.TextSecondary;
            lblResetHint.ForeColor = Theme.TextMuted;

            label1.Font = new Font("Segoe UI", 9.5F);
            label2.Font = new Font("Segoe UI", 9.5F);
            label4.Font = new Font("Segoe UI", 9.5F);
            label8.Font = new Font("Segoe UI", 9.5F);
            label9.Font = new Font("Segoe UI", 9.5F);
            label10.Font = new Font("Segoe UI", 9.5F);
            label11.Font = new Font("Segoe UI", 9.5F);
            label3.Font = new Font("Segoe UI", 9.5F);
            label6.Font = new Font("Segoe UI", 9.5F);
        }
    }
}
