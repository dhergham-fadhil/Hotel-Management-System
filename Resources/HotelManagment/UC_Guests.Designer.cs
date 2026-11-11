using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Guests
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.refreshbtn = new Guna.UI2.WinForms.Guna2Button();
            this.labelActive = new System.Windows.Forms.Label();
            this.DGV_Guests = new Guna.UI2.WinForms.Guna2DataGridView();
            this.labelSelected = new System.Windows.Forms.Label();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.DTP_CheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.labelSummary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Guests)).BeginInit();
            this.SuspendLayout();
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelTitle.Location = new Point(24, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(160, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "الضيوف والمغادرة";
            //
            // labelSubtitle
            //
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelSubtitle.Location = new Point(26, 62);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new Size(180, 19);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "إدارة النزلاء وتسجيل المغادرة";
            //
            // refreshbtn
            //
            this.refreshbtn.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.refreshbtn.BorderRadius = 10;
            this.refreshbtn.Cursor = Cursors.Hand;
            this.refreshbtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.refreshbtn.FillColor = Color.FromArgb(37, 99, 235);
            this.refreshbtn.FocusedColor = Color.Empty;
            this.refreshbtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.refreshbtn.ForeColor = Color.White;
            this.refreshbtn.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            this.refreshbtn.Location = new Point(1040, 22);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new Size(128, 40);
            this.refreshbtn.TabIndex = 2;
            this.refreshbtn.Text = "تحديث";
            this.refreshbtn.Click += new EventHandler(this.refreshbtn_Click);
            //
            // labelActive
            //
            this.labelActive.AutoSize = true;
            this.labelActive.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.labelActive.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelActive.Location = new Point(24, 98);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new Size(105, 20);
            this.labelActive.TabIndex = 3;
            this.labelActive.Text = "الضيوف النشطون";
            //
            // DGV_Guests
            //
            dataGridViewCellStyle1.BackColor = Color.White;
            this.DGV_Guests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Guests.AllowUserToAddRows = false;
            this.DGV_Guests.AllowUserToDeleteRows = false;
            this.DGV_Guests.AllowUserToResizeRows = false;
            this.DGV_Guests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Guests.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            this.DGV_Guests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Guests.ColumnHeadersHeight = 32;
            this.DGV_Guests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 246, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            this.DGV_Guests.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Guests.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_Guests.Location = new Point(24, 128);
            this.DGV_Guests.Name = "DGV_Guests";
            this.DGV_Guests.ReadOnly = true;
            this.DGV_Guests.RowHeadersVisible = false;
            this.DGV_Guests.RowTemplate.Height = 28;
            this.DGV_Guests.Size = new Size(1144, 230);
            this.DGV_Guests.TabIndex = 4;
            this.DGV_Guests.CellClick += new DataGridViewCellEventHandler(this.DGV_Guests_CellClick);
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            this.DGV_Guests.ThemeStyle.BackColor = Color.White;
            this.DGV_Guests.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_Guests.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.DGV_Guests.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            this.DGV_Guests.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.DGV_Guests.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            this.DGV_Guests.ThemeStyle.HeaderStyle.Height = 32;
            this.DGV_Guests.ThemeStyle.ReadOnly = true;
            this.DGV_Guests.ThemeStyle.RowsStyle.BackColor = Color.White;
            this.DGV_Guests.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Guests.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            this.DGV_Guests.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 85, 105);
            this.DGV_Guests.ThemeStyle.RowsStyle.Height = 28;
            this.DGV_Guests.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(243, 246, 249);
            this.DGV_Guests.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            //
            // labelSelected
            //
            this.labelSelected.AutoSize = false;
            this.labelSelected.Font = new Font("Segoe UI", 9.5F);
            this.labelSelected.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelSelected.Location = new Point(24, 372);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new Size(420, 24);
            this.labelSelected.TabIndex = 5;
            this.labelSelected.Text = "اختر نزيلًا من الشبكة.";
            //
            // labelCheckOut
            //
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new Font("Segoe UI", 9.5F);
            this.labelCheckOut.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelCheckOut.Location = new Point(24, 404);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new Size(96, 17);
            this.labelCheckOut.TabIndex = 6;
            this.labelCheckOut.Text = "تاريخ المغادرة";
            //
            // DTP_CheckOut
            //
            this.DTP_CheckOut.BorderRadius = 8;
            this.DTP_CheckOut.Checked = true;
            this.DTP_CheckOut.FillColor = Color.FromArgb(37, 99, 235);
            this.DTP_CheckOut.Font = new Font("Segoe UI", 9F);
            this.DTP_CheckOut.ForeColor = Color.White;
            this.DTP_CheckOut.Format = DateTimePickerFormat.Long;
            this.DTP_CheckOut.Location = new Point(24, 426);
            this.DTP_CheckOut.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DTP_CheckOut.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DTP_CheckOut.Name = "DTP_CheckOut";
            this.DTP_CheckOut.Size = new Size(240, 40);
            this.DTP_CheckOut.TabIndex = 7;
            this.DTP_CheckOut.Value = new DateTime(2025, 9, 7, 20, 43, 15, 455);
            this.DTP_CheckOut.ValueChanged += new EventHandler(this.DTP_CheckOut_ValueChanged);
            //
            // btnCheckout
            //
            this.btnCheckout.BorderRadius = 10;
            this.btnCheckout.Cursor = Cursors.Hand;
            this.btnCheckout.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnCheckout.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnCheckout.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.btnCheckout.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnCheckout.Enabled = false;
            this.btnCheckout.FillColor = Color.FromArgb(16, 185, 129);
            this.btnCheckout.FocusedColor = Color.Empty;
            this.btnCheckout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCheckout.ForeColor = Color.White;
            this.btnCheckout.HoverState.FillColor = Color.FromArgb(5, 150, 105);
            this.btnCheckout.Location = new Point(290, 426);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new Size(140, 40);
            this.btnCheckout.TabIndex = 8;
            this.btnCheckout.Text = "تسجيل المغادرة";
            this.btnCheckout.TextAlign = HorizontalAlignment.Left;
            this.btnCheckout.Click += new EventHandler(this.btnCheckout_Click);
            //
            // labelSummary
            //
            this.labelSummary.AutoSize = false;
            this.labelSummary.Font = new Font("Segoe UI", 9.5F);
            this.labelSummary.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelSummary.Location = new Point(450, 404);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new Size(718, 62);
            this.labelSummary.TabIndex = 9;
            this.labelSummary.Text = "اختر نزيلًا لعرض تقدير الفاتورة.";
            //
            // UC_Guests
            //
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.DTP_CheckOut);
            this.Controls.Add(this.labelCheckOut);
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.DGV_Guests);
            this.Controls.Add(this.labelActive);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "UC_Guests";
            this.Size = new Size(1200, 518);
            this.Load += new EventHandler(this.UC_Guests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Guests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2Button refreshbtn;
        private System.Windows.Forms.Label labelActive;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Guests;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelCheckOut;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_CheckOut;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private System.Windows.Forms.Label labelSummary;
    }
}
