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

        public UC_Rooms()
        {
            InitializeComponent();
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

            DGV_Rooms.DataSource = fn.getData(query);

            // Room_ID identifies the selected row; it does not need to be visible.
            if (DGV_Rooms.Columns["Room_ID"] != null)
                DGV_Rooms.Columns["Room_ID"].Visible = false;

            ClearALL();
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
            labelHint.Text = "Select a room in the grid to edit or delete it.";
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
            SelectComboValue(cmBoxRoomType, Convert.ToString(row.Cells["Room_Type"].Value));
            SelectComboValue(cmboxBed, Convert.ToString(row.Cells["Bed"].Value));
            txtPrice.Text = Convert.ToDecimal(row.Cells["Price"].Value).ToString("N2");
            SelectComboValue(cmBoxStatus, Convert.ToString(row.Cells["Status"].Value));

            UpdateButtonStates();
            labelHint.Text = "Editing room " + txtRoomNumber.Text +
                             " (Room_ID " + selectedRoomId + ").";
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
                Fail("Room number already exists.", txtRoomNumber);
                return;
            }

            const string query = @"
                INSERT INTO Rooms (Room_NO, Room_Type, Bed, Price, Status)
                VALUES (@roomNo, @roomType, @bed, @price, @status)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo },
                new SqlParameter("@roomType", SqlDbType.VarChar, 10) { Value = cmBoxRoomType.Text.Trim() },
                new SqlParameter("@bed", SqlDbType.VarChar, 10) { Value = cmboxBed.Text.Trim() },
                new SqlParameter("@price", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = price },
                new SqlParameter("@status", SqlDbType.VarChar, 5) { Value = cmBoxStatus.Text.Trim() }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("Room added.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else if (affected == 0)
            {
                MessageBox.Show("No room was added.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show("Select a room from the grid first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateRoomInput(out decimal price, out string roomNo))
                return;

            if (fn.RoomNumberExists(roomNo, selectedRoomId))
            {
                Fail("Room number already exists.", txtRoomNumber);
                return;
            }

            string error;
            bool updated = fn.UpdateRoom(
                selectedRoomId,
                roomNo,
                cmBoxRoomType.Text.Trim(),
                cmboxBed.Text.Trim(),
                price,
                cmBoxStatus.Text.Trim(),
                out error);

            if (updated)
            {
                MessageBox.Show("Room updated.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(error ?? "The room could not be updated.",
                    "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedRoomId <= 0)
            {
                MessageBox.Show("Select a room from the grid first.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string roomNo = (txtRoomNumber.Text ?? string.Empty).Trim();

            if (MessageBox.Show("Delete room " + roomNo + "?\n\n" +
                    "Rooms with customer history cannot be deleted.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            string error;
            bool deleted = fn.DeleteRoom(selectedRoomId, out error);

            if (deleted)
            {
                MessageBox.Show("Room deleted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
            }
            else
            {
                MessageBox.Show(error ?? "The room could not be deleted.",
                    "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                return Fail("Room number is required.", txtRoomNumber);

            if (roomNo.Length > 10)
                return Fail("Room number cannot exceed 10 characters.", txtRoomNumber);

            if (!Regex.IsMatch(roomNo, @"^[A-Za-z0-9\-]+$"))
                return Fail("Room number may contain letters, digits and hyphens only.", txtRoomNumber);

            if (cmBoxRoomType.SelectedIndex < 0)
                return Fail("Select a room type.", cmBoxRoomType);

            if (cmboxBed.SelectedIndex < 0)
                return Fail("Select a bed type.", cmboxBed);

            if (cmBoxStatus.SelectedIndex < 0)
                return Fail("Select a room status.", cmBoxStatus);

            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0 || price > 1000000m)
                return Fail("Price must be a number between 0 and 1,000,000.", txtPrice);

            return true;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        private void ApplyTheme()
        {
            labelTitle.ForeColor = Theme.TextPrimary;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);

            labelSubtitle.ForeColor = Theme.TextSecondary;
            labelSubtitle.Font = new Font("Segoe UI", 10F);

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
        }
    }
}
