using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Guests : UserControl
    {
        private readonly function fn = new function();

        private int selectedCustomerId;
        private string selectedName;
        private string selectedRoom;
        private DateTime selectedCheckIn;
        private decimal selectedRate;

        public UC_Guests()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void UC_Guests_Load(object sender, EventArgs e)
        {
            ResetSelection();
            LoadGuests();
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            LoadGuests();
        }

        private void LoadGuests()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DGV_Guests.DataSource = fn.GetActiveCustomers();
                ConfigureGrid();
                ResetSelection();

                int count = DGV_Guests.Rows.Count;
                labelSubtitle.Text = count == 0
                    ? "No active guests."
                    : count + (count == 1 ? " active guest." : " active guests.") +
                      " Select a row to check out.";
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("The guest list could not be loaded.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ConfigureGrid()
        {
            if (DGV_Guests.Columns["Customer_ID"] != null)
                DGV_Guests.Columns["Customer_ID"].Visible = false;

            SetWeight("Customer", 160);
            SetWeight("Mobile", 100);
            SetWeight("Room", 65);
            SetWeight("Check In", 90);
            SetWeight("Nights", 55);
            SetWeight("Rate", 80);
            SetWeight("Est. Total", 90);

            if (DGV_Guests.Columns["Check In"] != null)
                DGV_Guests.Columns["Check In"].DefaultCellStyle.Format = "yyyy-MM-dd";

            if (DGV_Guests.Columns["Rate"] != null)
            {
                DGV_Guests.Columns["Rate"].DefaultCellStyle.Format = "N2";
                DGV_Guests.Columns["Rate"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }

            if (DGV_Guests.Columns["Est. Total"] != null)
            {
                DGV_Guests.Columns["Est. Total"].DefaultCellStyle.Format = "N2";
                DGV_Guests.Columns["Est. Total"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void SetWeight(string columnName, int weight)
        {
            if (DGV_Guests.Columns[columnName] != null)
                DGV_Guests.Columns[columnName].FillWeight = weight;
        }

        private void ResetSelection()
        {
            selectedCustomerId = 0;
            selectedName = null;
            selectedRoom = null;
            selectedCheckIn = DateTime.Today;
            selectedRate = 0;

            if (DGV_Guests.DataSource != null)
                DGV_Guests.ClearSelection();

            DTP_CheckOut.Enabled = false;
            DTP_CheckOut.MinDate = new DateTime(1900, 1, 1);
            DTP_CheckOut.MaxDate = DateTime.Today;
            DTP_CheckOut.Value = DateTime.Today;

            btnCheckout.Enabled = false;
            labelSelected.Text = "Select a guest from the grid.";
            labelSummary.Text = "Select a guest to see the bill estimate.";
        }

        private void DGV_Guests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = DGV_Guests.Rows[e.RowIndex];

            if (row.Cells["Customer_ID"].Value == null ||
                row.Cells["Customer_ID"].Value == DBNull.Value)
            {
                return;
            }

            selectedCustomerId = Convert.ToInt32(row.Cells["Customer_ID"].Value);
            selectedName = Convert.ToString(row.Cells["Customer"].Value);
            selectedRoom = Convert.ToString(row.Cells["Room"].Value);
            selectedCheckIn = Convert.ToDateTime(row.Cells["Check In"].Value).Date;
            selectedRate = Convert.ToDecimal(row.Cells["Rate"].Value);

            labelSelected.Text = selectedName + " | Room " + selectedRoom +
                                 " | Check-in " + selectedCheckIn.ToString("yyyy-MM-dd");

            if (selectedCheckIn > DateTime.Today)
            {
                labelSummary.Text =
                    "This guest's check-in date is in the future; check-out is not available yet.";
                btnCheckout.Enabled = false;
                DTP_CheckOut.Enabled = false;
                return;
            }

            DTP_CheckOut.Enabled = true;
            DTP_CheckOut.MinDate = selectedCheckIn;
            DTP_CheckOut.MaxDate = DateTime.Today;
            DTP_CheckOut.Value = DateTime.Today;

            UpdateEstimate();
            btnCheckout.Enabled = true;
        }

        private void DTP_CheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (selectedCustomerId > 0)
                UpdateEstimate();
        }

        private void UpdateEstimate()
        {
            DateTime checkOut = DTP_CheckOut.Value.Date;
            int nights = (checkOut - selectedCheckIn).Days;

            if (nights < 1)
                nights = 1;

            decimal total = nights * selectedRate;

            labelSummary.Text = "Nights: " + nights +
                                "   |   Rate: " + selectedRate.ToString("N2") +
                                "   |   Estimated total: " + total.ToString("N2");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("Select a guest from the grid first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime checkOut = DTP_CheckOut.Value.Date;

            if (checkOut < selectedCheckIn)
            {
                MessageBox.Show("The check-out date cannot be before the check-in date.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut > DateTime.Today)
            {
                MessageBox.Show("The check-out date cannot be in the future.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nights = (checkOut - selectedCheckIn).Days;
            if (nights < 1)
                nights = 1;

            decimal total = nights * selectedRate;

            string confirmation =
                "Check out this guest?\n\n" +
                "Guest: " + selectedName + "\n" +
                "Room: " + selectedRoom + "\n" +
                "Check-in: " + selectedCheckIn.ToString("yyyy-MM-dd") + "\n" +
                "Check-out: " + checkOut.ToString("yyyy-MM-dd") + "\n" +
                "Nights: " + nights + "\n" +
                "Rate: " + selectedRate.ToString("N2") + "\n" +
                "Total: " + total.ToString("N2") + "\n\n" +
                "The room will be marked as Free.";

            if (MessageBox.Show(confirmation, "Confirm Check-out",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btnCheckout.Enabled = false;

                CheckoutResult result;
                string error;

                if (fn.CheckoutCustomer(selectedCustomerId, checkOut, out result, out error))
                {
                    MessageBox.Show(
                        "Check-out complete.\n\n" +
                        "Guest: " + result.CustomerName + "\n" +
                        "Room: " + result.RoomNo + "\n" +
                        "Nights: " + result.Nights + "\n" +
                        "Rate: " + result.Rate.ToString("N2") + "\n" +
                        "Total: " + result.Total.ToString("N2"),
                        "Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(error ?? "The guest could not be checked out.",
                        "Check-out Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadGuests();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("The guest could not be checked out.",
                    "Check-out Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadGuests();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplyTheme()
        {
            labelTitle.ForeColor = Theme.TextPrimary;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

            labelSubtitle.ForeColor = Theme.TextSecondary;
            labelSubtitle.Font = new Font("Segoe UI", 10F);

            labelActive.ForeColor = Theme.TextPrimary;
            labelActive.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            Theme.StyleActionButton(refreshbtn, true);

            Theme.StyleDangerButton(btnCheckout);

            labelSelected.ForeColor = Theme.TextPrimary;
            labelSelected.Font = new Font("Segoe UI", 9.5F);

            labelCheckOut.ForeColor = Theme.TextSecondary;
            labelCheckOut.Font = new Font("Segoe UI", 9.5F);

            labelSummary.ForeColor = Theme.TextSecondary;
            labelSummary.Font = new Font("Segoe UI", 9.5F);
        }
    }
}
