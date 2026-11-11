namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Guests
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
            this.refreshbtn = new Guna.UI2.WinForms.Guna2Button();
            this.labelActive = new System.Windows.Forms.Label();
            this.DGV_Guests = new Guna.UI2.WinForms.Guna2DataGridView();
            this.labelSummary = new System.Windows.Forms.Label();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.DTP_CheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.labelSelected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Guests)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelTitle.Location = new System.Drawing.Point(27, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(291, 39);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Guests & Check-out";
            this.labelTitle.UseMnemonic = false;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelSubtitle.Location = new System.Drawing.Point(31, 62);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(188, 21);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "Active guests and billing";
            // 
            // refreshbtn
            // 
            this.refreshbtn.BorderRadius = 6;
            this.refreshbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.refreshbtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshbtn.ForeColor = System.Drawing.Color.White;
            this.refreshbtn.Location = new System.Drawing.Point(1020, 26);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(140, 40);
            this.refreshbtn.TabIndex = 2;
            this.refreshbtn.Text = "Refresh";
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // labelActive
            // 
            this.labelActive.AutoSize = true;
            this.labelActive.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelActive.Location = new System.Drawing.Point(30, 98);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(115, 23);
            this.labelActive.TabIndex = 3;
            this.labelActive.Text = "Active guests";
            // 
            // DGV_Guests
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV_Guests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Guests.AllowUserToAddRows = false;
            this.DGV_Guests.AllowUserToDeleteRows = false;
            this.DGV_Guests.AllowUserToResizeRows = false;
            this.DGV_Guests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Guests.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Guests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Guests.ColumnHeadersHeight = 35;
            this.DGV_Guests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Guests.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Guests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Guests.Location = new System.Drawing.Point(30, 128);
            this.DGV_Guests.MultiSelect = false;
            this.DGV_Guests.Name = "DGV_Guests";
            this.DGV_Guests.ReadOnly = true;
            this.DGV_Guests.RowHeadersVisible = false;
            this.DGV_Guests.RowHeadersWidth = 51;
            this.DGV_Guests.RowTemplate.Height = 30;
            this.DGV_Guests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Guests.Size = new System.Drawing.Size(1140, 270);
            this.DGV_Guests.TabIndex = 4;
            this.DGV_Guests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Guests_CellClick);
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV_Guests.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV_Guests.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Guests.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Guests.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGV_Guests.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Guests.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Guests.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV_Guests.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV_Guests.ThemeStyle.HeaderStyle.Height = 35;
            this.DGV_Guests.ThemeStyle.ReadOnly = true;
            this.DGV_Guests.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Guests.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Guests.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Guests.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_Guests.ThemeStyle.RowsStyle.Height = 30;
            this.DGV_Guests.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Guests.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = false;
            this.labelSummary.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelSummary.Location = new System.Drawing.Point(30, 402);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(1140, 24);
            this.labelSummary.TabIndex = 5;
            this.labelSummary.Text = "Select a guest to see the bill estimate.";
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.labelCheckOut.Location = new System.Drawing.Point(30, 432);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(119, 21);
            this.labelCheckOut.TabIndex = 6;
            this.labelCheckOut.Text = "Check-out date";
            // 
            // DTP_CheckOut
            // 
            this.DTP_CheckOut.BorderColor = System.Drawing.Color.DarkGray;
            this.DTP_CheckOut.BorderRadius = 6;
            this.DTP_CheckOut.BorderThickness = 1;
            this.DTP_CheckOut.CustomFormat = "yyyy-MM-dd";
            this.DTP_CheckOut.Enabled = false;
            this.DTP_CheckOut.FillColor = System.Drawing.Color.White;
            this.DTP_CheckOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_CheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.DTP_CheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_CheckOut.Location = new System.Drawing.Point(30, 456);
            this.DTP_CheckOut.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            this.DTP_CheckOut.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DTP_CheckOut.Name = "DTP_CheckOut";
            this.DTP_CheckOut.Size = new System.Drawing.Size(210, 38);
            this.DTP_CheckOut.TabIndex = 7;
            this.DTP_CheckOut.Value = new System.DateTime(2026, 11, 11, 0, 0, 0, 0);
            this.DTP_CheckOut.ValueChanged += new System.EventHandler(this.DTP_CheckOut_ValueChanged);
            // 
            // btnCheckout
            // 
            this.btnCheckout.BorderRadius = 6;
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.Enabled = false;
            this.btnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnCheckout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(270, 450);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(170, 50);
            this.btnCheckout.TabIndex = 8;
            this.btnCheckout.Text = "Check Out";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = false;
            this.labelSelected.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.labelSelected.Location = new System.Drawing.Point(460, 456);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(710, 44);
            this.labelSelected.TabIndex = 9;
            this.labelSelected.Text = "Select a guest from the grid.";
            // 
            // UC_Guests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.Controls.Add(this.labelSelected);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.DTP_CheckOut);
            this.Controls.Add(this.labelCheckOut);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.DGV_Guests);
            this.Controls.Add(this.labelActive);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "UC_Guests";
            this.Size = new System.Drawing.Size(1200, 518);
            this.Load += new System.EventHandler(this.UC_Guests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Guests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2Button refreshbtn;
        private System.Windows.Forms.Label labelActive;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Guests;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Label labelCheckOut;
        private Guna.UI2.WinForms.Guna2DateTimePicker DTP_CheckOut;
        private Guna.UI2.WinForms.Guna2Button btnCheckout;
        private System.Windows.Forms.Label labelSelected;
    }
}
