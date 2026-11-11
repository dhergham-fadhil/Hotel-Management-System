namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Customers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.cmBoxRoomNo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboxBed = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmBoxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDProof = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNationality = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMobileNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.allotebtn = new Guna.UI2.WinForms.Guna2Button();
            this.cmBoxGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DTP_DateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DTP_CheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.SuspendLayout();
            // 
            // cmBoxRoomNo
            // 
            this.cmBoxRoomNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxRoomNo.BorderColor = System.Drawing.Color.DarkGray;
            this.cmBoxRoomNo.BorderRadius = 10;
            this.cmBoxRoomNo.BorderThickness = 3;
            this.cmBoxRoomNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmBoxRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxRoomNo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxRoomNo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomNo.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cmBoxRoomNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmBoxRoomNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomNo.ItemHeight = 30;
            this.cmBoxRoomNo.Location = new System.Drawing.Point(851, 261);
            this.cmBoxRoomNo.Name = "cmBoxRoomNo";
            this.cmBoxRoomNo.Size = new System.Drawing.Size(316, 36);
            this.cmBoxRoomNo.TabIndex = 31;
            this.cmBoxRoomNo.SelectedIndexChanged += new System.EventHandler(this.cmBoxRoomNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(851, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "Room Type";
            // 
            // cmboxBed
            // 
            this.cmboxBed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmboxBed.BorderColor = System.Drawing.Color.DarkGray;
            this.cmboxBed.BorderRadius = 10;
            this.cmboxBed.BorderThickness = 3;
            this.cmboxBed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboxBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxBed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmboxBed.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmboxBed.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmboxBed.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cmboxBed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmboxBed.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmboxBed.ItemHeight = 30;
            this.cmboxBed.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Queen",
            "King",
            "Twin",
            "Bunk"});
            this.cmboxBed.Location = new System.Drawing.Point(851, 71);
            this.cmboxBed.Name = "cmboxBed";
            this.cmboxBed.Size = new System.Drawing.Size(316, 36);
            this.cmboxBed.TabIndex = 29;
            this.cmboxBed.SelectedIndexChanged += new System.EventHandler(this.cmboxBed_SelectedIndexChanged);
            // 
            // cmBoxRoomType
            // 
            this.cmBoxRoomType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxRoomType.BorderColor = System.Drawing.Color.DarkGray;
            this.cmBoxRoomType.BorderRadius = 10;
            this.cmBoxRoomType.BorderThickness = 3;
            this.cmBoxRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmBoxRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxRoomType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxRoomType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomType.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cmBoxRoomType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmBoxRoomType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxRoomType.ItemHeight = 30;
            this.cmBoxRoomType.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Twin",
            "Triple",
            "Suit"});
            this.cmBoxRoomType.Location = new System.Drawing.Point(851, 167);
            this.cmBoxRoomType.Name = "cmBoxRoomType";
            this.cmBoxRoomType.Size = new System.Drawing.Size(316, 36);
            this.cmBoxRoomType.TabIndex = 28;
            this.cmBoxRoomType.SelectedIndexChanged += new System.EventHandler(this.cmBoxRoomType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(410, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 27;
            this.label7.Text = "ID Proof";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(851, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Room No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(410, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Animated = true;
            this.txtAddress.BorderColor = System.Drawing.Color.DarkGray;
            this.txtAddress.BorderRadius = 10;
            this.txtAddress.BorderThickness = 3;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtAddress.Location = new System.Drawing.Point(410, 166);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(316, 44);
            this.txtAddress.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Animated = true;
            this.txtName.BorderColor = System.Drawing.Color.DarkGray;
            this.txtName.BorderRadius = 10;
            this.txtName.BorderThickness = 3;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtName.Location = new System.Drawing.Point(16, 71);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(317, 43);
            this.txtName.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(851, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "Bed";
            // 
            // txtIDProof
            // 
            this.txtIDProof.Animated = true;
            this.txtIDProof.BorderColor = System.Drawing.Color.DarkGray;
            this.txtIDProof.BorderRadius = 10;
            this.txtIDProof.BorderThickness = 3;
            this.txtIDProof.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDProof.DefaultText = "";
            this.txtIDProof.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDProof.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDProof.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDProof.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDProof.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtIDProof.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtIDProof.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProof.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtIDProof.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtIDProof.Location = new System.Drawing.Point(410, 71);
            this.txtIDProof.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDProof.Name = "txtIDProof";
            this.txtIDProof.PlaceholderText = "";
            this.txtIDProof.SelectedText = "";
            this.txtIDProof.Size = new System.Drawing.Size(317, 43);
            this.txtIDProof.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 35;
            this.label4.Text = "Gender";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 21);
            this.label8.TabIndex = 37;
            this.label8.Text = "Nationality";
            // 
            // txtNationality
            // 
            this.txtNationality.Animated = true;
            this.txtNationality.BorderColor = System.Drawing.Color.DarkGray;
            this.txtNationality.BorderRadius = 10;
            this.txtNationality.BorderThickness = 3;
            this.txtNationality.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationality.DefaultText = "";
            this.txtNationality.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNationality.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNationality.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationality.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationality.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtNationality.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtNationality.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationality.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNationality.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtNationality.Location = new System.Drawing.Point(16, 261);
            this.txtNationality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.PlaceholderText = "";
            this.txtNationality.SelectedText = "";
            this.txtNationality.Size = new System.Drawing.Size(317, 43);
            this.txtNationality.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 21);
            this.label9.TabIndex = 39;
            this.label9.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Animated = true;
            this.txtMobileNo.BorderColor = System.Drawing.Color.DarkGray;
            this.txtMobileNo.BorderRadius = 10;
            this.txtMobileNo.BorderThickness = 3;
            this.txtMobileNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMobileNo.DefaultText = "";
            this.txtMobileNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMobileNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMobileNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMobileNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMobileNo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtMobileNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtMobileNo.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMobileNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtMobileNo.Location = new System.Drawing.Point(16, 167);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.PlaceholderText = "";
            this.txtMobileNo.SelectedText = "";
            this.txtMobileNo.Size = new System.Drawing.Size(317, 43);
            this.txtMobileNo.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(851, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 21);
            this.label10.TabIndex = 41;
            this.label10.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Animated = true;
            this.txtPrice.BorderColor = System.Drawing.Color.DarkGray;
            this.txtPrice.BorderRadius = 10;
            this.txtPrice.BorderThickness = 3;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.txtPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtPrice.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtPrice.Location = new System.Drawing.Point(851, 354);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.SelectedText = "";
            this.txtPrice.Size = new System.Drawing.Size(316, 44);
            this.txtPrice.TabIndex = 40;
            // 
            // allotebtn
            // 
            this.allotebtn.BorderRadius = 23;
            this.allotebtn.BorderThickness = 1;
            this.allotebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.allotebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.allotebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.allotebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.allotebtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.allotebtn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allotebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.allotebtn.Location = new System.Drawing.Point(995, 440);
            this.allotebtn.Name = "allotebtn";
            this.allotebtn.Size = new System.Drawing.Size(156, 54);
            this.allotebtn.TabIndex = 42;
            this.allotebtn.Text = "Allote Room";
            this.allotebtn.Click += new System.EventHandler(this.allotebtn_Click);
            // 
            // cmBoxGender
            // 
            this.cmBoxGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxGender.BorderColor = System.Drawing.Color.DarkGray;
            this.cmBoxGender.BorderRadius = 10;
            this.cmBoxGender.BorderThickness = 3;
            this.cmBoxGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxGender.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.cmBoxGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxGender.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cmBoxGender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmBoxGender.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.cmBoxGender.ItemHeight = 30;
            this.cmBoxGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other",
            "I Rather Do Not Answer",
            ""});
            this.cmBoxGender.Location = new System.Drawing.Point(16, 354);
            this.cmBoxGender.Name = "cmBoxGender";
            this.cmBoxGender.Size = new System.Drawing.Size(316, 36);
            this.cmBoxGender.TabIndex = 43;
            // 
            // DTP_DateOfBirth
            // 
            this.DTP_DateOfBirth.Checked = true;
            this.DTP_DateOfBirth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.DTP_DateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTP_DateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.DTP_DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DTP_DateOfBirth.Location = new System.Drawing.Point(16, 450);
            this.DTP_DateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTP_DateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTP_DateOfBirth.Name = "DTP_DateOfBirth";
            this.DTP_DateOfBirth.Size = new System.Drawing.Size(238, 44);
            this.DTP_DateOfBirth.TabIndex = 44;
            this.DTP_DateOfBirth.Value = new System.DateTime(2025, 9, 7, 20, 43, 15, 455);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 21);
            this.label11.TabIndex = 45;
            this.label11.Text = "Date Of Birth";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(410, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 21);
            this.label12.TabIndex = 47;
            this.label12.Text = "Check In";
            // 
            // DTP_CheckIn
            // 
            this.DTP_CheckIn.Checked = true;
            this.DTP_CheckIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.DTP_CheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTP_CheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.DTP_CheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DTP_CheckIn.Location = new System.Drawing.Point(410, 261);
            this.DTP_CheckIn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTP_CheckIn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTP_CheckIn.Name = "DTP_CheckIn";
            this.DTP_CheckIn.Size = new System.Drawing.Size(238, 44);
            this.DTP_CheckIn.TabIndex = 46;
            this.DTP_CheckIn.Value = new System.DateTime(2025, 9, 7, 20, 43, 15, 455);
            // 
            // UC_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DTP_CheckIn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DTP_DateOfBirth);
            this.Controls.Add(this.cmBoxGender);
            this.Controls.Add(this.allotebtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIDProof);
            this.Controls.Add(this.cmBoxRoomNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboxBed);
            this.Controls.Add(this.cmBoxRoomType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "UC_Customers";
            this.Size = new System.Drawing.Size(1200, 518);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmBoxRoomNo;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmboxBed;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxRoomType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtIDProof;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtNationality;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtMobileNo;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2Button allotebtn;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxGender;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_DateOfBirth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_CheckIn;
    }
}
