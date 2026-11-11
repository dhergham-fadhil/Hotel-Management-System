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
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebtn = new System.Windows.Forms.Button();
            this.logoutbtn = new Guna.UI2.WinForms.Guna2Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bookingsbtn = new Guna.UI2.WinForms.Guna2Button();
            this.staffbtn = new Guna.UI2.WinForms.Guna2Button();
            this.customersbtn = new Guna.UI2.WinForms.Guna2Button();
            this.roomsbtn = new Guna.UI2.WinForms.Guna2Button();
            this.UC_Panel = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.logoutbtn);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 94);
            this.panel1.TabIndex = 0;
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebtn.FlatAppearance.BorderSize = 0;
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.Font = new System.Drawing.Font("Lucida Calligraphy", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.closebtn.Location = new System.Drawing.Point(1160, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(40, 40);
            this.closebtn.TabIndex = 2;
            this.closebtn.Text = "X";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // logoutbtn
            // 
            this.logoutbtn.BorderRadius = 6;
            this.logoutbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.logoutbtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.Color.White;
            this.logoutbtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.logoutbtn.Location = new System.Drawing.Point(1000, 27);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(140, 40);
            this.logoutbtn.TabIndex = 4;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoEllipsis = true;
            this.labelUser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.labelUser.Location = new System.Drawing.Point(640, 32);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(340, 30);
            this.labelUser.TabIndex = 3;
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 22.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotel Managment System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hotel_Managment_System.Properties.Resources._1496677265_2_84643;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.bookingsbtn);
            this.panel2.Controls.Add(this.staffbtn);
            this.panel2.Controls.Add(this.customersbtn);
            this.panel2.Controls.Add(this.roomsbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 88);
            this.panel2.TabIndex = 1;
            // 
            // bookingsbtn
            // 
            this.bookingsbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bookingsbtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.bookingsbtn.CustomBorderColor = System.Drawing.Color.White;
            this.bookingsbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.bookingsbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bookingsbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bookingsbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bookingsbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bookingsbtn.FillColor = System.Drawing.Color.White;
            this.bookingsbtn.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingsbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookingsbtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.bookingsbtn.Location = new System.Drawing.Point(0, 0);
            this.bookingsbtn.Name = "bookingsbtn";
            this.bookingsbtn.Size = new System.Drawing.Size(210, 88);
            this.bookingsbtn.TabIndex = 3;
            this.bookingsbtn.Text = "Dashboard";
            this.bookingsbtn.Click += new System.EventHandler(this.bookingsbtn_Click);
            // 
            // staffbtn
            // 
            this.staffbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.staffbtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.staffbtn.CustomBorderColor = System.Drawing.Color.White;
            this.staffbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.staffbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.staffbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.staffbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.staffbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.staffbtn.FillColor = System.Drawing.Color.White;
            this.staffbtn.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.staffbtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.staffbtn.Location = new System.Drawing.Point(630, 0);
            this.staffbtn.Name = "staffbtn";
            this.staffbtn.Size = new System.Drawing.Size(210, 88);
            this.staffbtn.TabIndex = 2;
            this.staffbtn.Text = "Staff";
            this.staffbtn.Click += new System.EventHandler(this.staffbtn_Click);
            // 
            // customersbtn
            // 
            this.customersbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.customersbtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.customersbtn.CustomBorderColor = System.Drawing.Color.White;
            this.customersbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.customersbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.customersbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.customersbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customersbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.customersbtn.FillColor = System.Drawing.Color.White;
            this.customersbtn.Font = new System.Drawing.Font("Cooper Black", 10.2F);
            this.customersbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customersbtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.customersbtn.Location = new System.Drawing.Point(420, 0);
            this.customersbtn.Name = "customersbtn";
            this.customersbtn.Size = new System.Drawing.Size(210, 88);
            this.customersbtn.TabIndex = 1;
            this.customersbtn.Text = "Customers";
            this.customersbtn.Click += new System.EventHandler(this.customersbtn_Click);
            // 
            // roomsbtn
            // 
            this.roomsbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.roomsbtn.Checked = true;
            this.roomsbtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.roomsbtn.CustomBorderColor = System.Drawing.Color.White;
            this.roomsbtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.roomsbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.roomsbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.roomsbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.roomsbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.roomsbtn.FillColor = System.Drawing.Color.White;
            this.roomsbtn.Font = new System.Drawing.Font("Cooper Black", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsbtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.roomsbtn.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.roomsbtn.Location = new System.Drawing.Point(210, 0);
            this.roomsbtn.Name = "roomsbtn";
            this.roomsbtn.Size = new System.Drawing.Size(210, 88);
            this.roomsbtn.TabIndex = 0;
            this.roomsbtn.Text = "Rooms";
            this.roomsbtn.Click += new System.EventHandler(this.roomsbtn_Click);
            // 
            // UC_Panel
            // 
            this.UC_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.UC_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC_Panel.Location = new System.Drawing.Point(0, 182);
            this.UC_Panel.Name = "UC_Panel";
            this.UC_Panel.Size = new System.Drawing.Size(1200, 518);
            this.UC_Panel.TabIndex = 2;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // MainHotelMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.UC_Panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainHotelMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainHotelMenu";
            this.Load += new System.EventHandler(this.MainHotelMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closebtn;
        private Guna.UI2.WinForms.Guna2Button logoutbtn;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button roomsbtn;
        private Guna.UI2.WinForms.Guna2Button staffbtn;
        private Guna.UI2.WinForms.Guna2Button customersbtn;
        private System.Windows.Forms.Panel UC_Panel;
        private Guna.UI2.WinForms.Guna2Button bookingsbtn;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}