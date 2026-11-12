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

        private DataView guestsView;
        private Guna2TextBox searchBox;

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

                DataTable guests = fn.GetActiveCustomers();
                guestsView = new DataView(guests);

                DGV_Guests.DataSource = guestsView;
                ConfigureGrid();
                ApplyGuestFilter();
                ResetSelection();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("تعذّر تحميل قائمة النزلاء.",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SetHeader("Customer", "الضيف", 160);
            SetHeader("Mobile", "الجوال", 100);
            SetHeader("Room", "الغرفة", 65);
            SetHeader("Check In", "تاريخ الوصول", 90);
            SetHeader("Nights", "الليالي", 55);
            SetHeader("Rate", "سعر الليلة", 80);
            SetHeader("Est. Total", "الإجمالي التقديري", 90);

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

        private void SetHeader(string columnName, string title, int weight)
        {
            if (DGV_Guests.Columns[columnName] == null)
                return;

            DGV_Guests.Columns[columnName].HeaderText = title;
            DGV_Guests.Columns[columnName].FillWeight = weight;
        }

        private void ApplyGuestFilter()
        {
            if (guestsView == null)
                return;

            string search = (searchBox == null ? string.Empty : searchBox.Text).Trim();
            search = search.Replace("'", "''");

            guestsView.RowFilter = search.Length == 0
                ? string.Empty
                : "Customer LIKE '%" + search + "%' OR Mobile LIKE '%" + search +
                  "%' OR Convert(Room, 'System.String') LIKE '%" + search + "%'";

            int count = DGV_Guests.Rows.Count;

            labelSubtitle.Text = count == 0
                ? "لا يوجد نزلاء نشطون مطابقون للبحث."
                : "النزلاء النشطون: " + count + " — اختر صفاً لتسجيل المغادرة.";
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            ApplyGuestFilter();
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
            labelSelected.Text = "اختر نزيلاً من الجدول.";
            labelSummary.Text = "اختر نزيلاً لعرض تقدير الفاتورة.";
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

            labelSelected.Text = selectedName + " | الغرفة " + selectedRoom +
                                 " | الوصول " + selectedCheckIn.ToString("yyyy-MM-dd");

            if (selectedCheckIn > DateTime.Today)
            {
                labelSummary.Text =
                    "تاريخ وصول هذا النزيل في المستقبل؛ تسجيل المغادرة غير متاح بعد.";
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

            labelSummary.Text = "الليالي: " + nights +
                                "   |   سعر الليلة: " + selectedRate.ToString("N2") +
                                "   |   الإجمالي التقديري: " + total.ToString("N2");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show("اختر نزيلاً من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime checkOut = DTP_CheckOut.Value.Date;

            if (checkOut < selectedCheckIn)
            {
                MessageBox.Show("تاريخ المغادرة لا يكون قبل تاريخ الوصول.",
                    "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut > DateTime.Today)
            {
                MessageBox.Show("تاريخ المغادرة لا يكون في المستقبل.",
                    "تحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nights = (checkOut - selectedCheckIn).Days;
            if (nights < 1)
                nights = 1;

            decimal total = nights * selectedRate;

            string confirmation =
                "هل تريد تسجيل مغادرة هذا النزيل؟\n\n" +
                "الضيف: " + selectedName + "\n" +
                "الغرفة: " + selectedRoom + "\n" +
                "الوصول: " + selectedCheckIn.ToString("yyyy-MM-dd") + "\n" +
                "المغادرة: " + checkOut.ToString("yyyy-MM-dd") + "\n" +
                "الليالي: " + nights + "\n" +
                "سعر الليلة: " + selectedRate.ToString("N2") + "\n" +
                "الإجمالي: " + total.ToString("N2") + "\n\n" +
                "ستصبح الغرفة شاغرة.";

            if (MessageBox.Show(confirmation, "تأكيد المغادرة",
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
                        "تم تسجيل المغادرة.\n\n" +
                        "الضيف: " + result.CustomerName + "\n" +
                        "الغرفة: " + result.RoomNo + "\n" +
                        "الليالي: " + result.Nights + "\n" +
                        "سعر الليلة: " + result.Rate.ToString("N2") + "\n" +
                        "الإجمالي: " + result.Total.ToString("N2"),
                        "الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(error ?? "تعذّر تسجيل مغادرة النزيل.",
                        "فشل تسجيل المغادرة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadGuests();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show("تعذّر تسجيل مغادرة النزيل.",
                    "فشل تسجيل المغادرة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadGuests();
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

            labelActive.ForeColor = Theme.TextPrimary;
            labelActive.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            Theme.StyleActionButton(refreshbtn, true);

            Theme.StyleDangerButton(btnCheckout);
            Theme.StyleDatePicker(DTP_CheckOut);

            labelSelected.ForeColor = Theme.TextPrimary;
            labelSelected.Font = new Font("Segoe UI", 9.5F);

            labelCheckOut.ForeColor = Theme.TextSecondary;
            labelCheckOut.Font = new Font("Segoe UI", 9.5F);

            labelSummary.ForeColor = Theme.TextSecondary;
            labelSummary.Font = new Font("Segoe UI", 9.5F);

            Theme.AddCard(this, new Rectangle(16, 360, 1168, 120));

            if (searchBox == null)
            {
                searchBox = Theme.AddSearchBox(this, new Point(700, 22), new Size(320, 40),
                    "ابحث بالاسم أو الجوال أو الغرفة...", SearchChanged);
            }

            Theme.AlignFieldLabels(this);
        }
    }
}
