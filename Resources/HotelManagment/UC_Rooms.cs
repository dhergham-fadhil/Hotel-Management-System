using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Rooms : UserControl
    {
       private function fn = new function();
        private string query;
        public UC_Rooms()
        {
            InitializeComponent();
        }

        private void UC_Rooms_Load(object sender, EventArgs e)
        {
            query = "select * from Rooms";
            DataSet ds =  fn.getData(query);
            DGV_Rooms.DataSource = ds.Tables[0];
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
            if(string.IsNullOrWhiteSpace(txtRoomNumber.Text)|| string.IsNullOrWhiteSpace(cmBoxRoomType.Text)|| string.IsNullOrWhiteSpace(cmboxBed.Text)
                                        || string.IsNullOrWhiteSpace(txtPrice.Text)|| string.IsNullOrWhiteSpace(cmBoxStatus.Text))
            {
                MessageBox.Show("Fill All Fields", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                   
            else
            {
                string RoomNO = txtRoomNumber.Text;
                string RoomType = cmBoxRoomType.Text;
                string Bed = cmboxBed.Text;
                decimal Price = Convert.ToDecimal(txtPrice.Text);
                string Status = cmBoxStatus.Text;
                query = $"insert into Rooms (Room_NO,Room_Type,Bed, Price,Status) values ('" + RoomNO + "','" + RoomType + "'," +
                    "'" + Bed + "','" + Price + "','" + Status + "')";
                fn.setData(query, "Room Added.");
                UC_Rooms_Load(this, null);
                ClearALL();
              
                
            }
        }
    }
}
