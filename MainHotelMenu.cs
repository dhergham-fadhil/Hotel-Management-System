using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using Hotel_Managment_System.Resources.HotelManagment;

namespace Hotel_Managment_System
{
    public partial class MainHotelMenu : Form
    {
        public MainHotelMenu()
        {
            InitializeComponent();
        }



        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddUserControl(UserControl UC)
        {
            UC.Dock = DockStyle.Fill;
            UC_Panel.Controls.Clear();
            UC_Panel.Controls.Add(UC);
            UC.BringToFront();
                
        }
        private void NavigationButton_Click(object sender, EventArgs e)
        {
            UserControl control = null;

            if (sender == roomsbtn)
                control = new UC_Rooms();
            else if (sender == customersbtn)
                control = new UC_Customers();
            else if (sender == staffbtn)
                control = new UC_Staff();
            else if (sender == bookingsbtn)
                control = new UC_Booking();

            if (control != null)
                AddUserControl(control);
        }

        private void roomsbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void customersbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void staffbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void bookingsbtn_Click(object sender, EventArgs e)
        {
            NavigationButton_Click(sender, e);
        }

        private void MainHotelMenu_Load(object sender, EventArgs e)
        {
            roomsbtn.PerformClick();
            
        }

     
    }
}
