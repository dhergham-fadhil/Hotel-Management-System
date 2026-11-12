using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Booking : UserControl
    {
        private readonly function fn = new function();

        public UC_Booking()
        {
            InitializeComponent();
        }

        private void UC_Booking_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadDashboard();
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int activeCustomers = 0;
                DataTable statistics = fn.GetDashboardStatistics();

                foreach (DataRow row in statistics.Rows)
                {
                    string metric = Convert.ToString(row["Metric"]);
                    int value = Convert.ToInt32(row["Value"]);

                    switch (metric)
                    {
                        case "TotalRooms":
                            lblTotalRoomsValue.Text = value.ToString();
                            break;
                        case "FreeRooms":
                            lblFreeRoomsValue.Text = value.ToString();
                            break;
                        case "BusyRooms":
                            lblBusyRoomsValue.Text = value.ToString();
                            break;
                        case "TotalCustomers":
                            lblCustomersValue.Text = value.ToString();
                            break;
                        case "ActiveCustomers":
                            activeCustomers = value;
                            break;
                        case "TotalStaff":
                            lblStaffValue.Text = value.ToString();
                            break;
                    }
                }

                DataTable billing = fn.GetBillingSummary();
                decimal totalRevenue = 0;
                decimal todayRevenue = 0;

                if (billing.Rows.Count > 0)
                {
                    totalRevenue = Convert.ToDecimal(billing.Rows[0]["TotalRevenue"]);
                    todayRevenue = Convert.ToDecimal(billing.Rows[0]["TodayRevenue"]);
                }

                lblTotalRevenueValue.Text = totalRevenue.ToString("N2");
                lblTodayRevenueValue.Text = todayRevenue.ToString("N2");

                labelSubtitle.Text = "نزلاء نشطون: " + activeCustomers +
                                     "   |   الإيرادات: " + totalRevenue.ToString("N2") +
                                     "   |   محدث: " + DateTime.Now.ToString("HH:mm");

                DGV_RecentCustomers.DataSource = fn.GetRecentCustomers(10);

                if (DGV_RecentCustomers.Columns["Customer"] != null)
                    DGV_RecentCustomers.Columns["Customer"].HeaderText = "الضيف";
                if (DGV_RecentCustomers.Columns["Room"] != null)
                    DGV_RecentCustomers.Columns["Room"].HeaderText = "الغرفة";
                if (DGV_RecentCustomers.Columns["Check In"] != null)
                {
                    DGV_RecentCustomers.Columns["Check In"].HeaderText = "تسجيل الوصول";
                    DGV_RecentCustomers.Columns["Check In"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
                if (DGV_RecentCustomers.Columns["Check Out"] != null)
                {
                    DGV_RecentCustomers.Columns["Check Out"].HeaderText = "تسجيل المغادرة";
                    DGV_RecentCustomers.Columns["Check Out"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }
                if (DGV_RecentCustomers.Columns["Nights"] != null)
                {
                    DGV_RecentCustomers.Columns["Nights"].HeaderText = "ليالي";
                    DGV_RecentCustomers.Columns["Nights"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
                if (DGV_RecentCustomers.Columns["Bill"] != null)
                {
                    DGV_RecentCustomers.Columns["Bill"].HeaderText = "الفاتورة";
                    DGV_RecentCustomers.Columns["Bill"].DefaultCellStyle.Format = "N2";
                    DGV_RecentCustomers.Columns["Bill"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
                if (DGV_RecentCustomers.Columns["Status"] != null)
                    DGV_RecentCustomers.Columns["Status"].HeaderText = "الحالة";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplyTheme()
        {
            Theme.StyleScreenTitle(labelTitle);
            Theme.StyleScreenSubtitle(labelSubtitle);

            // Refresh button
            Theme.StyleActionButton(refreshbtn, true);

            // Cards
            Theme.StyleCard(pnlTotalRooms);
            Theme.StyleCard(pnlFreeRooms);
            Theme.StyleCard(pnlBusyRooms);
            Theme.StyleCard(pnlCustomers);
            Theme.StyleCard(pnlStaff);
            Theme.StyleCard(pnlTotalRevenue);
            Theme.StyleCard(pnlTodayRevenue);

            // A hairline border gives every KPI card the same crisp edge as a
            // rounded card without changing the panel type.
            pnlTotalRooms.Paint += DrawCardBorder;
            pnlFreeRooms.Paint += DrawCardBorder;
            pnlBusyRooms.Paint += DrawCardBorder;
            pnlCustomers.Paint += DrawCardBorder;
            pnlStaff.Paint += DrawCardBorder;
            pnlTotalRevenue.Paint += DrawCardBorder;
            pnlTodayRevenue.Paint += DrawCardBorder;

            // Card titles
            Theme.StyleSmall(lblTotalRoomsTitle);
            Theme.StyleSmall(lblFreeRoomsTitle);
            Theme.StyleSmall(lblBusyRoomsTitle);
            Theme.StyleSmall(lblCustomersTitle);
            Theme.StyleSmall(lblStaffTitle);
            Theme.StyleSmall(lblTotalRevenueTitle);
            Theme.StyleSmall(lblTodayRevenueTitle);

            // Recent section
            Theme.StyleHeading(labelRecent);
        }

        private static void DrawCardBorder(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel == null)
                return;

            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                Theme.Border, ButtonBorderStyle.Solid);
        }
    }
}
