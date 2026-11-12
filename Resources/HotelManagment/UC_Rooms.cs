using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Rooms : UserControl
    {
        private readonly function fn = new function();
        private int selectedRoomId;

        private DataTable roomsTable;
        private DataView roomsView;
        private Guna2TextBox searchBox;
        private Guna2ComboBox statusFilter;

        public UC_Rooms()
        {
            InitializeComponent();

            // The status column is stored in English, so the grid maps it to
            // Arabic on the fly without changing the underlying data.
            DGV_Rooms.CellFormatting += DGV_Rooms_CellFormatting;
        }

        private void UC_Rooms_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadRooms();
        }

        private void LoadRooms()
        {
            const string query = @"
                SELECT Room_ID, Room_NO, Room_Type, Bed, Price, Status
                FROM Rooms
                ORDER BY Room_NO";

            roomsTable = fn.getData(query);
            roomsView = new DataView(roomsTable);

            DGV_Rooms.DataSource = roomsView;
            ConfigureGrid();
            ApplyRoomFilter();
            ClearALL();
        }

        private void ConfigureGrid()
        {
            if (DGV_Rooms.Columns.Count == 0)
                return;

            if (DGV_Rooms.Columns["Room_ID"] != null)
                DGV_Rooms.Columns["Room_ID"].Visible = false;

            SetHeader("Room_NO", "رقم الغرفة", 90);
            SetHeader("Room_Type", "نوع الغرفة", 110);
            SetHeader("Bed", "السرير", 90);
            SetHeader("Price", "السعر", 90);
            SetHeader("Status", "الحالة", 90);

            if (DGV_Rooms.Columns["Price"] != null)
            {
                DGV_Rooms.Columns["Price"].DefaultCellStyle.Format = "N2";
                DGV_Rooms.Columns["Price"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void SetHeader(string columnName, string title, int weight)
        {
            if (DGV_Rooms.Columns[columnName] == null)
                return;

            DGV_Rooms.Columns[columnName].HeaderText = title;
            DGV_Rooms.Columns[columnName].FillWeight = weight;
        }

        private void DGV_Rooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null)
                return;

            string value = Convert.ToString(e.Value);
            if (value.Length == 0)
                return;

            string column = DGV_Rooms.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Room_Type":
                    e.Value = Localization.RoomTypeToArabic(value);
                    e.FormattingApplied = true;
                    break;
                case "Bed":
                    e.Value = Localization.BedToArabic(value);
                    e.FormattingApplied = true;
                    break;
                case "Status":
                    e.Value = Localization.StatusToArabic(value);
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void ApplyRoomFilter()
        {
            if (roomsView == null)
                return;

            string search = (searchBox == null ? string.Empty : searchBox.Text).Trim();
            search = search.Replace("'", "''");

            string filter = string.Empty;

            if (search.Length > 0)
                filter = "Room_NO LIKE '%" + search + "%'";

            int statusIndex = statusFilter == null ? 0 : statusFilter.SelectedIndex;
            string status = statusIndex == 1 ? "Free" : statusIndex == 2 ? "Busy" : null;

            if (status != null)
            {
                string statusFilterText = "Status = '" + status + "'";
                filter = filter.Length == 0 ? statusFilterText : filter + " AND " + statusFilterText;
            }

            roomsView.RowFilter = filter;
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            ApplyRoomFilter();
        }

        private void ClearALL()
        {
            selectedRoomId = 0;
            txtRoomNumber.Clear();
            cmBoxRoomType.SelectedIndex = -1;
            cmboxBed.SelectedIndex = -1;
            txtPrice.Clear();
            cmBoxStatus.SelectedIndex = 0; // A new room starts as Free.

            if (DGV_Rooms.DataSource != null)
                DGV_Rooms.ClearSelection();

            UpdateButtonStates();
            labelHint.Text = "اختر غرفة من الجدول لتعديلها أو حذفها.";
        }

        private void UpdateButtonStates()
        {
            addbtn.Enabled = selectedRoomId <= 0;
            editbtn.Enabled = selectedRoomId > 0;
            deletebtn.Enabled = selectedRoomId > 0;
        }

        private void DGV_Rooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = DGV_Rooms.Rows[e.RowIndex];

            if (row.Cells["Room_ID"].Value == null || row.Cells["Room_ID"].Value == DBNull.Value)
                return;

            selectedRoomId = Convert.ToInt32(row.Cells["Room_ID"].Value);

            txtRoomNumber.Text = Convert.ToString(row.Cells["Room_NO"].Value);
            SelectComboValue(cmBoxRoomType, Localization.RoomTypeToArabic(Convert.ToString(row.Cells["Room_Type"].Value)));
            SelectComboValue(cmboxBed, Localization.BedToArabic(Convert.ToString(row.Cells["Bed"].Value)));
            txtPrice.Text = Convert.ToDecimal(row.Cells["Price"].Value).ToString("N2");
            SelectComboValue(cmBoxStatus, Localization.StatusToArabic(Convert.ToString(row.Cells["Status"].Value)));

            UpdateButtonStates();
            labelHint.Text = "تعديل الغرفة " + txtRoomNumber.Text +
                             " (الرقم " + selectedRoomId + ").";
            txtRoomNumber.Focus();
        }

        private static void SelectComboValue(Guna2ComboBox combo, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                combo.SelectedIndex = -1;
                return;
            }

            // Legacy data may contain a value that is not in the fixed list.
            if (!combo.Items.Contains(value))
                combo.Items.Add(value);

            combo.SelectedItem = value;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateRoomInput(out decimal price, out string roomNo))
                return;

            // Friendly early check; the UNIQUE constraint remains the final guard.
            if (fn.RoomNumberExists(roomNo, 0))
            {
                Fail("رقم الغرفة موجود بالفعل.", txtRoomNumber);
                return;
            }

            const string query = @"
                INSERT INTO Rooms (Room_NO, Room_Type, Bed, Price, Status)
                VALUES (@roomNo, @roomType, @bed, @price, @status)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo },
                new SqlParameter("@roomType", SqlDbType.VarChar, 10) { Value = Localization.RoomTypeToDatabase(cmBoxRoomType.Text) },
                new SqlParameter("@bed", SqlDbType.VarChar, 10) { Value = Localization.BedToDatabase(cmboxBed.Text) },
                new SqlParameter("@price", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = price },
                new SqlParameter("@status", SqlDbType.VarChar, 5) { Value = Localization.StatusToDatabase(cmBoxStatus.Text) }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("تمت إضافة الغرفة.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else if (affected == 0)
            {
                MessageBox.Show("لم تتم إضافة أي غرفة.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show("اختر غرفة من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateRoomInput(out decimal price, out string roomNo))
                return;

            if (fn.RoomNumberExists(roomNo, selectedRoomId))
            {
                Fail("رقم الغرفة موجود بالفعل.", txtRoomNumber);
                return;
            }

            string error;
            bool updated = fn.UpdateRoom(
                selectedRoomId,
                roomNo,
                Localization.RoomTypeToDatabase(cmBoxRoomType.Text),
                Localization.BedToDatabase(cmboxBed.Text),
                price,
                Localization.StatusToDatabase(cmBoxStatus.Text),
                out error);

            if (updated)
            {
                MessageBox.Show("تم تحديث بيانات الغرفة.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(LocalizeRoomError(error) ?? "تعذّر تحديث الغرفة.",
                    "فشل التحديث", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show("اختر غرفة من الجدول أولاً.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string roomNo = (txtRoomNumber.Text ?? string.Empty).Trim();

            if (MessageBox.Show("هل تريد حذف الغرفة " + roomNo + "؟\n\n" +
                    "لا يمكن حذف الغرف التي لها سجل نزلاء.",
                    "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            string error;
            bool deleted = fn.DeleteRoom(selectedRoomId, out error);

            if (deleted)
            {
                MessageBox.Show("تم حذف الغرفة.", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(LocalizeRoomError(error) ?? "تعذّر حذف الغرفة.",
                    "فشل الحذف", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string LocalizeRoomError(string error)
        {
            if (string.IsNullOrEmpty(error))
                return null;

            if (error == "Room not found.")
                return "الغرفة غير موجودة.";
            if (error == "This room is occupied. Check out the guest before changing its status.")
                return "الغرفة مشغولة. سجل خروج النزيل قبل تغيير حالتها.";
            if (error == "This room is occupied. Check out the guest first.")
                return "الغرفة مشغولة. سجل خروج النزيل أولاً.";
            if (error == "This room is marked Busy. Set it to Free before deleting it.")
                return "الغرفة مشغولة. اجعلها شاغرة قبل حذفها.";
            if (error == "This room has customer history and cannot be deleted. Keep it for reporting.")
                return "لا يمكن حذف الغرفة؛ لها سجل نزلاء. يُحتفظ بها للتقارير.";

            return error;
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearALL();
        }

        private bool ValidateRoomInput(out decimal price, out string roomNo)
        {
            price = 0;
            roomNo = (txtRoomNumber.Text ?? string.Empty).Trim();

            if (roomNo.Length == 0)
                return Fail("رقم الغرفة مطلوب.", txtRoomNumber);

            if (roomNo.Length > 10)
                return Fail("رقم الغرفة لا يتجاوز 10 أحرف.", txtRoomNumber);

            if (!Regex.IsMatch(roomNo, @"^[A-Za-z0-9\-]+$"))
                return Fail("رقم الغرفة يقبل الحروف والأرقام والشرطة فقط.", txtRoomNumber);

            if (cmBoxRoomType.SelectedIndex < 0)
                return Fail("اختر نوع الغرفة.", cmBoxRoomType);

            if (cmboxBed.SelectedIndex < 0)
                return Fail("اختر نوع السرير.", cmboxBed);

            if (cmBoxStatus.SelectedIndex < 0)
                return Fail("اختر حالة الغرفة.", cmBoxStatus);

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0 || price > 1000000m)
                return Fail("السعر يجب أن يكون رقماً بين 0 و 1,000,000.", txtPrice);

            return true;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "تحقق",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        private void ApplyTheme()
        {
            Theme.StyleScreenTitle(labelTitle);
            Theme.StyleScreenSubtitle(labelSubtitle);

            labelHint.ForeColor = Theme.TextMuted;
            labelHint.Font = new Font("Segoe UI", 8.5F);

            Theme.StyleInput(txtRoomNumber);
            Theme.StyleInput(txtPrice);
            Theme.StyleCombo(cmBoxRoomType);
            Theme.StyleCombo(cmboxBed);
            Theme.StyleCombo(cmBoxStatus);

            Theme.StyleActionButton(addbtn, true);
            Theme.StyleActionButton(editbtn, true);
            Theme.StyleDangerButton(deletebtn);
            Theme.StyleActionButton(clearbtn, false);

            label1.ForeColor = Theme.TextSecondary;
            label5.ForeColor = Theme.TextSecondary;
            label6.ForeColor = Theme.TextSecondary;
            label2.ForeColor = Theme.TextSecondary;

            label1.Font = new Font("Segoe UI", 9.5F);
            label5.Font = new Font("Segoe UI", 9.5F);
            label6.Font = new Font("Segoe UI", 9.5F);
            label2.Font = new Font("Segoe UI", 9.5F);

            SetComboItems(cmBoxRoomType, new[] { "فردية", "مزدوجة", "توأم", "ثلاثية", "جناح" });
            SetComboItems(cmboxBed, new[] { "فردي", "مزدوج", "كوين", "كينغ", "توأم", "بطابقين" });
            SetComboItems(cmBoxStatus, new[] { "شاغرة", "مشغولة" });

            Theme.AddCard(this, new Rectangle(16, 84, 264, 420));

            if (searchBox == null)
            {
                searchBox = Theme.AddSearchBox(this, new Point(700, 24), new Size(290, 40),
                    "ابحث برقم الغرفة...", SearchChanged);

                statusFilter = Theme.AddFilterCombo(this, new Point(1006, 24), new Size(162, 40),
                    new[] { "كل الحالات", "شاغرة", "مشغولة" }, SearchChanged);

                statusFilter.SelectedIndex = 0;
            }

            Theme.AlignFieldLabels(this);
        }

        private static void SetComboItems(Guna2ComboBox combo, string[] items)
        {
            string current = combo.Text;

            combo.Items.Clear();
            combo.Items.AddRange(items);

            if (!string.IsNullOrEmpty(current) && combo.Items.Contains(current))
                combo.SelectedItem = current;
        }
    }
}
