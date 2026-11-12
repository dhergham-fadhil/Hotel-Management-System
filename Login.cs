using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    public partial class LoginForm : Form
    {
        private readonly function fn = new function();
        private Button languageButton;

        public LoginForm()
        {
            InitializeComponent();
            CreateLanguageButton();
            ApplyLanguage();
        }

        internal StaffUser AuthenticatedUser { get; private set; }

        private void CreateLanguageButton()
        {
            languageButton = new Button();
            languageButton.FlatStyle = FlatStyle.Flat;
            languageButton.FlatAppearance.BorderColor = Color.FromArgb(44, 62, 80);
            languageButton.FlatAppearance.BorderSize = 1;
            languageButton.BackColor = Color.FromArgb(218, 218, 218);
            languageButton.ForeColor = Color.FromArgb(44, 62, 80);
            languageButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            languageButton.Cursor = Cursors.Hand;
            languageButton.Size = new Size(110, 32);
            languageButton.Click += languageButton_Click;

            panel2.Controls.Add(languageButton);

            // Set bounds after adding: WinForms scales some controls on add.
            languageButton.Location = new Point(10, 8);
            languageButton.BringToFront();
        }

        private void languageButton_Click(object sender, EventArgs e)
        {
            Language.Set(Language.IsArabic ? AppLanguage.English : AppLanguage.Arabic);
            labelError.Visible = false;
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            label1.Text = Language.T("مرحبًا بك في تطبيق الفندق", "Welcome To Our Hotel App");
            label2.Text = Language.T("تطوير", "Developed By");
            label3.Text = Language.T("الدخول إلى حسابك", "Login To Your Account");
            loginbtn.Text = Language.T("تسجيل الدخول", "LOGIN");
            forgetbtn.Text = Language.T("نسيت كلمة المرور؟", "Forget Password ?");
            Text = Language.T("تسجيل الدخول", "Login");

            if (languageButton != null)
                languageButton.Text = Language.IsArabic ? "English" : "العربية";
        }

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
                ShowError(Language.T("أدخل اسم المستخدم وكلمة المرور.",
                    "Enter your user name and password."));
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
                        ShowError(Language.T("اسم المستخدم أو كلمة المرور غير صحيحة.",
                            "Invalid user name or password."));
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
            MessageBox.Show(Language.T(
                    "يرجى التواصل مع المدير لإعادة تعيين كلمة المرور.",
                    "Please contact an administrator to reset your password."),
                Language.T("إعادة تعيين كلمة المرور", "Password Reset"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
