using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Customers : UserControl
    {

        function fn = new function();
        string query;
        public UC_Customers()
        {
            InitializeComponent();
        }

        private void setComboBox(string query, ComboBox comboBox)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read())
            {
                for (short i = 0; i < sdr.FieldCount; i++)
                {
                    comboBox.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void UpdateRoomNumbers()
        {
            cmBoxRoomNo.Items.Clear();
            txtPrice.Clear();
            string query = "SELECT Room_NO FROM Rooms " +
                           "WHERE UPPER(LTRIM(RTRIM(Bed))) = '" + cmboxBed.Text.Trim().ToUpper() + "' " +
                           "AND UPPER(LTRIM(RTRIM(Room_Type))) = '" + cmBoxRoomType.Text.Trim().ToUpper() + "' " +
                           "AND Status = 'Free'";

            setComboBox(query, cmBoxRoomNo);
        }

        private void cmBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        private void cmboxBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoomNumbers();
        }

        int Room_ID;
        private void cmBoxRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "Select Price,Room_ID From Rooms Where Room_NO = '"+cmBoxRoomNo.Text+"'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            Room_ID = int.Parse(ds.Tables[0].Rows [0][1].ToString());
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
        }

        private void allotebtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtNationality.Text) || string.IsNullOrWhiteSpace(txtMobileNo.Text)
                 || string.IsNullOrWhiteSpace(txtIDProof.Text) || string.IsNullOrWhiteSpace(cmBoxGender.Text)
                 || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPrice.Text)
                 || string.IsNullOrWhiteSpace(DTP_DateOfBirth.Text) || string.IsNullOrWhiteSpace(DTP_CheckIn.Text))
            {
                MessageBox.Show("All Fields Mandatory", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string Name        = txtName.Text;
                string Nationality = txtNationality.Text;
                string MobileNo    = txtMobileNo.Text;
                string IDProof     = txtIDProof.Text;
                string Address     = txtAddress.Text;
                string Gender      = cmBoxGender.Text;
                DateTime DateOfBirth = DTP_DateOfBirth.Value.Date;
                DateTime CheckIn     = DTP_CheckIn.Value.Date;

                query = $"insert into Customers (Customer_Name,Customer_Mobile, Customer_Nationality, Customer_Gender,Customer_DateOfBirth," +
                    $"Customer_ID_Proof, Customer_Address, Customer_CheckIn, Customer_Room_ID)" +
                    $" values ('" + Name + "','" + MobileNo+ "'," + "'" + Nationality  + "','" + Gender + "','" + DateOfBirth + "','" + IDProof +
                    "','" + Address + "'" +",'" + CheckIn + "'," + Room_ID + ") update Rooms set Status = 'Busy' where Room_NO ='"+cmBoxRoomNo.Text+"'  ";
                fn.setData(query, "Room NO " + cmBoxRoomNo.Text + " Allocation Successfully.");
                ClearALL();
            }

        }
    }
}
