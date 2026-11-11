using System;
using System.Data;
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

                labelSubtitle.Text = "Active guests: " + activeCustomers +
                                     "   |   Updated " + DateTime.Now.ToString("HH:mm");

                DGV_RecentCustomers.DataSource = fn.GetRecentCustomers(10);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
