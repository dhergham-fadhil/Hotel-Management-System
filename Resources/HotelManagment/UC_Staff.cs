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
                Fail("اسم المستخدم مستخدم بالفعل.", txtUserName);
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
                new SqlParameter("@gender", SqlDbType.VarChar, 50) { Value = ToDatabaseGender(cmBoxGender.Text) },
                new SqlParameter("@email", SqlDbType.VarChar, 120) { Value = txtEmail.Text.Trim() },
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = userName },
                new SqlParameter("@password", SqlDbType.VarChar, 150) { Value = PasswordHasher.Hash(txtPassword.Text) },
                new SqlParameter("@role", SqlDbType.VarChar, 20) { Value = role }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("تم تسجيل الموظف.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearALL();
            }
            else if (affected == 0)
            {
                MessageBox.Show("لم تتم إضافة أي سجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string ToDatabaseRole(string value)
        {
            switch (value)
            {
                case "مدير":
                    return "Admin";
                case "موظف":
                    return "Staff";
                default:
                    return value;
            }
        }

        private static string ToDatabaseGender(string value)
        {
            switch (value)
            {
                case "ذكر":
                    return "Male";
                case "أنثى":
                    return "Female";
                case "آخر":
                    return "Other";
                case "أفضل عدم الإجابة":
                    return "I Rather Do Not Answer";
                default:
                    return value;
            }
        }

        private bool ValidateStaffInput(out string userName, out string role)
        {
            userName = (txtUserName.Text ?? string.Empty).Trim();
            role = ToDatabaseRole((cmBoxRole.Text ?? string.Empty).Trim());

            string name = (txtName.Text ?? string.Empty).Trim();
            if (name.Length == 0)
                return Fail("اسم الموظف مطلوب.", txtName);
            if (name.Length < 2)
                return Fail("يجب أن يكون اسم الموظف حرفين على الأقل.", txtName);
            if (name.Length > 75)
                return Fail("لا يمكن أن يتجاوز اسم الموظف 75 حرفاً.", txtName);

            if (!Validation.IsValidMobile(txtMobileNo.Text))
                return Fail("أدخل رقم جوال صحيحاً (7-15 رقماً).", txtMobileNo);

            if (cmBoxGender.SelectedIndex < 0)
                return Fail("اختر الجنس.", cmBoxGender);

            string email = (txtEmail.Text ?? string.Empty).Trim();
            if (!Validation.IsValidEmail(email))
                return Fail("أدخل بريداً إلكترونياً صحيحاً.", txtEmail);
            if (email.Length > 120)
                return Fail("لا يمكن أن يتجاوز البريد الإلكتروني 120 حرفاً.", txtEmail);

            if (!Validation.IsValidUserName(userName))
                return Fail("اسم المستخدم من 3 إلى 150 حرفاً (حروف، أرقام، نقطة، شرطة سفلية، شرطة).",
                    txtUserName);

            if (!Validation.IsValidPassword(txtPassword.Text))
                return Fail("كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم.",
                    txtPassword);

            if (txtPassword.Text.Length > 128)
                return Fail("لا يمكن أن تتجاوز كلمة المرور 128 حرفاً.", txtPassword);

            if (role != "Admin" && role != "Staff")
                return Fail("اختر الصلاحية.", cmBoxRole);

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
            ApplyStaffGridHeaders(grid);
        }

        /// <summary>
        /// Replaces the raw column names with Arabic headers after a data bind.
        /// </summary>
        private static void ApplyStaffGridHeaders(Guna2DataGridView grid)
        {
            if (grid.Columns.Count == 0)
            {
                return;
            }

            grid.Columns["Staff_ID"].HeaderText = "الرقم";
            grid.Columns["Staff_Name"].HeaderText = "الاسم";
            grid.Columns["Staff_Mobile"].HeaderText = "رقم الجوال";
            grid.Columns["Staff_Gender"].HeaderText = "الجنس";
            grid.Columns["Staff_Email"].HeaderText = "البريد الإلكتروني";
            grid.Columns["Staff_UserName"].HeaderText = "اسم المستخدم";
            grid.Columns["Staff_Role"].HeaderText = "الصلاحية";
        }

        private void DGV_StaffDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            object value = DGV_StaffDelete.Rows[e.RowIndex].Cells["Staff_ID"].Value;

            if (value != null && value != DBNull.Value)
            {
                txtStaffDeleteID.Text = value.ToString();
            }
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
                MessageBox.Show("اختر موظفاً.", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selection = cmBoxResetStaff.SelectedItem.ToString();

            if (!int.TryParse(selection.Split('-')[0], out int staffId))
            {
                MessageBox.Show("اختر موظفاً.", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!Validation.IsValidPassword(newPassword))
            {
                MessageBox.Show("كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم.",
                    "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length > 128)
            {
                MessageBox.Show("لا يمكن أن تتجاوز كلمة المرور 128 حرفاً.", "تحقق",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("كلمتا المرور غير متطابقتين.", "تحقق",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!fn.ResetStaffPassword(staffId, newPassword, out string error))
            {
                MessageBox.Show(error ?? "تعذّر إعادة تعيين كلمة المرور.", "فشل إعادة التعيين",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("تمت إعادة تعيين كلمة المرور بنجاح.", "نجاح",
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
                MessageBox.Show("أدخل رقم موظف صحيحاً.", "تحذير",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffDeleteID.Focus();
                return;
            }

            DataTable target = fn.getData(
                "SELECT Staff_Role FROM Staff WHERE Staff_ID = @staffId",
                new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

            if (target.Rows.Count == 0)
            {
                MessageBox.Show("رقم الموظف غير موجود.", "تنبيه",
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
                    MessageBox.Show("لا يمكن حذف آخر حساب مدير.",
                        "غير مسموح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (MessageBox.Show("هل أنت متأكد من حذف هذا الموظف؟", "تأكيد",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            const string query = "DELETE FROM Staff WHERE Staff_ID = @staffId";

            int affected = fn.setData(query,
                new SqlParameter("@staffId", SqlDbType.Int) { Value = staffId });

            if (affected > 0)
            {
                MessageBox.Show("تم حذف السجل.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtStaffDeleteID.Clear();
                LoadStaff(DGV_StaffDetails);
                LoadStaff(DGV_StaffDelete);
            }
            else if (affected == 0)
            {
                MessageBox.Show("رقم الموظف غير موجود.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "تحقق",
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
            Theme.StyleInput(txtNewPassword);
            Theme.StyleInput(txtConfirmPassword);
            Theme.StyleCombo(cmBoxResetStaff);

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

            // Headings and tab pages follow the shared theme.
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Theme.TextPrimary;
            labelResetTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelResetTitle.ForeColor = Theme.TextPrimary;

            tabRegisteration.BackColor = Theme.Background;
            tabDetails.BackColor = Theme.Background;
            tabDelete.BackColor = Theme.Background;
            tabResetPassword.BackColor = Theme.Background;

            // Grids: readable font and a visible header row.
            DGV_StaffDetails.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DGV_StaffDetails.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DGV_StaffDelete.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DGV_StaffDelete.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DGV_StaffDetails.Font = new Font("Segoe UI", 9F);
            DGV_StaffDelete.Font = new Font("Segoe UI", 9F);
        }
    }
}
