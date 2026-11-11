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
            if (string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtMobileNo.Text)
                || string.IsNullOrWhiteSpace(cmBoxGender.Text)
                || string.IsNullOrWhiteSpace(txtEmail.Text)
                || string.IsNullOrWhiteSpace(txtUserName.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Fill all fields.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = txtUserName.Text.Trim() },
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
    }
}
