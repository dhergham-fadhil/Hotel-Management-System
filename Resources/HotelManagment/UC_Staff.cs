using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    /// <summary>
    /// Single-page staff management screen: a searchable grid on the left and
    /// an add/edit form on the right. The password field doubles as the reset
    /// action: typing a new password and saving updates the stored hash.
    /// </summary>
    public partial class UC_Staff : UserControl
    {
        private readonly function fn = new function();

        private int selectedStaffId;
        private string selectedDbRole;
        private DataTable staffTable;
        private bool loadingForm;

        public UC_Staff()
        {
            InitializeComponent();

            txtSearch.TextChanged += SearchChanged;
            cmbRoleFilter.SelectedIndexChanged += SearchChanged;
            btnRefresh.Click += btnRefresh_Click;
            DGV_Staff.CellClick += DGV_Staff_CellClick;
            btnSave.Click += btnSave_Click;
            btnNew.Click += btnNew_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void UC_Staff_Load(object sender, EventArgs e)
        {
            ApplyTheme();

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[] { "ذكر", "أنثى", "آخر", "أفضل عدم الإجابة" });

            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "موظف", "مدير" });

            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.AddRange(new object[] { "كل الصلاحيات", "مدير", "موظف" });
            cmbRoleFilter.SelectedIndex = 0;

            LoadStaff();
            ClearForm();
        }

        // ------------------------------------------------------------------
        // Data loading and filtering
        // ------------------------------------------------------------------
        private void LoadStaff()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable source = fn.getData(@"
                    SELECT Staff_ID, Staff_Name, Staff_Mobile, Staff_Gender,
                           Staff_Email, Staff_UserName, Staff_Role
                    FROM Staff
                    ORDER BY Staff_ID");

                staffTable = new DataTable();
                staffTable.Columns.Add("ID", typeof(int));
                staffTable.Columns.Add("Name", typeof(string));
                staffTable.Columns.Add("Mobile", typeof(string));
                staffTable.Columns.Add("Gender", typeof(string));
                staffTable.Columns.Add("Email", typeof(string));
                staffTable.Columns.Add("UserName", typeof(string));
                staffTable.Columns.Add("Role", typeof(string));
                staffTable.Columns.Add("DbGender", typeof(string));
                staffTable.Columns.Add("DbRole", typeof(string));

                foreach (DataRow row in source.Rows)
                {
                    string dbGender = Convert.ToString(row["Staff_Gender"]);
                    string dbRole = Convert.ToString(row["Staff_Role"]);

                    staffTable.Rows.Add(
                        Convert.ToInt32(row["Staff_ID"]),
                        Convert.ToString(row["Staff_Name"]),
                        Convert.ToString(row["Staff_Mobile"]),
                        Localization.GenderToArabic(dbGender),
                        Convert.ToString(row["Staff_Email"]),
                        Convert.ToString(row["Staff_UserName"]),
                        Localization.RoleToArabic(dbRole),
                        dbGender,
                        dbRole);
                }

                DGV_Staff.DataSource = new DataView(staffTable);
                ConfigureGrid();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("تعذّر تحميل بيانات الموظفين.", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ConfigureGrid()
        {
            if (DGV_Staff.Columns.Count == 0)
                return;

            HideColumn("ID");
            HideColumn("DbGender");
            HideColumn("DbRole");

            SetHeader("Name", "الاسم", 130);
            SetHeader("Mobile", "رقم الجوال", 100);
            SetHeader("Gender", "الجنس", 60);
            SetHeader("Email", "البريد الإلكتروني", 170);
            SetHeader("UserName", "اسم المستخدم", 120);
            SetHeader("Role", "الصلاحية", 70);
        }

        private void HideColumn(string name)
        {
            if (DGV_Staff.Columns[name] != null)
                DGV_Staff.Columns[name].Visible = false;
        }

        private void SetHeader(string name, string title, int weight)
        {
            if (DGV_Staff.Columns[name] == null)
                return;

            DGV_Staff.Columns[name].HeaderText = title;
            DGV_Staff.Columns[name].FillWeight = weight;
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (!(DGV_Staff.DataSource is DataView view))
                return;

            string search = (txtSearch.Text ?? string.Empty).Trim().Replace("'", "''");

            string role = null;
            if (cmbRoleFilter.SelectedIndex == 1)
                role = "مدير";
            else if (cmbRoleFilter.SelectedIndex == 2)
                role = "موظف";

            string filter = string.Empty;

            if (search.Length > 0)
            {
                filter = "(Name LIKE '%" + search + "%'" +
                         " OR UserName LIKE '%" + search + "%'" +
                         " OR Mobile LIKE '%" + search + "%'" +
                         " OR Email LIKE '%" + search + "%'" +
                         " OR Role LIKE '%" + search + "%')";
            }

            if (role != null)
            {
                string roleFilter = "Role = '" + role + "'";
                filter = filter.Length == 0 ? roleFilter : filter + " AND " + roleFilter;
            }

            view.RowFilter = filter;
            lblCount.Text = "عدد الموظفين: " + view.Count;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            int keep = selectedStaffId;
            LoadStaff();

            if (keep > 0)
                SelectRowById(keep);
            else
                ClearForm();
        }

        // ------------------------------------------------------------------
        // Grid selection
        // ------------------------------------------------------------------
        private void DGV_Staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = DGV_Staff.Rows[e.RowIndex];
            object id = row.Cells["ID"].Value;

            if (id == null || id == DBNull.Value)
                return;

            selectedStaffId = Convert.ToInt32(id);
            selectedDbRole = Convert.ToString(row.Cells["DbRole"].Value);

            loadingForm = true;

            txtName.Text = Convert.ToString(row.Cells["Name"].Value);
            txtMobile.Text = Convert.ToString(row.Cells["Mobile"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtUserName.Text = Convert.ToString(row.Cells["UserName"].Value);
            txtPassword.Clear();
            cmbGender.SelectedItem = Convert.ToString(row.Cells["Gender"].Value);
            cmbRole.SelectedItem = Convert.ToString(row.Cells["Role"].Value);

            loadingForm = false;

            labelFormTitle.Text = "تعديل بيانات الموظف";
            lblFormHint.Text = "اترك كلمة المرور فارغة للإبقاء على الكلمة الحالية.";
            txtPassword.PlaceholderText = "اتركها فارغة لعدم التغيير";
            btnSave.Text = "حفظ التعديلات";
            btnDelete.Enabled = true;
        }

        private void SelectRowById(int staffId)
        {
            foreach (DataGridViewRow row in DGV_Staff.Rows)
            {
                object value = row.Cells["ID"].Value;

                if (value != null && value != DBNull.Value && Convert.ToInt32(value) == staffId)
                {
                    row.Selected = true;
                    DGV_Staff_CellClick(this, new DataGridViewCellEventArgs(0, row.Index));
                    return;
                }
            }

            ClearForm();
        }

        private void ClearForm()
        {
            loadingForm = true;

            selectedStaffId = 0;
            selectedDbRole = null;

            txtName.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cmbGender.SelectedIndex = -1;
            cmbRole.SelectedIndex = 0;

            loadingForm = false;

            DGV_Staff.ClearSelection();

            labelFormTitle.Text = "موظف جديد";
            lblFormHint.Text = "املأ الحقول ثم اضغط تسجيل.";
            txtPassword.PlaceholderText = "8 أحرف على الأقل";
            btnSave.Text = "تسجيل";
            btnDelete.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtName.Focus();
        }

        // ------------------------------------------------------------------
        // Save (insert / update)
        // ------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (loadingForm)
                return;

            if (!ValidateInput(out string gender, out string role))
                return;

            if (UserNameExists(txtUserName.Text.Trim(), selectedStaffId))
            {
                Fail("اسم المستخدم مستخدم بالفعل.", txtUserName);
                return;
            }

            if (selectedStaffId == 0)
                InsertStaff(gender, role);
            else
                UpdateStaff(gender, role);
        }

        private void InsertStaff(string gender, string role)
        {
            const string query = @"
                INSERT INTO Staff
                    (Staff_Name, Staff_Mobile, Staff_Gender, Staff_Email, Staff_UserName, Staff_Password, Staff_Role)
                VALUES
                    (@name, @mobile, @gender, @email, @userName, @password, @role)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.VarChar, 75) { Value = txtName.Text.Trim() },
                new SqlParameter("@mobile", SqlDbType.VarChar, 25) { Value = txtMobile.Text.Trim() },
                new SqlParameter("@gender", SqlDbType.VarChar, 50) { Value = gender },
                new SqlParameter("@email", SqlDbType.VarChar, 120) { Value = txtEmail.Text.Trim() },
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = txtUserName.Text.Trim() },
                new SqlParameter("@password", SqlDbType.VarChar, 150) { Value = PasswordHasher.Hash(txtPassword.Text) },
                new SqlParameter("@role", SqlDbType.VarChar, 20) { Value = role }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("تم تسجيل الموظف.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStaff();
                ClearForm();
            }
            else
            {
                MessageBox.Show("لم تتم إضافة أي سجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateStaff(string gender, string role)
        {
            const string query = @"
                UPDATE Staff
                SET Staff_Name = @name,
                    Staff_Mobile = @mobile,
                    Staff_Gender = @gender,
                    Staff_Email = @email,
                    Staff_UserName = @userName,
                    Staff_Role = @role
                WHERE Staff_ID = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", SqlDbType.VarChar, 75) { Value = txtName.Text.Trim() },
                new SqlParameter("@mobile", SqlDbType.VarChar, 25) { Value = txtMobile.Text.Trim() },
                new SqlParameter("@gender", SqlDbType.VarChar, 50) { Value = gender },
                new SqlParameter("@email", SqlDbType.VarChar, 120) { Value = txtEmail.Text.Trim() },
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = txtUserName.Text.Trim() },
                new SqlParameter("@role", SqlDbType.VarChar, 20) { Value = role },
                new SqlParameter("@id", SqlDbType.Int) { Value = selectedStaffId }
            };

            int affected = fn.setData(query, parameters);

            if (affected <= 0)
            {
                MessageBox.Show("لم يتم تحديث أي سجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string password = txtPassword.Text;

            if (password.Length > 0 &&
                !fn.ResetStaffPassword(selectedStaffId, password, out string error))
            {
                MessageBox.Show(LocalizeResetPasswordError(error) ??
                                    "تعذّر تحديث كلمة المرور.",
                                "فشل",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("تم تحديث بيانات الموظف.", "نجاح",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadStaff();
            SelectRowById(selectedStaffId);
        }

        // ------------------------------------------------------------------
        // Delete
        // ------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffId <= 0)
            {
                MessageBox.Show("اختر موظفاً من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedDbRole == "Admin")
            {
                DataTable otherAdmins = fn.getData(
                    "SELECT COUNT(*) AS AdminCount FROM Staff WHERE Staff_Role = 'Admin' AND Staff_ID <> @id",
                    new SqlParameter("@id", SqlDbType.Int) { Value = selectedStaffId });

                int adminCount = otherAdmins.Rows.Count == 0
                    ? 0
                    : Convert.ToInt32(otherAdmins.Rows[0]["AdminCount"]);

                if (adminCount == 0)
                {
                    MessageBox.Show("لا يمكن حذف آخر حساب مدير.", "غير مسموح",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string question = "هل أنت متأكد من حذف الموظف " + txtName.Text.Trim() + "؟";

            if (MessageBox.Show(question, "تأكيد",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            int affected = fn.setData(
                "DELETE FROM Staff WHERE Staff_ID = @id",
                new SqlParameter("@id", SqlDbType.Int) { Value = selectedStaffId });

            if (affected > 0)
            {
                MessageBox.Show("تم حذف الموظف.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStaff();
                ClearForm();
            }
            else
            {
                MessageBox.Show("لم يتم حذف أي سجل.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ------------------------------------------------------------------
        // Validation helpers
        // ------------------------------------------------------------------
        private bool ValidateInput(out string gender, out string role)
        {
            gender = Localization.GenderToDatabase(cmbGender.Text);
            role = Localization.RoleToDatabase(cmbRole.Text);

            string name = (txtName.Text ?? string.Empty).Trim();

            if (name.Length == 0)
                return Fail("اسم الموظف مطلوب.", txtName);

            if (name.Length < 2)
                return Fail("اسم الموظف يجب أن يكون حرفين على الأقل.", txtName);

            if (name.Length > 75)
                return Fail("اسم الموظف لا يتجاوز 75 حرفاً.", txtName);

            string mobile = (txtMobile.Text ?? string.Empty).Trim();

            if (!Validation.IsValidMobile(mobile))
                return Fail("أدخل رقم جوال صحيحاً (7-15 رقماً).", txtMobile);

            if (cmbGender.SelectedIndex < 0)
                return Fail("اختر الجنس.", cmbGender);

            string email = (txtEmail.Text ?? string.Empty).Trim();

            if (!Validation.IsValidEmail(email))
                return Fail("أدخل بريداً إلكترونياً صحيحاً.", txtEmail);

            if (email.Length > 120)
                return Fail("البريد الإلكتروني لا يتجاوز 120 حرفاً.", txtEmail);

            string userName = (txtUserName.Text ?? string.Empty).Trim();

            if (!Validation.IsValidUserName(userName))
                return Fail("اسم المستخدم من 3 إلى 150 حرفاً (حروف، أرقام، نقطة، شرطة سفلية، شرطة).", txtUserName);

            string password = txtPassword.Text ?? string.Empty;
            bool passwordRequired = selectedStaffId == 0;

            if (passwordRequired || password.Length > 0)
            {
                if (!Validation.IsValidPassword(password))
                    return Fail("كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم.", txtPassword);

                if (password.Length > 128)
                    return Fail("كلمة المرور لا تتجاوز 128 حرفاً.", txtPassword);
            }

            if (role != "Admin" && role != "Staff")
                return Fail("اختر الصلاحية.", cmbRole);

            return true;
        }

        private bool UserNameExists(string userName, int excludeId)
        {
            const string query = @"
                SELECT Staff_ID
                FROM Staff
                WHERE Staff_UserName = @userName
                  AND Staff_ID <> @id";

            DataTable table = fn.getData(query,
                new SqlParameter("@userName", SqlDbType.VarChar, 150) { Value = userName },
                new SqlParameter("@id", SqlDbType.Int) { Value = excludeId });

            return table.Rows.Count > 0;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "تحقق",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        private static string LocalizeResetPasswordError(string error)
        {
            if (string.IsNullOrEmpty(error))
                return null;

            if (error == "Select a staff member.")
                return "اختر موظفاً.";
            if (error == "Password must be at least 8 characters and contain a letter and a digit.")
                return "كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم.";
            if (error == "Password cannot exceed 128 characters.")
                return "كلمة المرور لا تتجاوز 128 حرفاً.";
            if (error == "Staff member not found.")
                return "الموظف غير موجود.";
            if (error == "A database error occurred. Please try again.")
                return "حدث خطأ في قاعدة البيانات. يرجى المحاولة مرة أخرى.";

            return error;
        }

        // ------------------------------------------------------------------
        // Theme
        // ------------------------------------------------------------------
        private void ApplyTheme()
        {
            Theme.StyleScreenTitle(labelTitle);
            Theme.StyleScreenSubtitle(labelSubtitle);

            Theme.StyleInput(txtSearch);
            Theme.StyleCombo(cmbRoleFilter);
            Theme.StyleActionButton(btnRefresh, true);

            Theme.StyleInput(txtName);
            Theme.StyleInput(txtMobile);
            Theme.StyleInput(txtEmail);
            Theme.StyleInput(txtUserName);
            Theme.StyleInput(txtPassword);
            Theme.StyleCombo(cmbGender);
            Theme.StyleCombo(cmbRole);

            Theme.StyleActionButton(btnSave, true);
            Theme.StyleDangerButton(btnDelete);

            btnNew.BorderRadius = 10;
            btnNew.FillColor = Color.FromArgb(241, 245, 249);
            btnNew.ForeColor = Theme.TextPrimary;
            btnNew.Font = new Font("Segoe UI", 10F);
            btnNew.HoverState.FillColor = Theme.Border;

            lblGridTitle.ForeColor = Theme.TextPrimary;
            lblCount.ForeColor = Theme.TextMuted;
            labelFormTitle.ForeColor = Theme.TextPrimary;
            lblFormHint.ForeColor = Theme.TextMuted;

            Theme.AlignFieldLabels(this);
        }
    }
}
