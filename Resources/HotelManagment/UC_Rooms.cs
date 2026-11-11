using System;
using System.Data;
using System.Data.SqlClient;
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
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text)
                || string.IsNullOrWhiteSpace(cmBoxRoomType.Text)
                || string.IsNullOrWhiteSpace(cmboxBed.Text)
                || string.IsNullOrWhiteSpace(txtPrice.Text)
                || string.IsNullOrWhiteSpace(cmBoxStatus.Text))
            {
                MessageBox.Show("Fill all fields.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a number greater than zero.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            const string query = @"
                INSERT INTO Rooms (Room_NO, Room_Type, Bed, Price, Status)
                VALUES (@roomNo, @roomType, @bed, @price, @status)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = txtRoomNumber.Text.Trim() },
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
    }
}
