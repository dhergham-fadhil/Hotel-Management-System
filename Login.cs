using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    public partial class LoginForm : Form
    {
        private readonly function fn = new function();

        public LoginForm()
        {
            InitializeComponent();
        }

        internal StaffUser AuthenticatedUser { get; private set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            textBox1.Focus();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;

            string userName = (textBox1.Text ?? string.Empty).Trim();
            string password = textBox2.Text ?? string.Empty;

            if (userName.Length == 0 || password.Length == 0)
            {
                ShowError("Enter your user name and password.");
                return;
            }

            try
            {
                loginbtn.Enabled = false;
                Cursor = Cursors.WaitCursor;

                bool databaseError;
                StaffUser user = fn.AuthenticateUser(userName, password, out databaseError);

                if (user == null)
                {
                    if (!databaseError)
                    {
                        // Clear the password before showing the message: clearing fires
                        // TextChanged, which hides the error label.
                        textBox2.Clear();
                        textBox2.Focus();
                        ShowError("Invalid user name or password.");
                    }
                    return;
                }

                AuthenticatedUser = user;
                DialogResult = DialogResult.OK;
            }
            finally
            {
                loginbtn.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        private void forgetbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact an administrator to reset your password.",
                "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.FromArgb(218, 218, 218);
            textBox2.BackColor = Color.FromArgb(218, 218, 218);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = Color.FromArgb(218, 218, 218);
            textBox1.BackColor = Color.FromArgb(218, 218, 218);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
