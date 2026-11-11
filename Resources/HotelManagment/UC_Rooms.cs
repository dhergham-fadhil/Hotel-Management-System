using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Rooms : UserControl
    {
        private readonly function fn = new function();

        public UC_Rooms()
        {
            InitializeComponent();
        }

        private void UC_Rooms_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {
            const string query = @"
                SELECT Room_NO, Room_Type, Bed, Price, Status
                FROM Rooms
                ORDER BY Room_NO";

            DGV_Rooms.DataSource = fn.getData(query);
        }

        private void ClearALL()
        {
            txtRoomNumber.Clear();
            cmBoxRoomType.SelectedIndex = -1;
            cmboxBed.SelectedIndex = -1;
            txtPrice.Clear();
            cmBoxStatus.SelectedIndex = -1;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateRoomInput(out decimal price, out string roomNo))
                return;

            // Friendly early check; the UNIQUE constraint remains the final guard.
            if (RoomNumberExists(roomNo))
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
                new SqlParameter("@roomType", SqlDbType.VarChar, 10) { Value = cmBoxRoomType.Text },
                new SqlParameter("@bed", SqlDbType.VarChar, 10) { Value = cmboxBed.Text },
                new SqlParameter("@price", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = price },
                new SqlParameter("@status", SqlDbType.VarChar, 5) { Value = cmBoxStatus.Text }
            };

            int affected = fn.setData(query, parameters);

            if (affected > 0)
            {
                MessageBox.Show("Room added.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRooms();
                ClearALL();
            }
            else if (affected == 0)
            {
                MessageBox.Show("No room was added.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private bool RoomNumberExists(string roomNo)
        {
            DataTable table = fn.getData(
                "SELECT Room_ID FROM Rooms WHERE Room_NO = @roomNo",
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo });

            return table.Rows.Count > 0;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }
    }
}
