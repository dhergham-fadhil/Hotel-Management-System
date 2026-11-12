using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Rooms : UserControl, ILocalizable
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
            ApplyLanguage();
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

            SetHeader("Room_NO", Language.T("رقم الغرفة", "Room number"), 90);
            SetHeader("Room_Type", Language.T("نوع الغرفة", "Room type"), 110);
            SetHeader("Bed", Language.T("السرير", "Bed"), 90);
            SetHeader("Price", Language.T("السعر", "Price"), 90);
            SetHeader("Status", Language.T("الحالة", "Status"), 90);

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
                    e.Value = Localization.RoomTypeDisplay(value);
                    e.FormattingApplied = true;
                    break;
                case "Bed":
                    e.Value = Localization.BedDisplay(value);
                    e.FormattingApplied = true;
                    break;
                case "Status":
                    e.Value = Localization.StatusDisplay(value);
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
            labelHint.Text = Language.T("اختر غرفة من الجدول لتعديلها أو حذفها.",
                "Select a room from the grid to edit or delete it.");
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
            SelectComboValue(cmBoxRoomType, Localization.RoomTypeDisplay(Convert.ToString(row.Cells["Room_Type"].Value)));
            SelectComboValue(cmboxBed, Localization.BedDisplay(Convert.ToString(row.Cells["Bed"].Value)));
            txtPrice.Text = Convert.ToDecimal(row.Cells["Price"].Value).ToString("N2");
            SelectComboValue(cmBoxStatus, Localization.StatusDisplay(Convert.ToString(row.Cells["Status"].Value)));

            UpdateButtonStates();
            labelHint.Text = Language.T("تعديل الغرفة ", "Editing room ") + txtRoomNumber.Text +
                             Language.T(" (الرقم ", " (ID ") + selectedRoomId + ").";
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
                Fail(Language.T("رقم الغرفة موجود بالفعل.", "This room number already exists."), txtRoomNumber);
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
                MessageBox.Show(Language.T("تمت إضافة الغرفة.", "Room added."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else if (affected == 0)
            {
                MessageBox.Show(Language.T("لم تتم إضافة أي غرفة.", "No room was added."),
                    Language.T("تنبيه", "Notice"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show(Language.T("اختر غرفة من الجدول أولاً.", "Select a room from the grid first."),
                    Language.T("تنبيه", "Notice"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateRoomInput(out decimal price, out string roomNo))
                return;

            if (fn.RoomNumberExists(roomNo, selectedRoomId))
            {
                Fail(Language.T("رقم الغرفة موجود بالفعل.", "This room number already exists."), txtRoomNumber);
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
                MessageBox.Show(Language.T("تم تحديث بيانات الغرفة.", "Room updated."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(LocalizeRoomError(error) ??
                        Language.T("تعذّر تحديث الغرفة.", "Could not update the room."),
                    Language.T("فشل التحديث", "Update Failed"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show(Language.T("اختر غرفة من الجدول أولاً.", "Select a room from the grid first."),
                    Language.T("تنبيه", "Notice"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string roomNo = (txtRoomNumber.Text ?? string.Empty).Trim();

            if (MessageBox.Show(
                    Language.T("هل تريد حذف الغرفة ", "Delete room ") + roomNo + "؟\n\n" +
                    Language.T("لا يمكن حذف الغرف التي لها سجل نزلاء.",
                               "Rooms with guest history cannot be deleted."),
                    Language.T("تأكيد", "Confirm"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            string error;
            bool deleted = fn.DeleteRoom(selectedRoomId, out error);

            if (deleted)
            {
                MessageBox.Show(Language.T("تم حذف الغرفة.", "Room deleted."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(LocalizeRoomError(error) ??
                        Language.T("تعذّر حذف الغرفة.", "Could not delete the room."),
                    Language.T("فشل الحذف", "Delete Failed"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string LocalizeRoomError(string error)
        {
            if (string.IsNullOrEmpty(error) || !Language.IsArabic)
                return error;

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
                return Fail(Language.T("رقم الغرفة مطلوب.", "Room number is required."), txtRoomNumber);

            if (roomNo.Length > 10)
                return Fail(Language.T("رقم الغرفة لا يتجاوز 10 أحرف.", "Room number cannot exceed 10 characters."), txtRoomNumber);

            if (!Regex.IsMatch(roomNo, @"^[A-Za-z0-9\-]+$"))
                return Fail(Language.T("رقم الغرفة يقبل الحروف والأرقام والشرطة فقط.",
                                       "Room number accepts letters, digits and dashes only."), txtRoomNumber);

            if (cmBoxRoomType.SelectedIndex < 0)
                return Fail(Language.T("اختر نوع الغرفة.", "Select the room type."), cmBoxRoomType);

            if (cmboxBed.SelectedIndex < 0)
                return Fail(Language.T("اختر نوع السرير.", "Select the bed type."), cmboxBed);

            if (cmBoxStatus.SelectedIndex < 0)
                return Fail(Language.T("اختر حالة الغرفة.", "Select the room status."), cmBoxStatus);

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0 || price > 1000000m)
                return Fail(Language.T("السعر يجب أن يكون رقماً بين 0 و 1,000,000.",
                                       "Price must be a number between 0 and 1,000,000."), txtPrice);

            return true;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, Language.T("تحقق", "Validation"),
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

            SetComboItems(cmBoxRoomType, Localization.RoomTypeItems());
            SetComboItems(cmboxBed, Localization.BedItems());
            SetComboItems(cmBoxStatus, Localization.StatusItems());

            Theme.AddCard(this, new Rectangle(16, 84, 264, 420));

            if (searchBox == null)
            {
                searchBox = Theme.AddSearchBox(this, new Point(700, 24), new Size(290, 40),
                    Language.T("ابحث برقم الغرفة...", "Search by room number..."), SearchChanged);

                statusFilter = Theme.AddFilterCombo(this, new Point(1006, 24), new Size(162, 40),
                    BuildStatusFilterItems(), SearchChanged);

                statusFilter.SelectedIndex = 0;
            }

            Theme.AlignFieldLabels(this);
        }

        public void ApplyLanguage()
        {
            labelTitle.Text = Language.T("إدارة الغرف", "Room management");
            labelSubtitle.Text = Language.T("إضافة وتعديل وحذف الغرف", "Add, edit and delete rooms");
            label1.Text = Language.T("نوع الغرفة", "Room type");
            label5.Text = Language.T("السعر", "Price");
            label6.Text = Language.T("السرير", "Bed");
            label2.Text = Language.T("الحالة", "Status");

            txtRoomNumber.PlaceholderText = Language.T("رقم الغرفة", "Room number");
            txtPrice.PlaceholderText = Language.T("السعر", "Price");

            addbtn.Text = Language.T("إضافة", "Add");
            editbtn.Text = Language.T("تعديل", "Edit");
            deletebtn.Text = Language.T("حذف", "Delete");
            clearbtn.Text = Language.T("مسح", "Clear");

            SetComboItems(cmBoxRoomType, Localization.RoomTypeItems());
            SetComboItems(cmboxBed, Localization.BedItems());
            SetComboItems(cmBoxStatus, Localization.StatusItems());

            if (searchBox != null)
                searchBox.PlaceholderText = Language.T("ابحث برقم الغرفة...", "Search by room number...");

            if (statusFilter != null)
            {
                int index = statusFilter.SelectedIndex;

                statusFilter.Items.Clear();
                statusFilter.Items.Add(Language.T("كل الحالات", "All statuses"));
                statusFilter.Items.AddRange(Localization.StatusItems());

                statusFilter.SelectedIndex = index >= 0 && index < statusFilter.Items.Count ? index : 0;
            }

            labelHint.Text = Language.T("اختر غرفة من الجدول لتعديلها أو حذفها.",
                "Select a room from the grid to edit or delete it.");

            ConfigureGrid();
            ApplyRoomFilter();
        }

        private static string[] BuildStatusFilterItems()
        {
            string[] statuses = Localization.StatusItems();
            string[] items = new string[statuses.Length + 1];

            items[0] = Language.T("كل الحالات", "All statuses");
            statuses.CopyTo(items, 1);

            return items;
        }

        private static void SetComboItems(Guna2ComboBox combo, string[] items)
        {
            int index = combo.SelectedIndex;

            combo.Items.Clear();
            combo.Items.AddRange(items);

            if (index >= 0 && index < combo.Items.Count)
                combo.SelectedIndex = index;
        }
    }
}
