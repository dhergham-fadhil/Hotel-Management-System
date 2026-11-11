using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Staff : UserControl
    {
        function fn = new function();
        string query;
        public UC_Staff()
        {
            InitializeComponent();
        }

        private void ClearALL()
        {
            txtName.Clear();
            txtMobileNo.Clear();
            cmBoxGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtMobileNo.Text) || string.IsNullOrWhiteSpace(cmBoxGender.Text)
                                        || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Fill All Fields", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Name = txtName.Text;
                string Mobile = txtMobileNo.Text;
                string Gender = cmBoxGender.Text;
                string Email = txtEmail.Text;
                string UserName = txtUserName.Text;
                string Password = txtPassword.Text;
                query = $"insert into Staff (Staff_Name,Staff_Mobile,Staff_Gender,Staff_Email,Staff_UserName,Staff_Password) values ('" + Name + "','" + Mobile + "'," +
                    "'" + Gender + "','" + Email + "','" + UserName + "','" + Password + "')";
                fn.setData(query, "Staff Registered.");
                ClearALL();


            }
        }

        private void UpdateStaffTabSelectedIndex(Guna2DataGridView DGV)
        {
            query = "Select * From Staff";
            DataSet ds = fn.getData(query);
            DGV.DataSource = ds.Tables[0];
        }
        private void tabStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabStaff.SelectedIndex == 1)
            {
                UpdateStaffTabSelectedIndex(DGV_StaffDetails);
            }
            else if(tabStaff.SelectedIndex == 2)
            {
                UpdateStaffTabSelectedIndex(DGV_StaffDelete);
            }
        }

        private void staffDeletebtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStaffDeleteID.Text))
            {
                string checkQuery = "SELECT * FROM Staff WHERE Staff_ID = " + txtStaffDeleteID.Text;
                DataSet ds = fn.getData(checkQuery); // نفس fn اللي عندك بس ترجع DataSet

                if (ds.Tables[0].Rows.Count > 0) // يعني ID موجود
                {
                    if (MessageBox.Show("Are You Sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        query = "DELETE FROM Staff WHERE Staff_ID = " + txtStaffDeleteID.Text;
                        fn.setData(query, "Record Deleted.");
                        tabStaff_SelectedIndexChanged(this, null);
                    }
                }
                else
                {
                    MessageBox.Show("Staff ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
