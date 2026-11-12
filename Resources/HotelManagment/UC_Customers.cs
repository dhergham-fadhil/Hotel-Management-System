using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Customers : UserControl
    {
        private readonly function fn = new function();
        private int roomId;

        public UC_Customers()
        {
            InitializeComponent();
            ApplyTheme();
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
                new SqlParameter("@bed", SqlDbType.VarChar, 10) { Value = Localization.BedToDatabase(cmboxBed.Text) },
                new SqlParameter("@roomType", SqlDbType.VarChar, 10) { Value = Localization.RoomTypeToDatabase(cmBoxRoomType.Text) }
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
            if (!ValidateCustomerInput())
                return;

            string selectedRoom = cmBoxRoomNo.Text;

            string error;
            bool allocated = fn.AllocateRoom(
                roomId,
                txtName.Text.Trim(),
                txtMobileNo.Text.Trim(),
                txtNationality.Text.Trim(),
                Localization.GenderToDatabase(cmBoxGender.Text),
                DTP_DateOfBirth.Value.Date,
                txtIDProof.Text.Trim(),
                txtAddress.Text.Trim(),
                DTP_CheckIn.Value.Date,
                out error);

            if (allocated)
            {
                MessageBox.Show("تم تخصيص الغرفة " + selectedRoom + " بنجاح.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearALL();
            }
            else
            {
                MessageBox.Show(error ?? "تعذّر تخصيص الغرفة.",
                    "فشل التخصيص", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateCustomerInput()
        {
            string name = (txtName.Text ?? string.Empty).Trim();
            if (name.Length == 0)
                return Fail("اسم النزيل مطلوب.", txtName);
            if (name.Length < 2)
                return Fail("اسم النزيل يجب أن يكون حرفين على الأقل.", txtName);
            if (name.Length > 75)
                return Fail("اسم النزيل لا يتجاوز 75 حرفاً.", txtName);

            string nationality = (txtNationality.Text ?? string.Empty).Trim();
            if (nationality.Length == 0)
                return Fail("الجنسية مطلوبة.", txtNationality);
            if (nationality.Length > 25)
                return Fail("الجنسية لا تتجاوز 25 حرفاً.", txtNationality);

            string mobile = (txtMobileNo.Text ?? string.Empty).Trim();
            if (!Validation.IsValidMobile(mobile))
                return Fail("أدخل رقم جوال صحيحاً (7-15 رقماً).", txtMobileNo);

            if (cmBoxGender.SelectedIndex < 0)
                return Fail("اختر الجنس.", cmBoxGender);

            string idProof = (txtIDProof.Text ?? string.Empty).Trim();
            if (idProof.Length == 0)
                return Fail("إثبات الهوية مطلوب.", txtIDProof);
            if (idProof.Length > 30)
                return Fail("إثبات الهوية لا يتجاوز 30 حرفاً.", txtIDProof);

            string address = (txtAddress.Text ?? string.Empty).Trim();
            if (address.Length < 5)
                return Fail("أدخل عنواناً صحيحاً (5 أحرف على الأقل).", txtAddress);
            if (address.Length > 350)
                return Fail("العنوان لا يتجاوز 350 حرفاً.", txtAddress);

            if (roomId <= 0)
                return Fail("اختر غرفة شاغرة أولاً.", cmBoxRoomNo);

            if (DTP_DateOfBirth.Value.Date >= DateTime.Today)
                return Fail("تاريخ الميلاد يجب أن يكون قبل اليوم.", DTP_DateOfBirth);

            if (DTP_CheckIn.Value.Date < DateTime.Today)
                return Fail("تاريخ الوصول لا يكون في الماضي.", DTP_CheckIn);

            return true;
        }

        private static void SetComboItems(Guna2ComboBox combo, string[] items)
        {
            string current = combo.Text;

            combo.Items.Clear();
            combo.Items.AddRange(items);

            if (!string.IsNullOrEmpty(current) && combo.Items.Contains(current))
                combo.SelectedItem = current;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, "تحقق",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        private void ApplyTheme()
        {
            labelTitle.ForeColor = Theme.TextPrimary;
            Theme.StyleScreenTitle(labelTitle);

            labelSubtitle.ForeColor = Theme.TextSecondary;
            Theme.StyleScreenSubtitle(labelSubtitle);

            Theme.StyleInput(txtName);
            Theme.StyleInput(txtMobileNo);
            Theme.StyleInput(txtNationality);
            Theme.StyleInput(txtIDProof);
            Theme.StyleInput(txtAddress);
            Theme.StyleInput(txtPrice);

            Theme.StyleCombo(cmBoxGender);
            Theme.StyleCombo(cmboxBed);
            Theme.StyleCombo(cmBoxRoomType);
            Theme.StyleCombo(cmBoxRoomNo);

            Theme.StyleDatePicker(DTP_DateOfBirth);
            Theme.StyleDatePicker(DTP_CheckIn);

            Theme.StyleActionButton(allotebtn, true);

            label1.ForeColor = Theme.TextSecondary;
            label9.ForeColor = Theme.TextSecondary;
            label8.ForeColor = Theme.TextSecondary;
            label4.ForeColor = Theme.TextSecondary;
            label7.ForeColor = Theme.TextSecondary;
            label5.ForeColor = Theme.TextSecondary;
            label11.ForeColor = Theme.TextSecondary;
            label12.ForeColor = Theme.TextSecondary;
            label3.ForeColor = Theme.TextSecondary;
            label2.ForeColor = Theme.TextSecondary;
            label6.ForeColor = Theme.TextSecondary;
            label10.ForeColor = Theme.TextSecondary;

            label1.Font = new Font("Segoe UI", 9.5F);
            label9.Font = new Font("Segoe UI", 9.5F);
            label8.Font = new Font("Segoe UI", 9.5F);
            label4.Font = new Font("Segoe UI", 9.5F);
            label7.Font = new Font("Segoe UI", 9.5F);
            label5.Font = new Font("Segoe UI", 9.5F);
            label11.Font = new Font("Segoe UI", 9.5F);
            label12.Font = new Font("Segoe UI", 9.5F);
            label3.Font = new Font("Segoe UI", 9.5F);
            label2.Font = new Font("Segoe UI", 9.5F);
            label6.Font = new Font("Segoe UI", 9.5F);
            label10.Font = new Font("Segoe UI", 9.5F);

            SetComboItems(cmBoxGender, new[] { "ذكر", "أنثى", "آخر", "أفضل عدم الإجابة" });
            SetComboItems(cmBoxRoomType, new[] { "فردية", "مزدوجة", "توأم", "ثلاثية", "جناح" });
            SetComboItems(cmboxBed, new[] { "فردي", "مزدوج", "كوين", "كينغ", "توأم", "بطابقين" });

            Theme.AddCard(this, new Rectangle(24, 86, 904, 402));

            Theme.AlignFieldLabels(this);
        }
    }
}
