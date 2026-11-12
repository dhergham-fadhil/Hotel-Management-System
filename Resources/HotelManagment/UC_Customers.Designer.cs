using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Customers
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMobileNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNationality = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmBoxGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIDProof = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTP_DateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.DTP_CheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cmboxBed = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmBoxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmBoxRoomNo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.allotebtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelTitle.Location = new Point(40, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(135, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "تسجيل النزيل";
            // labelSubtitle
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelSubtitle.Location = new Point(42, 62);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new Size(194, 19);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "إضافة نزيل جديد وتخصيص غرفة";
            // txtName
            this.txtName.BorderRadius = 8; this.txtName.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtName.DefaultText = ""; this.txtName.FillColor = Color.White;
            this.txtName.Font = new Font("Segoe UI", 10F); this.txtName.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtName.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtName.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtName.Location = new Point(40, 120); this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "الاسم الكامل"; this.txtName.Size = new Size(260, 40);
            this.txtName.TabIndex = 2;
            // label1
            this.label1.AutoSize = true; this.label1.Font = new Font("Segoe UI", 9.5F);
            this.label1.ForeColor = Color.FromArgb(71, 85, 105); this.label1.Location = new Point(40, 96);
            this.label1.Name = "label1"; this.label1.Size = new Size(64, 19);
            this.label1.TabIndex = 3; this.label1.Text = "الاسم الكامل";
            // txtMobileNo
            this.txtMobileNo.BorderRadius = 8; this.txtMobileNo.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtMobileNo.DefaultText = ""; this.txtMobileNo.FillColor = Color.White;
            this.txtMobileNo.Font = new Font("Segoe UI", 10F); this.txtMobileNo.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtMobileNo.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtMobileNo.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtMobileNo.Location = new Point(40, 200); this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.PlaceholderText = "رقم الجوال"; this.txtMobileNo.Size = new Size(260, 40);
            this.txtMobileNo.TabIndex = 4;
            // label9
            this.label9.AutoSize = true; this.label9.Font = new Font("Segoe UI", 9.5F);
            this.label9.ForeColor = Color.FromArgb(71, 85, 105); this.label9.Location = new Point(40, 176);
            this.label9.Name = "label9"; this.label9.Size = new Size(74, 19);
            this.label9.TabIndex = 5; this.label9.Text = "رقم الجوال";
            // txtNationality
            this.txtNationality.BorderRadius = 8; this.txtNationality.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtNationality.DefaultText = ""; this.txtNationality.FillColor = Color.White;
            this.txtNationality.Font = new Font("Segoe UI", 10F); this.txtNationality.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtNationality.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtNationality.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtNationality.Location = new Point(40, 280); this.txtNationality.Name = "txtNationality";
            this.txtNationality.PlaceholderText = "الجنسية"; this.txtNationality.Size = new Size(260, 40);
            this.txtNationality.TabIndex = 6;
            // label8
            this.label8.AutoSize = true; this.label8.Font = new Font("Segoe UI", 9.5F);
            this.label8.ForeColor = Color.FromArgb(71, 85, 105); this.label8.Location = new Point(40, 256);
            this.label8.Name = "label8"; this.label8.Size = new Size(64, 19);
            this.label8.TabIndex = 7; this.label8.Text = "الجنسية";
            // cmBoxGender
            this.cmBoxGender.BorderRadius = 8; this.cmBoxGender.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmBoxGender.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmBoxGender.FillColor = Color.White;
            this.cmBoxGender.Font = new Font("Segoe UI", 10F); this.cmBoxGender.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmBoxGender.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxGender.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxGender.ItemHeight = 30;
            this.cmBoxGender.Items.AddRange(new object[] { "Male", "Female", "Other", "I Rather Do Not Answer" });
            this.cmBoxGender.Location = new Point(40, 360); this.cmBoxGender.Name = "cmBoxGender"; this.cmBoxGender.Size = new Size(260, 36);
            this.cmBoxGender.TabIndex = 8;
            // label4
            this.label4.AutoSize = true; this.label4.Font = new Font("Segoe UI", 9.5F);
            this.label4.ForeColor = Color.FromArgb(71, 85, 105); this.label4.Location = new Point(40, 336);
            this.label4.Name = "label4"; this.label4.Size = new Size(56, 19);
            this.label4.TabIndex = 9; this.label4.Text = "النوع";
            // txtIDProof
            this.txtIDProof.BorderRadius = 8; this.txtIDProof.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtIDProof.DefaultText = ""; this.txtIDProof.FillColor = Color.White;
            this.txtIDProof.Font = new Font("Segoe UI", 10F); this.txtIDProof.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtIDProof.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtIDProof.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtIDProof.Location = new Point(340, 120); this.txtIDProof.Name = "txtIDProof";
            this.txtIDProof.PlaceholderText = "إثبات الهوية"; this.txtIDProof.Size = new Size(260, 40);
            this.txtIDProof.TabIndex = 10;
            // label7
            this.label7.AutoSize = true; this.label7.Font = new Font("Segoe UI", 9.5F);
            this.label7.ForeColor = Color.FromArgb(71, 85, 105); this.label7.Location = new Point(340, 96);
            this.label7.Name = "label7"; this.label7.Size = new Size(90, 19);
            this.label7.TabIndex = 11; this.label7.Text = "إثبات الهوية";
            // txtAddress
            this.txtAddress.BorderRadius = 8; this.txtAddress.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtAddress.DefaultText = ""; this.txtAddress.FillColor = Color.White;
            this.txtAddress.Font = new Font("Segoe UI", 10F); this.txtAddress.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtAddress.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtAddress.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtAddress.Location = new Point(340, 200); this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "العنوان"; this.txtAddress.Size = new Size(260, 40);
            this.txtAddress.TabIndex = 12;
            // label5
            this.label5.AutoSize = true; this.label5.Font = new Font("Segoe UI", 9.5F);
            this.label5.ForeColor = Color.FromArgb(71, 85, 105); this.label5.Location = new Point(340, 176);
            this.label5.Name = "label5"; this.label5.Size = new Size(64, 19);
            this.label5.TabIndex = 13; this.label5.Text = "العنوان";
            // DTP_DateOfBirth
            this.DTP_DateOfBirth.BorderRadius = 8; this.DTP_DateOfBirth.Checked = true;
            this.DTP_DateOfBirth.FillColor = Color.FromArgb(37, 99, 235);
            this.DTP_DateOfBirth.Font = new Font("Segoe UI", 9F);
            this.DTP_DateOfBirth.ForeColor = Color.White;
            this.DTP_DateOfBirth.Format = DateTimePickerFormat.Long;
            this.DTP_DateOfBirth.Location = new Point(340, 280); this.DTP_DateOfBirth.Name = "DTP_DateOfBirth";
            this.DTP_DateOfBirth.Size = new Size(260, 40);
            this.DTP_DateOfBirth.TabIndex = 14;
            this.DTP_DateOfBirth.Value = new DateTime(2025, 9, 7, 20, 43, 15, 455);
            // label11
            this.label11.AutoSize = true; this.label11.Font = new Font("Segoe UI", 9.5F);
            this.label11.ForeColor = Color.FromArgb(71, 85, 105); this.label11.Location = new Point(340, 256);
            this.label11.Name = "label11"; this.label11.Size = new Size(80, 19);
            this.label11.TabIndex = 15; this.label11.Text = "تاريخ الميلاد";
            // DTP_CheckIn
            this.DTP_CheckIn.BorderRadius = 8; this.DTP_CheckIn.Checked = true;
            this.DTP_CheckIn.FillColor = Color.FromArgb(37, 99, 235);
            this.DTP_CheckIn.Font = new Font("Segoe UI", 9F);
            this.DTP_CheckIn.ForeColor = Color.White;
            this.DTP_CheckIn.Format = DateTimePickerFormat.Long;
            this.DTP_CheckIn.Location = new Point(340, 360); this.DTP_CheckIn.Name = "DTP_CheckIn";
            this.DTP_CheckIn.Size = new Size(260, 40);
            this.DTP_CheckIn.TabIndex = 16;
            this.DTP_CheckIn.Value = new DateTime(2025, 9, 7, 20, 43, 15, 455);
            // label12
            this.label12.AutoSize = true; this.label12.Font = new Font("Segoe UI", 9.5F);
            this.label12.ForeColor = Color.FromArgb(71, 85, 105); this.label12.Location = new Point(340, 336);
            this.label12.Name = "label12"; this.label12.Size = new Size(80, 19);
            this.label12.TabIndex = 17; this.label12.Text = "تاريخ الوصول";
            // cmboxBed
            this.cmboxBed.BorderRadius = 8; this.cmboxBed.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmboxBed.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmboxBed.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmboxBed.FillColor = Color.White;
            this.cmboxBed.Font = new Font("Segoe UI", 10F); this.cmboxBed.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmboxBed.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmboxBed.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmboxBed.ItemHeight = 30;
            this.cmboxBed.Items.AddRange(new object[] { "Single", "Double", "Queen", "King", "Twin", "Bunk" });
            this.cmboxBed.Location = new Point(640, 120); this.cmboxBed.Name = "cmboxBed"; this.cmboxBed.Size = new Size(260, 36);
            this.cmboxBed.TabIndex = 18;
            // label3
            this.label3.AutoSize = true; this.label3.Font = new Font("Segoe UI", 9.5F);
            this.label3.ForeColor = Color.FromArgb(71, 85, 105); this.label3.Location = new Point(640, 96);
            this.label3.Name = "label3"; this.label3.Size = new Size(80, 19);
            this.label3.TabIndex = 19; this.label3.Text = "نوع السرير";
            // cmBoxRoomType
            this.cmBoxRoomType.BorderRadius = 8; this.cmBoxRoomType.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmBoxRoomType.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmBoxRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmBoxRoomType.FillColor = Color.White;
            this.cmBoxRoomType.Font = new Font("Segoe UI", 10F); this.cmBoxRoomType.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmBoxRoomType.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomType.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomType.ItemHeight = 30;
            this.cmBoxRoomType.Items.AddRange(new object[] { "Single", "Double", "Twin", "Triple", "Suite" });
            this.cmBoxRoomType.Location = new Point(640, 200); this.cmBoxRoomType.Name = "cmBoxRoomType"; this.cmBoxRoomType.Size = new Size(260, 36);
            this.cmBoxRoomType.TabIndex = 20;
            // label2
            this.label2.AutoSize = true; this.label2.Font = new Font("Segoe UI", 9.5F);
            this.label2.ForeColor = Color.FromArgb(71, 85, 105); this.label2.Location = new Point(640, 176);
            this.label2.Name = "label2"; this.label2.Size = new Size(70, 19);
            this.label2.TabIndex = 21; this.label2.Text = "نوع الغرفة";
            // cmBoxRoomNo
            this.cmBoxRoomNo.BorderRadius = 8; this.cmBoxRoomNo.BorderColor = Color.FromArgb(226, 232, 240);
            this.cmBoxRoomNo.DrawMode = DrawMode.OwnerDrawFixed;
            this.cmBoxRoomNo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmBoxRoomNo.FillColor = Color.White;
            this.cmBoxRoomNo.Font = new Font("Segoe UI", 10F); this.cmBoxRoomNo.ForeColor = Color.FromArgb(15, 23, 42);
            this.cmBoxRoomNo.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomNo.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.cmBoxRoomNo.ItemHeight = 30;
            this.cmBoxRoomNo.Location = new Point(640, 280); this.cmBoxRoomNo.Name = "cmBoxRoomNo"; this.cmBoxRoomNo.Size = new Size(260, 36);
            this.cmBoxRoomNo.TabIndex = 22;
            // label6
            this.label6.AutoSize = true; this.label6.Font = new Font("Segoe UI", 9.5F);
            this.label6.ForeColor = Color.FromArgb(71, 85, 105); this.label6.Location = new Point(640, 256);
            this.label6.Name = "label6"; this.label6.Size = new Size(80, 19);
            this.label6.TabIndex = 23; this.label6.Text = "رقم الغرفة";
            // txtPrice
            this.txtPrice.BorderRadius = 8; this.txtPrice.BorderColor = Color.FromArgb(226, 232, 240);
            this.txtPrice.DefaultText = ""; this.txtPrice.FillColor = Color.FromArgb(243, 246, 249);
            this.txtPrice.Font = new Font("Segoe UI", 10F); this.txtPrice.ForeColor = Color.FromArgb(15, 23, 42);
            this.txtPrice.HoverState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtPrice.FocusedState.BorderColor = Color.FromArgb(37, 99, 235);
            this.txtPrice.Location = new Point(640, 360); this.txtPrice.Name = "txtPrice";
            this.txtPrice.PlaceholderText = "السعر"; this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new Size(260, 40); this.txtPrice.TabIndex = 24;
            // label10
            this.label10.AutoSize = true; this.label10.Font = new Font("Segoe UI", 9.5F);
            this.label10.ForeColor = Color.FromArgb(71, 85, 105); this.label10.Location = new Point(640, 336);
            this.label10.Name = "label10"; this.label10.Size = new Size(42, 19);
            this.label10.TabIndex = 25; this.label10.Text = "السعر";
            // allotebtn
            this.allotebtn.BorderRadius = 10;
            this.allotebtn.Cursor = Cursors.Hand;
            this.allotebtn.FillColor = Color.FromArgb(16, 185, 129);
            this.allotebtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.allotebtn.ForeColor = Color.White;
            this.allotebtn.HoverState.FillColor = Color.FromArgb(5, 150, 105);
            this.allotebtn.Location = new Point(640, 424);
            this.allotebtn.Name = "allotebtn"; this.allotebtn.Size = new Size(156, 48);
            this.allotebtn.TabIndex = 26;
            this.allotebtn.Text = "تخصيص الغرفة";
            this.allotebtn.TextAlign = HorizontalAlignment.Left;
            this.allotebtn.Click += new EventHandler(this.allotebtn_Click);
            // UC_Customers
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.Controls.Add(this.allotebtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmBoxRoomNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmBoxRoomType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmboxBed);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DTP_CheckIn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DTP_DateOfBirth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIDProof);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmBoxGender);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "UC_Customers";
            this.Size = new Size(1200, 518);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMobileNo;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtNationality;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxGender;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtIDProof;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_DateOfBirth;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_CheckIn;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2ComboBox cmboxBed;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxRoomType;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmBoxRoomNo;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button allotebtn;
    }
}
