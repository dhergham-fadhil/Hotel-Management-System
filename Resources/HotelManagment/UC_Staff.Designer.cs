namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Staff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbRoleFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.DGV_Staff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelMobile = new System.Windows.Forms.Label();
            this.txtMobile = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.lblFormHint = new System.Windows.Forms.Label();

            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Staff)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.labelTitle.Location = new System.Drawing.Point(24, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(120, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "الموظفون";

            //
            // labelSubtitle
            //
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelSubtitle.Location = new System.Drawing.Point(26, 56);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(220, 19);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "إدارة حسابات الموظفين والصلاحيات";

            //
            // txtSearch
            //
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtSearch.Location = new System.Drawing.Point(420, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "ابحث بالاسم أو المستخدم أو الجوال...";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 2;

            //
            // cmbRoleFilter
            //
            this.cmbRoleFilter.BackColor = System.Drawing.Color.Transparent;
            this.cmbRoleFilter.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cmbRoleFilter.BorderRadius = 10;
            this.cmbRoleFilter.FillColor = System.Drawing.Color.White;
            this.cmbRoleFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRoleFilter.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbRoleFilter.Location = new System.Drawing.Point(732, 22);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(164, 40);
            this.cmbRoleFilter.TabIndex = 3;

            //
            // btnRefresh
            //
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1060, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "تحديث";

            //
            // pnlGrid
            //
            this.pnlGrid.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlGrid.BorderRadius = 14;
            this.pnlGrid.BorderThickness = 1;
            this.pnlGrid.Controls.Add(this.DGV_Staff);
            this.pnlGrid.Controls.Add(this.lblCount);
            this.pnlGrid.Controls.Add(this.lblGridTitle);
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(16, 92);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(776, 576);
            this.pnlGrid.TabIndex = 5;

            //
            // lblGridTitle
            //
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridTitle.Location = new System.Drawing.Point(20, 14);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(140, 21);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "قائمة الموظفين";

            //
            // lblCount
            //
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(20, 40);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(120, 15);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "عدد الموظفين: 0";

            //
            // DGV_Staff
            //
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.DGV_Staff.AlternatingRowsDefaultCellStyle = alternatingStyle;
            this.DGV_Staff.AllowUserToAddRows = false;
            this.DGV_Staff.AllowUserToDeleteRows = false;
            this.DGV_Staff.AllowUserToResizeRows = false;
            this.DGV_Staff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Staff.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Staff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Staff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            headerStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Staff.ColumnHeadersDefaultCellStyle = headerStyle;
            this.DGV_Staff.ColumnHeadersHeight = 38;
            this.DGV_Staff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Staff.DefaultCellStyle = rowStyle;
            this.DGV_Staff.EnableHeadersVisualStyles = false;
            this.DGV_Staff.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.DGV_Staff.Location = new System.Drawing.Point(12, 66);
            this.DGV_Staff.MultiSelect = false;
            this.DGV_Staff.Name = "DGV_Staff";
            this.DGV_Staff.ReadOnly = true;
            this.DGV_Staff.RowHeadersVisible = false;
            this.DGV_Staff.RowHeadersWidth = 51;
            this.DGV_Staff.RowTemplate.Height = 38;
            this.DGV_Staff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Staff.Size = new System.Drawing.Size(752, 498);
            this.DGV_Staff.TabIndex = 2;
            this.DGV_Staff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.DGV_Staff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Staff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV_Staff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV_Staff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV_Staff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Staff.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.DGV_Staff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.DGV_Staff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Staff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DGV_Staff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.DGV_Staff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Staff.ThemeStyle.HeaderStyle.Height = 38;
            this.DGV_Staff.ThemeStyle.ReadOnly = true;
            this.DGV_Staff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Staff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Staff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DGV_Staff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.DGV_Staff.ThemeStyle.RowsStyle.Height = 38;
            this.DGV_Staff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.DGV_Staff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);

            //
            // pnlForm
            //
            this.pnlForm.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlForm.BorderRadius = 14;
            this.pnlForm.BorderThickness = 1;
            this.pnlForm.Controls.Add(this.lblFormHint);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnNew);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.cmbRole);
            this.pnlForm.Controls.Add(this.labelRole);
            this.pnlForm.Controls.Add(this.cmbGender);
            this.pnlForm.Controls.Add(this.labelGender);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.labelPassword);
            this.pnlForm.Controls.Add(this.txtUserName);
            this.pnlForm.Controls.Add(this.labelUserName);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.labelEmail);
            this.pnlForm.Controls.Add(this.txtMobile);
            this.pnlForm.Controls.Add(this.labelMobile);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.labelName);
            this.pnlForm.Controls.Add(this.labelFormTitle);
            this.pnlForm.FillColor = System.Drawing.Color.White;
            this.pnlForm.Location = new System.Drawing.Point(804, 92);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(372, 576);
            this.pnlForm.TabIndex = 6;

            //
            // labelFormTitle
            //
            this.labelFormTitle.AutoSize = true;
            this.labelFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelFormTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.labelFormTitle.Location = new System.Drawing.Point(20, 14);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(140, 21);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "موظف جديد";

            //
            // labelName
            //
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelName.Location = new System.Drawing.Point(20, 46);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(40, 17);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "الاسم";

            //
            // txtName
            //
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtName.BorderRadius = 8;
            this.txtName.FillColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtName.Location = new System.Drawing.Point(20, 68);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "الاسم الكامل";
            this.txtName.Size = new System.Drawing.Size(332, 38);
            this.txtName.TabIndex = 2;

            //
            // labelMobile
            //
            this.labelMobile.AutoSize = true;
            this.labelMobile.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelMobile.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelMobile.Location = new System.Drawing.Point(20, 114);
            this.labelMobile.Name = "labelMobile";
            this.labelMobile.Size = new System.Drawing.Size(70, 17);
            this.labelMobile.TabIndex = 3;
            this.labelMobile.Text = "رقم الجوال";

            //
            // txtMobile
            //
            this.txtMobile.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtMobile.BorderRadius = 8;
            this.txtMobile.FillColor = System.Drawing.Color.White;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMobile.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtMobile.Location = new System.Drawing.Point(20, 136);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.PlaceholderText = "7-15 رقماً";
            this.txtMobile.Size = new System.Drawing.Size(332, 38);
            this.txtMobile.TabIndex = 4;

            //
            // labelEmail
            //
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelEmail.Location = new System.Drawing.Point(20, 182);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(90, 17);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "البريد الإلكتروني";

            //
            // txtEmail
            //
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.FillColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtEmail.Location = new System.Drawing.Point(20, 204);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "name@example.com";
            this.txtEmail.Size = new System.Drawing.Size(332, 38);
            this.txtEmail.TabIndex = 6;

            //
            // labelUserName
            //
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelUserName.Location = new System.Drawing.Point(20, 250);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(80, 17);
            this.labelUserName.TabIndex = 7;
            this.labelUserName.Text = "اسم المستخدم";

            //
            // txtUserName
            //
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtUserName.BorderRadius = 8;
            this.txtUserName.FillColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUserName.Location = new System.Drawing.Point(20, 272);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "حروف وأرقام ونقطة";
            this.txtUserName.Size = new System.Drawing.Size(332, 38);
            this.txtUserName.TabIndex = 8;

            //
            // labelPassword
            //
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelPassword.Location = new System.Drawing.Point(20, 318);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(80, 17);
            this.labelPassword.TabIndex = 9;
            this.labelPassword.Text = "كلمة المرور";

            //
            // txtPassword
            //
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPassword.Location = new System.Drawing.Point(20, 340);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "8 أحرف على الأقل";
            this.txtPassword.Size = new System.Drawing.Size(332, 38);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;

            //
            // labelGender
            //
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelGender.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelGender.Location = new System.Drawing.Point(20, 386);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(40, 17);
            this.labelGender.TabIndex = 11;
            this.labelGender.Text = "الجنس";

            //
            // cmbGender
            //
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cmbGender.BorderRadius = 8;
            this.cmbGender.FillColor = System.Drawing.Color.White;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbGender.Location = new System.Drawing.Point(20, 408);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(156, 36);
            this.cmbGender.TabIndex = 12;

            //
            // labelRole
            //
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelRole.Location = new System.Drawing.Point(176, 386);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(50, 17);
            this.labelRole.TabIndex = 13;
            this.labelRole.Text = "الصلاحية";

            //
            // cmbRole
            //
            this.cmbRole.BackColor = System.Drawing.Color.Transparent;
            this.cmbRole.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cmbRole.BorderRadius = 8;
            this.cmbRole.FillColor = System.Drawing.Color.White;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRole.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cmbRole.Location = new System.Drawing.Point(176, 408);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(156, 36);
            this.cmbRole.TabIndex = 14;

            //
            // btnSave
            //
            this.btnSave.BorderRadius = 10;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "تسجيل";

            //
            // btnNew
            //
            this.btnNew.BorderRadius = 10;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FillColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.btnNew.Location = new System.Drawing.Point(176, 456);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(156, 40);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "جديد";

            //
            // btnDelete
            //
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 506);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(332, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "حذف الموظف المحدد";

            //
            // lblFormHint
            //
            this.lblFormHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFormHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFormHint.Location = new System.Drawing.Point(20, 550);
            this.lblFormHint.Name = "lblFormHint";
            this.lblFormHint.Size = new System.Drawing.Size(332, 18);
            this.lblFormHint.TabIndex = 18;
            this.lblFormHint.Text = "املأ الحقول ثم اضغط تسجيل.";

            //
            // UC_Staff
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 246, 249);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbRoleFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "UC_Staff";
            this.Size = new System.Drawing.Size(1200, 688);
            this.Load += new System.EventHandler(this.UC_Staff_Load);

            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Staff)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRoleFilter;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Label lblCount;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Staff;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Label labelName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label labelMobile;
        private Guna.UI2.WinForms.Guna2TextBox txtMobile;
        private System.Windows.Forms.Label labelEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label labelUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private System.Windows.Forms.Label labelPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label labelGender;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private System.Windows.Forms.Label labelRole;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRole;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private System.Windows.Forms.Label lblFormHint;
    }
}
