using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    partial class UC_Booking
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
            this.pnlTotalRooms = new System.Windows.Forms.Panel();
            this.lblTotalRoomsValue = new System.Windows.Forms.Label();
            this.lblTotalRoomsTitle = new System.Windows.Forms.Label();
            this.accentTotal = new System.Windows.Forms.Panel();
            this.pnlFreeRooms = new System.Windows.Forms.Panel();
            this.lblFreeRoomsValue = new System.Windows.Forms.Label();
            this.lblFreeRoomsTitle = new System.Windows.Forms.Label();
            this.accentFree = new System.Windows.Forms.Panel();
            this.pnlBusyRooms = new System.Windows.Forms.Panel();
            this.lblBusyRoomsValue = new System.Windows.Forms.Label();
            this.lblBusyRoomsTitle = new System.Windows.Forms.Label();
            this.accentBusy = new System.Windows.Forms.Panel();
            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.lblCustomersValue = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.accentCustomers = new System.Windows.Forms.Panel();
            this.pnlStaff = new System.Windows.Forms.Panel();
            this.lblStaffValue = new System.Windows.Forms.Label();
            this.lblStaffTitle = new System.Windows.Forms.Label();
            this.accentStaff = new System.Windows.Forms.Panel();
            this.pnlTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenueValue = new System.Windows.Forms.Label();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.accentTotalRevenue = new System.Windows.Forms.Panel();
            this.pnlTodayRevenue = new System.Windows.Forms.Panel();
            this.lblTodayRevenueValue = new System.Windows.Forms.Label();
            this.lblTodayRevenueTitle = new System.Windows.Forms.Label();
            this.accentTodayRevenue = new System.Windows.Forms.Panel();
            this.labelRecent = new System.Windows.Forms.Label();
            this.DGV_RecentCustomers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTotalRooms.SuspendLayout();
            this.pnlFreeRooms.SuspendLayout();
            this.pnlBusyRooms.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            this.pnlStaff.SuspendLayout();
            this.pnlTotalRevenue.SuspendLayout();
            this.pnlTodayRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RecentCustomers)).BeginInit();
            this.SuspendLayout();
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelTitle.Location = new System.Drawing.Point(24, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(137, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "لوحة القيادة";
            //
            // labelSubtitle
            //
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSubtitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.labelSubtitle.Location = new System.Drawing.Point(26, 64);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(88, 19);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "نظرة عامة على الفندق";
            //
            // refreshbtn
            //
            this.refreshbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshbtn.BorderRadius = 10;
            this.refreshbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshbtn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.FillColor = Color.FromArgb(209, 213, 219);
            this.refreshbtn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            this.refreshbtn.FillColor = Color.FromArgb(37, 99, 235);
            this.refreshbtn.FocusedColor = Color.Empty;
            this.refreshbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.refreshbtn.ForeColor = Color.White;
            this.refreshbtn.HoverState.FillColor = Color.FromArgb(29, 78, 216);
            this.refreshbtn.Location = new System.Drawing.Point(1040, 22);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(128, 40);
            this.refreshbtn.TabIndex = 2;
            this.refreshbtn.Text = "تحديث";
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            //
            // pnlTotalRooms
            //
            this.pnlTotalRooms.BackColor = Color.White;
            this.pnlTotalRooms.Controls.Add(this.lblTotalRoomsValue);
            this.pnlTotalRooms.Controls.Add(this.lblTotalRoomsTitle);
            this.pnlTotalRooms.Controls.Add(this.accentTotal);
            this.pnlTotalRooms.Location = new System.Drawing.Point(24, 110);
            this.pnlTotalRooms.Name = "pnlTotalRooms";
            this.pnlTotalRooms.Size = new System.Drawing.Size(210, 120);
            this.pnlTotalRooms.TabIndex = 3;
            //
            // lblTotalRoomsValue
            //
            this.lblTotalRoomsValue.AutoSize = true;
            this.lblTotalRoomsValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalRoomsValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblTotalRoomsValue.Location = new System.Drawing.Point(18, 40);
            this.lblTotalRoomsValue.Name = "lblTotalRoomsValue";
            this.lblTotalRoomsValue.Size = new System.Drawing.Size(41, 47);
            this.lblTotalRoomsValue.TabIndex = 2;
            this.lblTotalRoomsValue.Text = "0";
            //
            // lblTotalRoomsTitle
            //
            this.lblTotalRoomsTitle.AutoSize = true;
            this.lblTotalRoomsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTotalRoomsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblTotalRoomsTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTotalRoomsTitle.Name = "lblTotalRoomsTitle";
            this.lblTotalRoomsTitle.Size = new System.Drawing.Size(74, 17);
            this.lblTotalRoomsTitle.TabIndex = 1;
            this.lblTotalRoomsTitle.Text = "إجمالي الغرف";
            //
            // accentTotal
            //
            this.accentTotal.BackColor = Color.FromArgb(37, 99, 235);
            this.accentTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentTotal.Location = new System.Drawing.Point(0, 0);
            this.accentTotal.Name = "accentTotal";
            this.accentTotal.Size = new System.Drawing.Size(6, 120);
            this.accentTotal.TabIndex = 0;
            //
            // pnlFreeRooms
            //
            this.pnlFreeRooms.BackColor = Color.White;
            this.pnlFreeRooms.Controls.Add(this.lblFreeRoomsValue);
            this.pnlFreeRooms.Controls.Add(this.lblFreeRoomsTitle);
            this.pnlFreeRooms.Controls.Add(this.accentFree);
            this.pnlFreeRooms.Location = new System.Drawing.Point(248, 110);
            this.pnlFreeRooms.Name = "pnlFreeRooms";
            this.pnlFreeRooms.Size = new System.Drawing.Size(210, 120);
            this.pnlFreeRooms.TabIndex = 4;
            //
            // lblFreeRoomsValue
            //
            this.lblFreeRoomsValue.AutoSize = true;
            this.lblFreeRoomsValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblFreeRoomsValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblFreeRoomsValue.Location = new System.Drawing.Point(18, 40);
            this.lblFreeRoomsValue.Name = "lblFreeRoomsValue";
            this.lblFreeRoomsValue.Size = new System.Drawing.Size(41, 47);
            this.lblFreeRoomsValue.TabIndex = 2;
            this.lblFreeRoomsValue.Text = "0";
            //
            // lblFreeRoomsTitle
            //
            this.lblFreeRoomsTitle.AutoSize = true;
            this.lblFreeRoomsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFreeRoomsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblFreeRoomsTitle.Location = new System.Drawing.Point(20, 14);
            this.lblFreeRoomsTitle.Name = "lblFreeRoomsTitle";
            this.lblFreeRoomsTitle.Size = new System.Drawing.Size(74, 17);
            this.lblFreeRoomsTitle.TabIndex = 1;
            this.lblFreeRoomsTitle.Text = "الغرف الفارغة";
            //
            // accentFree
            //
            this.accentFree.BackColor = Color.FromArgb(16, 185, 129);
            this.accentFree.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentFree.Location = new System.Drawing.Point(0, 0);
            this.accentFree.Name = "accentFree";
            this.accentFree.Size = new System.Drawing.Size(6, 120);
            this.accentFree.TabIndex = 0;
            //
            // pnlBusyRooms
            //
            this.pnlBusyRooms.BackColor = Color.White;
            this.pnlBusyRooms.Controls.Add(this.lblBusyRoomsValue);
            this.pnlBusyRooms.Controls.Add(this.lblBusyRoomsTitle);
            this.pnlBusyRooms.Controls.Add(this.accentBusy);
            this.pnlBusyRooms.Location = new System.Drawing.Point(472, 110);
            this.pnlBusyRooms.Name = "pnlBusyRooms";
            this.pnlBusyRooms.Size = new System.Drawing.Size(210, 120);
            this.pnlBusyRooms.TabIndex = 5;
            //
            // lblBusyRoomsValue
            //
            this.lblBusyRoomsValue.AutoSize = true;
            this.lblBusyRoomsValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblBusyRoomsValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblBusyRoomsValue.Location = new System.Drawing.Point(18, 40);
            this.lblBusyRoomsValue.Name = "lblBusyRoomsValue";
            this.lblBusyRoomsValue.Size = new System.Drawing.Size(41, 47);
            this.lblBusyRoomsValue.TabIndex = 2;
            this.lblBusyRoomsValue.Text = "0";
            //
            // lblBusyRoomsTitle
            //
            this.lblBusyRoomsTitle.AutoSize = true;
            this.lblBusyRoomsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBusyRoomsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblBusyRoomsTitle.Location = new System.Drawing.Point(20, 14);
            this.lblBusyRoomsTitle.Name = "lblBusyRoomsTitle";
            this.lblBusyRoomsTitle.Size = new System.Drawing.Size(85, 17);
            this.lblBusyRoomsTitle.TabIndex = 1;
            this.lblBusyRoomsTitle.Text = "الغرف المشغولة";
            //
            // accentBusy
            //
            this.accentBusy.BackColor = Color.FromArgb(239, 68, 68);
            this.accentBusy.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentBusy.Location = new System.Drawing.Point(0, 0);
            this.accentBusy.Name = "accentBusy";
            this.accentBusy.Size = new System.Drawing.Size(6, 120);
            this.accentBusy.TabIndex = 0;
            //
            // pnlCustomers
            //
            this.pnlCustomers.BackColor = Color.White;
            this.pnlCustomers.Controls.Add(this.lblCustomersValue);
            this.pnlCustomers.Controls.Add(this.lblCustomersTitle);
            this.pnlCustomers.Controls.Add(this.accentCustomers);
            this.pnlCustomers.Location = new System.Drawing.Point(696, 110);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(210, 120);
            this.pnlCustomers.TabIndex = 6;
            //
            // lblCustomersValue
            //
            this.lblCustomersValue.AutoSize = true;
            this.lblCustomersValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblCustomersValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblCustomersValue.Location = new System.Drawing.Point(18, 40);
            this.lblCustomersValue.Name = "lblCustomersValue";
            this.lblCustomersValue.Size = new System.Drawing.Size(41, 47);
            this.lblCustomersValue.TabIndex = 2;
            this.lblCustomersValue.Text = "0";
            //
            // lblCustomersTitle
            //
            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCustomersTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblCustomersTitle.Location = new System.Drawing.Point(20, 14);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Size = new System.Drawing.Size(58, 17);
            this.lblCustomersTitle.TabIndex = 1;
            this.lblCustomersTitle.Text = "العملاء";
            //
            // accentCustomers
            //
            this.accentCustomers.BackColor = Color.FromArgb(59, 130, 246);
            this.accentCustomers.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentCustomers.Location = new System.Drawing.Point(0, 0);
            this.accentCustomers.Name = "accentCustomers";
            this.accentCustomers.Size = new System.Drawing.Size(6, 120);
            this.accentCustomers.TabIndex = 0;
            //
            // pnlStaff
            //
            this.pnlStaff.BackColor = Color.White;
            this.pnlStaff.Controls.Add(this.lblStaffValue);
            this.pnlStaff.Controls.Add(this.lblStaffTitle);
            this.pnlStaff.Controls.Add(this.accentStaff);
            this.pnlStaff.Location = new System.Drawing.Point(920, 110);
            this.pnlStaff.Name = "pnlStaff";
            this.pnlStaff.Size = new System.Drawing.Size(210, 120);
            this.pnlStaff.TabIndex = 7;
            //
            // lblStaffValue
            //
            this.lblStaffValue.AutoSize = true;
            this.lblStaffValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblStaffValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblStaffValue.Location = new System.Drawing.Point(18, 40);
            this.lblStaffValue.Name = "lblStaffValue";
            this.lblStaffValue.Size = new System.Drawing.Size(41, 47);
            this.lblStaffValue.TabIndex = 2;
            this.lblStaffValue.Text = "0";
            //
            // lblStaffTitle
            //
            this.lblStaffTitle.AutoSize = true;
            this.lblStaffTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStaffTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblStaffTitle.Location = new System.Drawing.Point(20, 14);
            this.lblStaffTitle.Name = "lblStaffTitle";
            this.lblStaffTitle.Size = new System.Drawing.Size(44, 17);
            this.lblStaffTitle.TabIndex = 1;
            this.lblStaffTitle.Text = "الموظفون";
            //
            // accentStaff
            //
            this.accentStaff.BackColor = Color.FromArgb(139, 92, 246);
            this.accentStaff.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentStaff.Location = new System.Drawing.Point(0, 0);
            this.accentStaff.Name = "accentStaff";
            this.accentStaff.Size = new System.Drawing.Size(6, 120);
            this.accentStaff.TabIndex = 0;
            //
            // pnlTotalRevenue
            //
            this.pnlTotalRevenue.BackColor = Color.White;
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueValue);
            this.pnlTotalRevenue.Controls.Add(this.lblTotalRevenueTitle);
            this.pnlTotalRevenue.Controls.Add(this.accentTotalRevenue);
            this.pnlTotalRevenue.Location = new System.Drawing.Point(24, 248);
            this.pnlTotalRevenue.Name = "pnlTotalRevenue";
            this.pnlTotalRevenue.Size = new System.Drawing.Size(210, 120);
            this.pnlTotalRevenue.TabIndex = 8;
            //
            // lblTotalRevenueValue
            //
            this.lblTotalRevenueValue.AutoSize = true;
            this.lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblTotalRevenueValue.Location = new System.Drawing.Point(18, 40);
            this.lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            this.lblTotalRevenueValue.Size = new System.Drawing.Size(64, 37);
            this.lblTotalRevenueValue.TabIndex = 2;
            this.lblTotalRevenueValue.Text = "0.00";
            //
            // lblTotalRevenueTitle
            //
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTotalRevenueTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(88, 17);
            this.lblTotalRevenueTitle.TabIndex = 1;
            this.lblTotalRevenueTitle.Text = "إجمالي الإيرادات";
            //
            // accentTotalRevenue
            //
            this.accentTotalRevenue.BackColor = Color.FromArgb(212, 175, 55);
            this.accentTotalRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentTotalRevenue.Location = new System.Drawing.Point(0, 0);
            this.accentTotalRevenue.Name = "accentTotalRevenue";
            this.accentTotalRevenue.Size = new System.Drawing.Size(6, 120);
            this.accentTotalRevenue.TabIndex = 0;
            //
            // pnlTodayRevenue
            //
            this.pnlTodayRevenue.BackColor = Color.White;
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenueValue);
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenueTitle);
            this.pnlTodayRevenue.Controls.Add(this.accentTodayRevenue);
            this.pnlTodayRevenue.Location = new System.Drawing.Point(248, 248);
            this.pnlTodayRevenue.Name = "pnlTodayRevenue";
            this.pnlTodayRevenue.Size = new System.Drawing.Size(210, 120);
            this.pnlTodayRevenue.TabIndex = 9;
            //
            // lblTodayRevenueValue
            //
            this.lblTodayRevenueValue.AutoSize = true;
            this.lblTodayRevenueValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenueValue.ForeColor = Color.FromArgb(15, 23, 42);
            this.lblTodayRevenueValue.Location = new System.Drawing.Point(18, 40);
            this.lblTodayRevenueValue.Name = "lblTodayRevenueValue";
            this.lblTodayRevenueValue.Size = new System.Drawing.Size(64, 37);
            this.lblTodayRevenueValue.TabIndex = 2;
            this.lblTodayRevenueValue.Text = "0.00";
            //
            // lblTodayRevenueTitle
            //
            this.lblTodayRevenueTitle.AutoSize = true;
            this.lblTodayRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTodayRevenueTitle.ForeColor = Color.FromArgb(71, 85, 105);
            this.lblTodayRevenueTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTodayRevenueTitle.Name = "lblTodayRevenueTitle";
            this.lblTodayRevenueTitle.Size = new System.Drawing.Size(93, 17);
            this.lblTodayRevenueTitle.TabIndex = 1;
            this.lblTodayRevenueTitle.Text = "إيرادات اليوم";
            //
            // accentTodayRevenue
            //
            this.accentTodayRevenue.BackColor = Color.FromArgb(245, 158, 11);
            this.accentTodayRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.accentTodayRevenue.Location = new System.Drawing.Point(0, 0);
            this.accentTodayRevenue.Name = "accentTodayRevenue";
            this.accentTodayRevenue.Size = new System.Drawing.Size(6, 120);
            this.accentTodayRevenue.TabIndex = 0;
            //
            // labelRecent
            //
            this.labelRecent.AutoSize = true;
            this.labelRecent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelRecent.ForeColor = Color.FromArgb(15, 23, 42);
            this.labelRecent.Location = new System.Drawing.Point(24, 390);
            this.labelRecent.Name = "labelRecent";
            this.labelRecent.Size = new System.Drawing.Size(99, 21);
            this.labelRecent.TabIndex = 10;
            this.labelRecent.Text = "النشاط الأخير";
            //
            // DGV_RecentCustomers
            //
            dataGridViewCellStyle1.BackColor = Color.White;
            this.DGV_RecentCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_RecentCustomers.AllowUserToAddRows = false;
            this.DGV_RecentCustomers.AllowUserToDeleteRows = false;
            this.DGV_RecentCustomers.AllowUserToResizeRows = false;
            this.DGV_RecentCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_RecentCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_RecentCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_RecentCustomers.ColumnHeadersHeight = 32;
            this.DGV_RecentCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 246, 249);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_RecentCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_RecentCustomers.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_RecentCustomers.Location = new System.Drawing.Point(24, 420);
            this.DGV_RecentCustomers.Name = "DGV_RecentCustomers";
            this.DGV_RecentCustomers.ReadOnly = true;
            this.DGV_RecentCustomers.RowHeadersVisible = false;
            this.DGV_RecentCustomers.RowTemplate.Height = 28;
            this.DGV_RecentCustomers.Size = new System.Drawing.Size(1106, 80);
            this.DGV_RecentCustomers.TabIndex = 11;
            this.DGV_RecentCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            this.DGV_RecentCustomers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_RecentCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            this.DGV_RecentCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            this.DGV_RecentCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            this.DGV_RecentCustomers.ThemeStyle.BackColor = Color.White;
            this.DGV_RecentCustomers.ThemeStyle.GridColor = Color.FromArgb(226, 232, 240);
            this.DGV_RecentCustomers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.DGV_RecentCustomers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_RecentCustomers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.DGV_RecentCustomers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            this.DGV_RecentCustomers.ThemeStyle.HeaderStyle.Height = 32;
            this.DGV_RecentCustomers.ThemeStyle.ReadOnly = true;
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.BackColor = Color.White;
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 85, 105);
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.Height = 28;
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(243, 246, 249);
            this.DGV_RecentCustomers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            //
            // UC_Booking
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(243, 246, 249);
            this.Controls.Add(this.DGV_RecentCustomers);
            this.Controls.Add(this.labelRecent);
            this.Controls.Add(this.pnlTodayRevenue);
            this.Controls.Add(this.pnlTotalRevenue);
            this.Controls.Add(this.pnlStaff);
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.pnlBusyRooms);
            this.Controls.Add(this.pnlFreeRooms);
            this.Controls.Add(this.pnlTotalRooms);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "UC_Booking";
            this.Size = new System.Drawing.Size(1160, 518);
            this.Load += new System.EventHandler(this.UC_Booking_Load);
            this.pnlTotalRooms.ResumeLayout(false);
            this.pnlTotalRooms.PerformLayout();
            this.pnlFreeRooms.ResumeLayout(false);
            this.pnlFreeRooms.PerformLayout();
            this.pnlBusyRooms.ResumeLayout(false);
            this.pnlBusyRooms.PerformLayout();
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            this.pnlStaff.ResumeLayout(false);
            this.pnlStaff.PerformLayout();
            this.pnlTotalRevenue.ResumeLayout(false);
            this.pnlTotalRevenue.PerformLayout();
            this.pnlTodayRevenue.ResumeLayout(false);
            this.pnlTodayRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_RecentCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private Guna.UI2.WinForms.Guna2Button refreshbtn;
        private System.Windows.Forms.Panel pnlTotalRooms;
        private System.Windows.Forms.Label lblTotalRoomsValue;
        private System.Windows.Forms.Label lblTotalRoomsTitle;
        private System.Windows.Forms.Panel accentTotal;
        private System.Windows.Forms.Panel pnlFreeRooms;
        private System.Windows.Forms.Label lblFreeRoomsValue;
        private System.Windows.Forms.Label lblFreeRoomsTitle;
        private System.Windows.Forms.Panel accentFree;
        private System.Windows.Forms.Panel pnlBusyRooms;
        private System.Windows.Forms.Label lblBusyRoomsValue;
        private System.Windows.Forms.Label lblBusyRoomsTitle;
        private System.Windows.Forms.Panel accentBusy;
        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.Label lblCustomersValue;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Panel accentCustomers;
        private System.Windows.Forms.Panel pnlStaff;
        private System.Windows.Forms.Label lblStaffValue;
        private System.Windows.Forms.Label lblStaffTitle;
        private System.Windows.Forms.Panel accentStaff;
        private System.Windows.Forms.Panel pnlTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Panel accentTotalRevenue;
        private System.Windows.Forms.Panel pnlTodayRevenue;
        private System.Windows.Forms.Label lblTodayRevenueValue;
        private System.Windows.Forms.Label lblTodayRevenueTitle;
        private System.Windows.Forms.Panel accentTodayRevenue;
        private System.Windows.Forms.Label labelRecent;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_RecentCustomers;
    }
}
