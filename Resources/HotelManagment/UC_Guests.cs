using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Guests : UserControl, ILocalizable
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
            ApplyLanguage();
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
                MessageBox.Show(Language.T("تعذّر تحميل قائمة النزلاء.", "Could not load the guest list."),
                    Language.T("خطأ", "Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            SetHeader("Customer", Language.T("الضيف", "Guest"), 160);
            SetHeader("Mobile", Language.T("الجوال", "Mobile"), 100);
            SetHeader("Room", Language.T("الغرفة", "Room"), 65);
            SetHeader("Check In", Language.T("تاريخ الوصول", "Check-in"), 90);
            SetHeader("Nights", Language.T("الليالي", "Nights"), 55);
            SetHeader("Rate", Language.T("سعر الليلة", "Nightly rate"), 80);
            SetHeader("Est. Total", Language.T("الإجمالي التقديري", "Est. total"), 90);

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
                ? Language.T("لا يوجد نزلاء نشطون مطابقون للبحث.", "No active guests match the search.")
                : Language.T("النزلاء النشطون: ", "Active guests: ") + count +
                  Language.T(" — اختر صفاً لتسجيل المغادرة.", " — select a row to check out.");
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
            labelSelected.Text = Language.T("اختر نزيلاً من الجدول.", "Select a guest from the grid.");
            labelSummary.Text = Language.T("اختر نزيلاً لعرض تقدير الفاتورة.",
                "Select a guest to see the bill estimate.");
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

            labelSelected.Text = selectedName + Language.T(" | الغرفة ", " | Room ") + selectedRoom +
                                 Language.T(" | الوصول ", " | Check-in ") + selectedCheckIn.ToString("yyyy-MM-dd");

            if (selectedCheckIn > DateTime.Today)
            {
                labelSummary.Text = Language.T(
                    "تاريخ وصول هذا النزيل في المستقبل؛ تسجيل المغادرة غير متاح بعد.",
                    "This guest's check-in date is in the future; check-out is not available yet.");
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

            labelSummary.Text = Language.T("الليالي: ", "Nights: ") + nights +
                                Language.T("   |   سعر الليلة: ", "   |   Nightly rate: ") +
                                selectedRate.ToString("N2") +
                                Language.T("   |   الإجمالي التقديري: ", "   |   Est. total: ") +
                                total.ToString("N2");
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId <= 0)
            {
                MessageBox.Show(Language.T("اختر نزيلاً من الجدول أولاً.",
                        "Select a guest from the grid first."),
                    Language.T("تنبيه", "Notice"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime checkOut = DTP_CheckOut.Value.Date;

            if (checkOut < selectedCheckIn)
            {
                MessageBox.Show(Language.T("تاريخ المغادرة لا يكون قبل تاريخ الوصول.",
                        "Check-out cannot be before check-in."),
                    Language.T("تحقق", "Validation"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut > DateTime.Today)
            {
                MessageBox.Show(Language.T("تاريخ المغادرة لا يكون في المستقبل.",
                        "Check-out cannot be in the future."),
                    Language.T("تحقق", "Validation"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nights = (checkOut - selectedCheckIn).Days;
            if (nights < 1)
                nights = 1;

            decimal total = nights * selectedRate;

            string confirmation =
                Language.T("هل تريد تسجيل مغادرة هذا النزيل؟", "Check out this guest?") + "\n\n" +
                Language.T("الضيف: ", "Guest: ") + selectedName + "\n" +
                Language.T("الغرفة: ", "Room: ") + selectedRoom + "\n" +
                Language.T("الوصول: ", "Check-in: ") + selectedCheckIn.ToString("yyyy-MM-dd") + "\n" +
                Language.T("المغادرة: ", "Check-out: ") + checkOut.ToString("yyyy-MM-dd") + "\n" +
                Language.T("الليالي: ", "Nights: ") + nights + "\n" +
                Language.T("سعر الليلة: ", "Nightly rate: ") + selectedRate.ToString("N2") + "\n" +
                Language.T("الإجمالي: ", "Total: ") + total.ToString("N2") + "\n\n" +
                Language.T("ستصبح الغرفة شاغرة.", "The room will become free.");

            if (MessageBox.Show(confirmation, Language.T("تأكيد المغادرة", "Confirm check-out"),
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
                        Language.T("تم تسجيل المغادرة.", "Check-out completed.") + "\n\n" +
                        Language.T("الضيف: ", "Guest: ") + result.CustomerName + "\n" +
                        Language.T("الغرفة: ", "Room: ") + result.RoomNo + "\n" +
                        Language.T("الليالي: ", "Nights: ") + result.Nights + "\n" +
                        Language.T("سعر الليلة: ", "Nightly rate: ") + result.Rate.ToString("N2") + "\n" +
                        Language.T("الإجمالي: ", "Total: ") + result.Total.ToString("N2"),
                        Language.T("الفاتورة", "Bill"),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(LocalizeCheckoutError(error) ??
                            Language.T("تعذّر تسجيل مغادرة النزيل.", "Could not check out the guest."),
                        Language.T("فشل تسجيل المغادرة", "Check-out Failed"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                LoadGuests();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(Language.T("تعذّر تسجيل مغادرة النزيل.", "Could not check out the guest."),
                    Language.T("فشل تسجيل المغادرة", "Check-out Failed"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Language.T("ابحث بالاسم أو الجوال أو الغرفة...",
                               "Search by name, mobile or room..."), SearchChanged);
            }

            Theme.AlignFieldLabels(this);
        }

        public void ApplyLanguage()
        {
            labelTitle.Text = Language.T("الضيوف والمغادرة", "Guests and check-out");
            labelSubtitle.Text = Language.T("إدارة النزلاء وتسجيل المغادرة",
                                            "Manage guests and check them out");

            labelActive.Text = Language.T("الضيوف النشطون", "Active guests");
            refreshbtn.Text = Language.T("تحديث", "Refresh");
            labelCheckOut.Text = Language.T("تاريخ المغادرة", "Check-out date");
            btnCheckout.Text = Language.T("تسجيل المغادرة", "Check out");

            if (searchBox != null)
                searchBox.PlaceholderText = Language.T(
                    "ابحث بالاسم أو الجوال أو الغرفة...",
                    "Search by name, mobile or room...");

            if (selectedCustomerId > 0)
            {
                labelSelected.Text = selectedName + Language.T(" | الغرفة ", " | Room ") + selectedRoom +
                                     Language.T(" | الوصول ", " | Check-in ") +
                                     selectedCheckIn.ToString("yyyy-MM-dd");

                if (DTP_CheckOut.Enabled)
                    UpdateEstimate();
            }
            else
            {
                labelSelected.Text = Language.T("اختر نزيلاً من الجدول.",
                                                "Select a guest from the grid.");
                labelSummary.Text = Language.T("اختر نزيلاً لعرض تقدير الفاتورة.",
                                                "Select a guest to see the bill estimate.");
            }

            ConfigureGrid();
            ApplyGuestFilter();
        }

        private static string LocalizeCheckoutError(string error)
        {
            if (string.IsNullOrEmpty(error) || !Language.IsArabic)
                return error;

            if (error == "Customer not found.")
                return "النزيل غير موجود.";
            if (error == "This guest has already been checked out.")
                return "هذا النزيل سُجّلت مغادرته بالفعل.";
            if (error == "Check-out date cannot be before the check-in date.")
                return "تاريخ المغادرة لا يكون قبل تاريخ الوصول.";
            if (error == "Check-out date cannot be in the future.")
                return "تاريخ المغادرة لا يكون في المستقبل.";

            return error;
        }
    }
}
