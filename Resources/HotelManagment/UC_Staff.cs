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
    public partial class UC_Staff : UserControl, ILocalizable
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
            ApplyLanguage();

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
                        Localization.GenderDisplay(dbGender),
                        Convert.ToString(row["Staff_Email"]),
                        Convert.ToString(row["Staff_UserName"]),
                        Localization.RoleDisplay(dbRole),
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
                MessageBox.Show(Language.T("تعذّر تحميل بيانات الموظفين.", "Could not load the staff list."),
                    Language.T("خطأ", "Error"),
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

            SetHeader("Name", Language.T("الاسم", "Name"), 130);
            SetHeader("Mobile", Language.T("رقم الجوال", "Mobile"), 100);
            SetHeader("Gender", Language.T("الجنس", "Gender"), 60);
            SetHeader("Email", Language.T("البريد الإلكتروني", "Email"), 170);
            SetHeader("UserName", Language.T("اسم المستخدم", "User name"), 120);
            SetHeader("Role", Language.T("الصلاحية", "Role"), 70);
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
                role = Localization.RoleDisplay("Admin");
            else if (cmbRoleFilter.SelectedIndex == 2)
                role = Localization.RoleDisplay("Staff");

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
            lblCount.Text = Language.T("عدد الموظفين: ", "Staff count: ") + view.Count;
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

            labelFormTitle.Text = Language.T("تعديل بيانات الموظف", "Edit staff member");
            lblFormHint.Text = Language.T("اترك كلمة المرور فارغة للإبقاء على الكلمة الحالية.",
                "Leave the password empty to keep the current one.");
            txtPassword.PlaceholderText = Language.T("اتركها فارغة لعدم التغيير", "Leave empty to keep it");
            btnSave.Text = Language.T("حفظ التعديلات", "Save changes");
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

            labelFormTitle.Text = Language.T("موظف جديد", "New staff member");
            lblFormHint.Text = Language.T("املأ الحقول ثم اضغط تسجيل.", "Fill the fields and press save.");
            txtPassword.PlaceholderText = Language.T("8 أحرف على الأقل", "At least 8 characters");
            btnSave.Text = Language.T("تسجيل", "Save");
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
                Fail(Language.T("اسم المستخدم مستخدم بالفعل.", "This user name is already in use."), txtUserName);
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
                MessageBox.Show(Language.T("تم تسجيل الموظف.", "Staff member added."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStaff();
                ClearForm();
            }
            else
            {
                MessageBox.Show(Language.T("لم تتم إضافة أي سجل.", "No record was added."),
                    Language.T("تنبيه", "Notice"),
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
                MessageBox.Show(Language.T("لم يتم تحديث أي سجل.", "No record was updated."),
                    Language.T("تنبيه", "Notice"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string password = txtPassword.Text;

            if (password.Length > 0 &&
                !fn.ResetStaffPassword(selectedStaffId, password, out string error))
            {
                MessageBox.Show(LocalizeResetPasswordError(error) ??
                                    Language.T("تعذّر تحديث كلمة المرور.", "Could not update the password."),
                                Language.T("فشل", "Failed"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(Language.T("تم تحديث بيانات الموظف.", "Staff member updated."),
                Language.T("نجاح", "Success"),
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
                MessageBox.Show(Language.T("اختر موظفاً من الجدول أولاً.",
                        "Select a staff member from the grid first."),
                    Language.T("تنبيه", "Notice"),
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
                    MessageBox.Show(Language.T("لا يمكن حذف آخر حساب مدير.",
                            "The last admin account cannot be deleted."),
                        Language.T("غير مسموح", "Not allowed"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string question = Language.T("هل أنت متأكد من حذف الموظف ",
                               "Are you sure you want to delete ") +
                             txtName.Text.Trim() + "؟";

            if (MessageBox.Show(question, Language.T("تأكيد", "Confirm"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            int affected = fn.setData(
                "DELETE FROM Staff WHERE Staff_ID = @id",
                new SqlParameter("@id", SqlDbType.Int) { Value = selectedStaffId });

            if (affected > 0)
            {
                MessageBox.Show(Language.T("تم حذف الموظف.", "Staff member deleted."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStaff();
                ClearForm();
            }
            else
            {
                MessageBox.Show(Language.T("لم يتم حذف أي سجل.", "No record was deleted."),
                    Language.T("تنبيه", "Notice"),
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
                return Fail(Language.T("اسم الموظف مطلوب.", "Staff name is required."), txtName);

            if (name.Length < 2)
                return Fail(Language.T("اسم الموظف يجب أن يكون حرفين على الأقل.",
                                       "Staff name must be at least two characters."), txtName);

            if (name.Length > 75)
                return Fail(Language.T("اسم الموظف لا يتجاوز 75 حرفاً.",
                                       "Staff name cannot exceed 75 characters."), txtName);

            string mobile = (txtMobile.Text ?? string.Empty).Trim();

            if (!Validation.IsValidMobile(mobile))
                return Fail(Language.T("أدخل رقم جوال صحيحاً (7-15 رقماً).",
                                       "Enter a valid mobile number (7-15 digits)."), txtMobile);

            if (cmbGender.SelectedIndex < 0)
                return Fail(Language.T("اختر الجنس.", "Select the gender."), cmbGender);

            string email = (txtEmail.Text ?? string.Empty).Trim();

            if (!Validation.IsValidEmail(email))
                return Fail(Language.T("أدخل بريداً إلكترونياً صحيحاً.",
                                       "Enter a valid email address."), txtEmail);

            if (email.Length > 120)
                return Fail(Language.T("البريد الإلكتروني لا يتجاوز 120 حرفاً.",
                                       "Email cannot exceed 120 characters."), txtEmail);

            string userName = (txtUserName.Text ?? string.Empty).Trim();

            if (!Validation.IsValidUserName(userName))
                return Fail(Language.T(
                    "اسم المستخدم من 3 إلى 150 حرفاً (حروف، أرقام، نقطة، شرطة سفلية، شرطة).",
                    "User name must be 3-150 characters (letters, digits, dot, underscore, dash)."),
                    txtUserName);

            string password = txtPassword.Text ?? string.Empty;
            bool passwordRequired = selectedStaffId == 0;

            if (passwordRequired || password.Length > 0)
            {
                if (!Validation.IsValidPassword(password))
                    return Fail(Language.T(
                        "كلمة المرور 8 أحرف على الأقل وتحتوي على حرف ورقم.",
                        "Password must be at least 8 characters and contain a letter and a digit."),
                        txtPassword);

                if (password.Length > 128)
                    return Fail(Language.T("كلمة المرور لا تتجاوز 128 حرفاً.",
                                           "Password cannot exceed 128 characters."), txtPassword);
            }

            if (role != "Admin" && role != "Staff")
                return Fail(Language.T("اختر الصلاحية.", "Select the role."), cmbRole);

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
            MessageBox.Show(message, Language.T("تحقق", "Validation"),
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        private static string LocalizeResetPasswordError(string error)
        {
            if (string.IsNullOrEmpty(error) || !Language.IsArabic)
                return error;

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
        // Language
        // ------------------------------------------------------------------
        public void ApplyLanguage()
        {
            labelTitle.Text = Language.T("الموظفون", "Staff");
            labelSubtitle.Text = Language.T("إدارة حسابات الموظفين والصلاحيات",
                                            "Manage staff accounts and roles");
            lblGridTitle.Text = Language.T("قائمة الموظفين", "Staff list");

            btnRefresh.Text = Language.T("تحديث", "Refresh");
            btnNew.Text = Language.T("جديد", "New");
            btnDelete.Text = Language.T("حذف الموظف المحدد", "Delete selected staff");

            labelName.Text = Language.T("الاسم", "Name");
            labelMobile.Text = Language.T("رقم الجوال", "Mobile");
            labelEmail.Text = Language.T("البريد الإلكتروني", "Email");
            labelUserName.Text = Language.T("اسم المستخدم", "User name");
            labelPassword.Text = Language.T("كلمة المرور", "Password");
            labelGender.Text = Language.T("الجنس", "Gender");
            labelRole.Text = Language.T("الصلاحية", "Role");

            txtSearch.PlaceholderText = Language.T("ابحث بالاسم أو المستخدم أو الجوال...",
                                                    "Search by name, user name or mobile...");
            txtName.PlaceholderText = Language.T("الاسم الكامل", "Full name");
            txtMobile.PlaceholderText = Language.T("7-15 رقماً", "7-15 digits");
            txtEmail.PlaceholderText = "name@example.com";
            txtUserName.PlaceholderText = Language.T("حروف وأرقام ونقطة",
                                                      "Letters, digits and dot");

            SetComboItems(cmbGender, Localization.GenderItems());
            SetComboItems(cmbRole, Localization.RoleItems());
            SetComboItems(cmbRoleFilter, BuildRoleFilterItems());

            if (cmbRoleFilter.SelectedIndex < 0)
                cmbRoleFilter.SelectedIndex = 0;

            // The grid stores the displayed gender and role, so refresh those
            // columns to match the selected language.
            if (staffTable != null)
            {
                foreach (DataRow row in staffTable.Rows)
                {
                    row["Gender"] = Localization.GenderDisplay(Convert.ToString(row["DbGender"]));
                    row["Role"] = Localization.RoleDisplay(Convert.ToString(row["DbRole"]));
                }
            }

            ConfigureGrid();
            ApplyFilter();

            if (selectedStaffId > 0)
            {
                // Keep the selected row in sync with the new language.
                foreach (DataGridViewRow row in DGV_Staff.Rows)
                {
                    object value = row.Cells["ID"].Value;

                    if (value == null || value == DBNull.Value ||
                        Convert.ToInt32(value) != selectedStaffId)
                    {
                        continue;
                    }

                    loadingForm = true;
                    cmbGender.SelectedItem = Convert.ToString(row.Cells["Gender"].Value);
                    cmbRole.SelectedItem = Convert.ToString(row.Cells["Role"].Value);
                    loadingForm = false;
                    break;
                }

                labelFormTitle.Text = Language.T("تعديل بيانات الموظف", "Edit staff member");
                lblFormHint.Text = Language.T(
                    "اترك كلمة المرور فارغة للإبقاء على الكلمة الحالية.",
                    "Leave the password empty to keep the current one.");
                txtPassword.PlaceholderText = Language.T(
                    "اتركها فارغة لعدم التغيير", "Leave empty to keep it");
                btnSave.Text = Language.T("حفظ التعديلات", "Save changes");
            }
            else
            {
                labelFormTitle.Text = Language.T("موظف جديد", "New staff member");
                lblFormHint.Text = Language.T("املأ الحقول ثم اضغط تسجيل.",
                                               "Fill the fields and press save.");
                txtPassword.PlaceholderText = Language.T("8 أحرف على الأقل",
                                                          "At least 8 characters");
                btnSave.Text = Language.T("تسجيل", "Save");
            }
        }

        private static string[] BuildRoleFilterItems()
        {
            return new[]
            {
                Language.T("كل الصلاحيات", "All roles"),
                Localization.RoleDisplay("Admin"),
                Localization.RoleDisplay("Staff")
            };
        }

        private static void SetComboItems(Guna2ComboBox combo, string[] items)
        {
            int index = combo.SelectedIndex;

            combo.Items.Clear();
            combo.Items.AddRange(items);

            if (index >= 0 && index < combo.Items.Count)
                combo.SelectedIndex = index;
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
