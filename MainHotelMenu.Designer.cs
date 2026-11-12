using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    partial class MainHotelMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelHotel = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnStaff = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuests = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomers = new Guna.UI2.WinForms.Guna2Button();
            this.btnRooms = new Guna.UI2.WinForms.Guna2Button();
            this.btnBookings = new Guna.UI2.WinForms.Guna2Button();
            this.pictureLogoSmall = new System.Windows.Forms.PictureBox();
            this.UC_Panel = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoSmall)).BeginInit();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = Color.FromArgb(30, 41, 59);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Controls.Add(this.labelUser);
            this.panelHeader.Controls.Add(this.labelHotel);
            this.panelHeader.Controls.Add(this.pictureLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1460, 72);
            this.panelHeader.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnClose.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnClose.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.btnClose.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnClose.FillColor = Color.FromArgb(239, 68, 68);
            this.btnClose.FocusedColor = Color.Empty;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.HoverState.FillColor = Color.FromArgb(199, 45, 45);
            this.btnClose.Location = new System.Drawing.Point(1398, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.closebtn_Click);
            //
            // labelUser
            //
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.labelUser.ForeColor = Color.FromArgb(243, 246, 249);
            this.labelUser.Location = new System.Drawing.Point(1060, 18);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(320, 36);
            this.labelUser.TabIndex = 3;
            this.labelUser.TextAlign = ContentAlignment.MiddleRight;
            //
            // labelHotel
            //
            this.labelHotel.AutoSize = true;
            this.labelHotel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.labelHotel.ForeColor = Color.FromArgb(212, 175, 55);
            this.labelHotel.Location = new System.Drawing.Point(70, 22);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(242, 30);
            this.labelHotel.TabIndex = 2;
            this.labelHotel.Text = "Hotel Management";
            //
            // pictureLogo
            //
            this.pictureLogo.Image = global::Hotel_Managment_System.Properties.Resources._1496677265_2_84643;
            this.pictureLogo.Location = new System.Drawing.Point(12, 10);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(52, 52);
            this.pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 1;
            this.pictureLogo.TabStop = false;
            //
            // panelSidebar
            //
            this.panelSidebar.BackColor = Color.FromArgb(15, 23, 42);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnStaff);
            this.panelSidebar.Controls.Add(this.btnGuests);
            this.panelSidebar.Controls.Add(this.btnCustomers);
            this.panelSidebar.Controls.Add(this.btnRooms);
            this.panelSidebar.Controls.Add(this.btnBookings);
            this.panelSidebar.Controls.Add(this.pictureLogoSmall);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 72);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 688);
            this.panelSidebar.TabIndex = 1;
            //
            // btnLogout
            //
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BorderRadius = 12;
            this.btnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnLogout.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnLogout.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnLogout.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnLogout.FillColor = Color.FromArgb(30, 41, 59);
            this.btnLogout.FocusedColor = Color.Empty;
            this.btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.HoverState.FillColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.Location = new System.Drawing.Point(20, 614);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 48);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "تسجيل الخروج";
            this.btnLogout.TextAlign = HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.logoutbtn_Click);
            //
            // btnStaff
            //
            this.btnStaff.BorderRadius = 12;
            this.btnStaff.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnStaff.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnStaff.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnStaff.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnStaff.FillColor = Color.Transparent;
            this.btnStaff.FocusedColor = Color.Empty;
            this.btnStaff.Font = new Font("Segoe UI", 10F);
            this.btnStaff.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnStaff.HoverState.FillColor = Color.FromArgb(30, 41, 59);
            this.btnStaff.HoverState.ForeColor = Color.White;
            this.btnStaff.Location = new System.Drawing.Point(20, 372);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(220, 48);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "الموظفون";
            this.btnStaff.TextAlign = HorizontalAlignment.Left;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            //
            // btnGuests
            //
            this.btnGuests.BorderRadius = 12;
            this.btnGuests.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGuests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuests.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnGuests.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnGuests.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnGuests.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnGuests.FillColor = Color.Transparent;
            this.btnGuests.FocusedColor = Color.Empty;
            this.btnGuests.Font = new Font("Segoe UI", 10F);
            this.btnGuests.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnGuests.HoverState.FillColor = Color.FromArgb(30, 41, 59);
            this.btnGuests.HoverState.ForeColor = Color.White;
            this.btnGuests.Location = new System.Drawing.Point(20, 312);
            this.btnGuests.Name = "btnGuests";
            this.btnGuests.Size = new System.Drawing.Size(220, 48);
            this.btnGuests.TabIndex = 4;
            this.btnGuests.Text = "النزلاء";
            this.btnGuests.TextAlign = HorizontalAlignment.Left;
            this.btnGuests.Click += new System.EventHandler(this.btnGuests_Click);
            //
            // btnCustomers
            //
            this.btnCustomers.BorderRadius = 12;
            this.btnCustomers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomers.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnCustomers.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnCustomers.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnCustomers.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnCustomers.FillColor = Color.Transparent;
            this.btnCustomers.FocusedColor = Color.Empty;
            this.btnCustomers.Font = new Font("Segoe UI", 10F);
            this.btnCustomers.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnCustomers.HoverState.FillColor = Color.FromArgb(30, 41, 59);
            this.btnCustomers.HoverState.ForeColor = Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(20, 252);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(220, 48);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "العملاء";
            this.btnCustomers.TextAlign = HorizontalAlignment.Left;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            //
            // btnRooms
            //
            this.btnRooms.BorderRadius = 12;
            this.btnRooms.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRooms.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnRooms.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnRooms.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnRooms.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnRooms.FillColor = Color.FromArgb(37, 99, 235);
            this.btnRooms.FocusedColor = Color.Empty;
            this.btnRooms.Font = new Font("Segoe UI", 10F);
            this.btnRooms.ForeColor = Color.White;
            this.btnRooms.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            this.btnRooms.HoverState.ForeColor = Color.White;
            this.btnRooms.Location = new System.Drawing.Point(20, 192);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(220, 48);
            this.btnRooms.TabIndex = 2;
            this.btnRooms.Text = "الغرف";
            this.btnRooms.TextAlign = HorizontalAlignment.Left;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            //
            // btnBookings
            //
            this.btnBookings.BorderRadius = 12;
            this.btnBookings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookings.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.btnBookings.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.btnBookings.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            this.btnBookings.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.btnBookings.FillColor = Color.Transparent;
            this.btnBookings.FocusedColor = Color.Empty;
            this.btnBookings.Font = new Font("Segoe UI", 10F);
            this.btnBookings.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnBookings.HoverState.FillColor = Color.FromArgb(30, 41, 59);
            this.btnBookings.HoverState.ForeColor = Color.White;
            this.btnBookings.Location = new System.Drawing.Point(20, 132);
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(220, 48);
            this.btnBookings.TabIndex = 1;
            this.btnBookings.Text = "لوحة القيادة";
            this.btnBookings.TextAlign = HorizontalAlignment.Left;
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            //
            // pictureLogoSmall
            //
            this.pictureLogoSmall.Image = global::Hotel_Managment_System.Properties.Resources._1496677265_2_84643;
            this.pictureLogoSmall.Location = new System.Drawing.Point(20, 26);
            this.pictureLogoSmall.Name = "pictureLogoSmall";
            this.pictureLogoSmall.Size = new System.Drawing.Size(220, 72);
            this.pictureLogoSmall.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureLogoSmall.TabIndex = 0;
            this.pictureLogoSmall.TabStop = false;
            //
            // UC_Panel
            //
            this.UC_Panel.BackColor = Color.FromArgb(243, 246, 249);
            this.UC_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Panel.Location = new System.Drawing.Point(260, 72);
            this.UC_Panel.Name = "UC_Panel";
            this.UC_Panel.Size = new System.Drawing.Size(1200, 688);
            this.UC_Panel.TabIndex = 2;
            //
            // guna2DragControl1
            //
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panelHeader;
            this.guna2DragControl1.UseTransparentDrag = true;
            //
            // MainHotelMenu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 760);
            this.Controls.Add(this.UC_Panel);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainHotelMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainHotelMenu";
            this.Load += new System.EventHandler(this.MainHotelMenu_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogoSmall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.Label labelUser;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureLogoSmall;
        private Guna.UI2.WinForms.Guna2Button btnBookings;
        private Guna.UI2.WinForms.Guna2Button btnRooms;
        private Guna.UI2.WinForms.Guna2Button btnCustomers;
        private Guna.UI2.WinForms.Guna2Button btnGuests;
        private Guna.UI2.WinForms.Guna2Button btnStaff;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private System.Windows.Forms.Panel UC_Panel;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}

