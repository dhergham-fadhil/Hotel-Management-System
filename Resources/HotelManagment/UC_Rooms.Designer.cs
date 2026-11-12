using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Rooms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.txtRoomNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.DGV_Rooms = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmBoxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmboxBed = new Guna.UI2.WinForms.Guna2ComboBox();
            this.addbtn = new Guna.UI2.WinForms.Guna2Button();
            this.editbtn = new Guna.UI2.WinForms.Guna2Button();
            this.deletebtn = new Guna.UI2.WinForms.Guna2Button();
            this.cmBoxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearbtn = new Guna.UI2.WinForms.Guna2Button();
            this.labelHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rooms)).BeginInit();
            this.SuspendLayout();
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelTitle.Location = new System.Drawing.Point(24, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(102, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "إدارة الغرف";
            //
            // labelSubtitle
            //
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelSubtitle.Location = new System.Drawing.Point(26, 62);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(157, 19);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "إضافة وتعديل وحذف الغرف";
            //
            // txtRoomNumber
            //
            this.txtRoomNumber.BorderRadius = 8;
            this.txtRoomNumber.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtRoomNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomNumber.DefaultText = "";
            this.txtRoomNumber.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.txtRoomNumber.DisabledState.FillColor = Color.FromArgb(243, 246, 249);
            this.txtRoomNumber.DisabledState.ForeColor = Color.FromArgb(107, 114, 128);
            this.txtRoomNumber.FillColor = Color.White;
            this.txtRoomNumber.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtRoomNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoomNumber.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtRoomNumber.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtRoomNumber.Location = new System.Drawing.Point(28, 96);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.PlaceholderText = "رقم الغرفة";
            this.txtRoomNumber.SelectedText = "";
            this.txtRoomNumber.Size = new System.Drawing.Size(240, 40);
            this.txtRoomNumber.TabIndex = 2;
            //
            // DGV_Rooms
            //
            dataGridViewCellStyle1.BackColor = Color.White;
            this.DGV_Rooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Rooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Rooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Rooms.ColumnHeadersHeight = 32;
            this.DGV_Rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 246, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Rooms.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Rooms.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_Rooms.Location = new System.Drawing.Point(292, 96);
            this.DGV_Rooms.Name = "DGV_Rooms";
            this.DGV_Rooms.ReadOnly = true;
            this.DGV_Rooms.RowHeadersVisible = false;
            this.DGV_Rooms.RowTemplate.Height = 28;
            this.DGV_Rooms.Size = new System.Drawing.Size(868, 500);
            this.DGV_Rooms.TabIndex = 4;
            this.DGV_Rooms.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.DGV_Rooms.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Rooms.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            this.DGV_Rooms.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            this.DGV_Rooms.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            this.DGV_Rooms.ThemeStyle.BackColor = Color.White;
            this.DGV_Rooms.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_Rooms.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(241, 245, 249);
            this.DGV_Rooms.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Rooms.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.DGV_Rooms.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(15, 23, 42);
            this.DGV_Rooms.ThemeStyle.HeaderStyle.Height = 38;
            this.DGV_Rooms.ThemeStyle.ReadOnly = true;
            this.DGV_Rooms.ThemeStyle.RowsStyle.BackColor = Color.White;
            this.DGV_Rooms.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Rooms.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.DGV_Rooms.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 85, 105);
            this.DGV_Rooms.ThemeStyle.RowsStyle.Height = 34;
            this.DGV_Rooms.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            this.DGV_Rooms.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = Color.FromArgb(71, 85, 105);
            this.label1.Location = new System.Drawing.Point(28, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "نوع الغرفة";
            //
            // txtPrice
            //
            this.txtPrice.BorderRadius = 8;
            this.txtPrice.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.txtPrice.DisabledState.FillColor = Color.FromArgb(243, 246, 249);
            this.txtPrice.DisabledState.ForeColor = Color.FromArgb(107, 114, 128);
            this.txtPrice.FillColor = Color.White;
            this.txtPrice.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtPrice.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtPrice.Location = new System.Drawing.Point(28, 290);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "السعر";
            this.txtPrice.SelectedText = "";
            this.txtPrice.Size = new System.Drawing.Size(240, 40);
            this.txtPrice.TabIndex = 10;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label5.ForeColor = Color.FromArgb(71, 85, 105);
            this.label5.Location = new System.Drawing.Point(28, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "السعر";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label6.ForeColor = Color.FromArgb(71, 85, 105);
            this.label6.Location = new System.Drawing.Point(28, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "السرير";
            //
            // cmBoxRoomType
            //
            this.cmBoxRoomType.BorderRadius = 8;
            this.cmBoxRoomType.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmBoxRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmBoxRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxRoomType.FillColor = Color.White;
            this.cmBoxRoomType.FocusedColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomType.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmBoxRoomType.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmBoxRoomType.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomType.ItemHeight = 30;
            this.cmBoxRoomType.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Twin",
            "Triple",
            "Suite"});
            this.cmBoxRoomType.Location = new System.Drawing.Point(28, 166);
            this.cmBoxRoomType.Name = "cmBoxRoomType";
            this.cmBoxRoomType.Size = new System.Drawing.Size(240, 36);
            this.cmBoxRoomType.TabIndex = 14;
            //
            // cmboxBed
            //
            this.cmboxBed.BorderRadius = 8;
            this.cmboxBed.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmboxBed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboxBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxBed.FillColor = Color.White;
            this.cmboxBed.FocusedColor = Color.FromArgb(37, 99, 235);
            this.cmboxBed.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmboxBed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmboxBed.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmboxBed.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmboxBed.ItemHeight = 30;
            this.cmboxBed.Items.AddRange(new object[] {
            "Single",
            "Double",
            "Queen",
            "King",
            "Twin",
            "Bunk"});
            this.cmboxBed.Location = new System.Drawing.Point(28, 224);
            this.cmboxBed.Name = "cmboxBed";
            this.cmboxBed.Size = new System.Drawing.Size(240, 36);
            this.cmboxBed.TabIndex = 15;
            //
            // addbtn
            //
            this.addbtn.BorderRadius = 10;
            this.addbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addbtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.addbtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.addbtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.addbtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.addbtn.FillColor = Color.FromArgb(37, 99, 235);
            this.addbtn.FocusedColor = Color.Empty;
            this.addbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.addbtn.ForeColor = Color.White;
            this.addbtn.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            this.addbtn.Location = new System.Drawing.Point(28, 402);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(110, 40);
            this.addbtn.TabIndex = 16;
            this.addbtn.Text = "إضافة";
            this.addbtn.TextAlign = HorizontalAlignment.Left;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            //
            // editbtn
            //
            this.editbtn.BorderRadius = 10;
            this.editbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.editbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editbtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.editbtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.editbtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.editbtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.editbtn.FillColor = Color.FromArgb(59, 130, 246);
            this.editbtn.FocusedColor = Color.Empty;
            this.editbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.editbtn.ForeColor = Color.White;
            this.editbtn.HoverState.FillColor = Color.FromArgb(37, 99, 235);
            this.editbtn.Location = new System.Drawing.Point(150, 402);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(110, 40);
            this.editbtn.TabIndex = 17;
            this.editbtn.Text = "تعديل";
            this.editbtn.TextAlign = HorizontalAlignment.Left;
            this.editbtn.Click += new System.EventHandler(this.editbtn_Click);
            //
            // deletebtn
            //
            this.deletebtn.BorderRadius = 10;
            this.deletebtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.deletebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletebtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.deletebtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.deletebtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.deletebtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.deletebtn.FillColor = Color.FromArgb(239, 68, 68);
            this.deletebtn.FocusedColor = Color.Empty;
            this.deletebtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.deletebtn.ForeColor = Color.White;
            this.deletebtn.HoverState.FillColor = Color.FromArgb(199, 45, 45);
            this.deletebtn.Location = new System.Drawing.Point(28, 452);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(110, 40);
            this.deletebtn.TabIndex = 18;
            this.deletebtn.Text = "حذف";
            this.deletebtn.TextAlign = HorizontalAlignment.Left;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            //
            // cmBoxStatus
            //
            this.cmBoxStatus.BorderRadius = 8;
            this.cmBoxStatus.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmBoxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxStatus.FillColor = Color.White;
            this.cmBoxStatus.FocusedColor = Color.FromArgb(37, 99, 235);
            this.cmBoxStatus.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmBoxStatus.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmBoxStatus.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxStatus.ItemHeight = 30;
            this.cmBoxStatus.Items.AddRange(new object[] {
            "Free",
            "Busy"});
            this.cmBoxStatus.Location = new System.Drawing.Point(28, 358);
            this.cmBoxStatus.Name = "cmBoxStatus";
            this.cmBoxStatus.Size = new System.Drawing.Size(240, 36);
            this.cmBoxStatus.TabIndex = 20;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.ForeColor = Color.FromArgb(71, 85, 105);
            this.label2.Location = new System.Drawing.Point(28, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "الحالة";
            //
            // clearbtn
            //
            this.clearbtn.BorderRadius = 10;
            this.clearbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.clearbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearbtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.clearbtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.clearbtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.clearbtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.clearbtn.FillColor = Color.FromArgb(243, 246, 249);
            this.clearbtn.FocusedColor = Color.Empty;
            this.clearbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clearbtn.ForeColor = Color.FromArgb(71, 85, 105);
            this.clearbtn.HoverState.FillColor = Color.FromArgb(226, 232, 240);
            this.clearbtn.Location = new System.Drawing.Point(158, 452);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(110, 40);
            this.clearbtn.TabIndex = 19;
            this.clearbtn.Text = "مسح";
            this.clearbtn.TextAlign = HorizontalAlignment.Left;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            //
            // labelHint
            //
            this.labelHint.AutoSize = false;
            this.labelHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelHint.ForeColor = Color.FromArgb(100, 116, 139);
            this.labelHint.Location = new System.Drawing.Point(292, 604);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(868, 24);
            this.labelHint.TabIndex = 20;
            this.labelHint.Text = "اختر غرفة من الشبكة لتعديلها أو حذفها.";
            //
            // UC_Rooms
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmBoxStatus);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.editbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.cmboxBed);
            this.Controls.Add(this.cmBoxRoomType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV_Rooms);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "UC_Rooms";
            this.Size = new System.Drawing.Size(1200, 518);
            this.Load += new System.EventHandler(this.UC_Rooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomNumber;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Rooms;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxRoomType;
        private Guna.UI2.WinForms.Guna2ComboBox cmboxBed;
        private Guna.UI2.WinForms.Guna2Button addbtn;
        private Guna.UI2.WinForms.Guna2Button editbtn;
        private Guna.UI2.WinForms.Guna2Button deletebtn;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxStatus;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button clearbtn;
        private System.Windows.Forms.Label labelHint;
    }
}
