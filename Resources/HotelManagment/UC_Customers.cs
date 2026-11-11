using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Customers : UserControl
    {
        private readonly function fn = new function();
        private int roomId;

        public UC_Customers()
        {
            InitializeComponent();
        }

        private void UpdateRoomNumbers()
        {
            cmBoxRoomNo.Items.Clear();
            txtPrice.Clear();
            roomId = 0;

            if (string.IsNullOrWhiteSpace(cmBoxRoomType.Text)
                || string.IsNullOrWhiteSpace(cmboxBed.Text))
            {
                return;
            }

            const string query = @"
                SELECT Room_NO
                FROM Rooms
                WHERE UPPER(LTRIM(RTRIM(Bed))) = UPPER(@bed)
                  AND UPPER(LTRIM(RTRIM(Room_Type))) = UPPER(@roomType)
                  AND Status = 'Free'
                ORDER BY Room_NO";

            SqlParameter[] parameters =
            {
                new SqlParameter("@bed", SqlDbType.VarChar, 10) { Value = cmboxBed.Text.Trim() },
                new SqlParameter("@roomType", SqlDbType.VarChar, 10) { Value = cmBoxRoomType.Text.Trim() }
            };

            foreach (string roomNo in fn.getForCombo(query, parameters))
                cmBoxRoomNo.Items.Add(roomNo);
        }

        private void cmBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        private void cmboxBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        private void cmBoxRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Clear();
            roomId = 0;

            string roomNo = cmBoxRoomNo.Text;
            if (string.IsNullOrWhiteSpace(roomNo))
                return;

            const string query = "SELECT Price, Room_ID FROM Rooms WHERE Room_NO = @roomNo";

            SqlParameter[] parameters =
            {
                new SqlParameter("@roomNo", SqlDbType.VarChar, 10) { Value = roomNo }
            };

            DataTable table = fn.getData(query, parameters);
            if (table.Rows.Count == 0)
                return;

            DataRow row = table.Rows[0];
            txtPrice.Text = Convert.ToDecimal(row["Price"]).ToString("N2");
            roomId = Convert.ToInt32(row["Room_ID"]);
        }

        private void ClearALL()
        {
            txtName.Clear();
            txtNationality.Clear();
            txtMobileNo.Clear();
            txtIDProof.Clear();
            txtAddress.Clear();
            cmBoxGender.SelectedIndex = -1;
            DTP_DateOfBirth.ResetText();
            DTP_CheckIn.ResetText();
            cmboxBed.SelectedIndex = -1;
            cmBoxRoomNo.Items.Clear();
            cmBoxRoomType.SelectedIndex = -1;
            txtPrice.Clear();
            roomId = 0;
        }

        private void allotebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)
                || string.IsNullOrWhiteSpace(txtNationality.Text)
                || string.IsNullOrWhiteSpace(txtMobileNo.Text)
                || string.IsNullOrWhiteSpace(txtIDProof.Text)
                || string.IsNullOrWhiteSpace(cmBoxGender.Text)
                || string.IsNullOrWhiteSpace(txtAddress.Text)
                || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("All fields are mandatory.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (roomId <= 0)
            {
                MessageBox.Show("Select a room first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedRoom = cmBoxRoomNo.Text;

            string error;
            bool allocated = fn.AllocateRoom(
                roomId,
                txtName.Text.Trim(),
                txtMobileNo.Text.Trim(),
                txtNationality.Text.Trim(),
                cmBoxGender.Text,
                DTP_DateOfBirth.Value.Date,
                txtIDProof.Text.Trim(),
                txtAddress.Text.Trim(),
                DTP_CheckIn.Value.Date,
                out error);

            if (allocated)
            {
                MessageBox.Show("Room " + selectedRoom + " allocated successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearALL();
            }
            else
            {
                MessageBox.Show(error ?? "The room could not be allocated.",
                    "Allocation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
