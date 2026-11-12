using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Hotel_Managment_System.Resources.HotelManagment
{
    public partial class UC_Customers : UserControl, ILocalizable
    {
        private readonly function fn = new function();
        private int roomId;
        private bool updatingLanguage;

        public UC_Customers()
        {
            InitializeComponent();

            // The room-number list depends on the room type and bed type.
            // These handlers were missing from the designer, so selecting a
            // room never filled the price and "Allocate" always failed.
            cmBoxRoomType.SelectedIndexChanged += cmBoxRoomType_SelectedIndexChanged;
            cmboxBed.SelectedIndexChanged += cmboxBed_SelectedIndexChanged;
            cmBoxRoomNo.SelectedIndexChanged += cmBoxRoomNo_SelectedIndexChanged;

            ApplyTheme();
            ApplyLanguage();
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
            if (updatingLanguage)
                return;

            UpdateRoomNumbers();
        }

        private void cmboxBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLanguage)
                return;

            UpdateRoomNumbers();
        }

        private void cmBoxRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updatingLanguage)
                return;

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
                MessageBox.Show(Language.T("تم تخصيص الغرفة ", "Room assigned: ") + selectedRoom +
                        Language.T(" بنجاح.", " successfully."),
                    Language.T("نجاح", "Success"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearALL();
            }
            else
            {
                MessageBox.Show(LocalizeAllocationError(error) ??
                        Language.T("تعذّر تخصيص الغرفة.", "Could not assign the room."),
                    Language.T("فشل التخصيص", "Assignment Failed"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string LocalizeAllocationError(string error)
        {
            if (string.IsNullOrEmpty(error) || !Language.IsArabic)
                return error;

            if (error == "This room is no longer available.")
                return "هذه الغرفة لم تعد متاحة.";

            return error;
        }

        private bool ValidateCustomerInput()
        {
            string name = (txtName.Text ?? string.Empty).Trim();
            if (name.Length == 0)
                return Fail(Language.T("اسم النزيل مطلوب.", "Guest name is required."), txtName);
            if (name.Length < 2)
                return Fail(Language.T("اسم النزيل يجب أن يكون حرفين على الأقل.",
                                       "Guest name must be at least two characters."), txtName);
            if (name.Length > 75)
                return Fail(Language.T("اسم النزيل لا يتجاوز 75 حرفاً.",
                                       "Guest name cannot exceed 75 characters."), txtName);

            string nationality = (txtNationality.Text ?? string.Empty).Trim();
            if (nationality.Length == 0)
                return Fail(Language.T("الجنسية مطلوبة.", "Nationality is required."), txtNationality);
            if (nationality.Length > 25)
                return Fail(Language.T("الجنسية لا تتجاوز 25 حرفاً.",
                                       "Nationality cannot exceed 25 characters."), txtNationality);

            string mobile = (txtMobileNo.Text ?? string.Empty).Trim();
            if (!Validation.IsValidMobile(mobile))
                return Fail(Language.T("أدخل رقم جوال صحيحاً (7-15 رقماً).",
                                       "Enter a valid mobile number (7-15 digits)."), txtMobileNo);

            if (cmBoxGender.SelectedIndex < 0)
                return Fail(Language.T("اختر الجنس.", "Select the gender."), cmBoxGender);

            string idProof = (txtIDProof.Text ?? string.Empty).Trim();
            if (idProof.Length == 0)
                return Fail(Language.T("إثبات الهوية مطلوب.", "ID proof is required."), txtIDProof);
            if (idProof.Length > 30)
                return Fail(Language.T("إثبات الهوية لا يتجاوز 30 حرفاً.",
                                       "ID proof cannot exceed 30 characters."), txtIDProof);

            string address = (txtAddress.Text ?? string.Empty).Trim();
            if (address.Length < 5)
                return Fail(Language.T("أدخل عنواناً صحيحاً (5 أحرف على الأقل).",
                                       "Enter a valid address (at least 5 characters)."), txtAddress);
            if (address.Length > 350)
                return Fail(Language.T("العنوان لا يتجاوز 350 حرفاً.",
                                       "Address cannot exceed 350 characters."), txtAddress);

            if (roomId <= 0)
                return Fail(Language.T("اختر غرفة شاغرة أولاً.", "Select a free room first."), cmBoxRoomNo);

            if (DTP_DateOfBirth.Value.Date >= DateTime.Today)
                return Fail(Language.T("تاريخ الميلاد يجب أن يكون قبل اليوم.",
                                       "Date of birth must be before today."), DTP_DateOfBirth);

            if (DTP_CheckIn.Value.Date < DateTime.Today)
                return Fail(Language.T("تاريخ الوصول لا يكون في الماضي.",
                                       "Check-in date cannot be in the past."), DTP_CheckIn);

            return true;
        }

        private static void SetComboItems(Guna2ComboBox combo, string[] items)
        {
            int index = combo.SelectedIndex;

            combo.Items.Clear();
            combo.Items.AddRange(items);

            if (index >= 0 && index < combo.Items.Count)
                combo.SelectedIndex = index;
        }

        private bool Fail(string message, Control focus)
        {
            MessageBox.Show(message, Language.T("تحقق", "Validation"),
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

            SetComboItems(cmBoxGender, Localization.GenderItems());
            SetComboItems(cmBoxRoomType, Localization.RoomTypeItems());
            SetComboItems(cmboxBed, Localization.BedItems());

            Theme.AddCard(this, new Rectangle(24, 86, 904, 402));

            Theme.AlignFieldLabels(this);
        }

        public void ApplyLanguage()
        {
            labelTitle.Text = Language.T("تسجيل النزيل", "Register guest");
            labelSubtitle.Text = Language.T("إضافة نزيل جديد وتخصيص غرفة",
                                            "Add a new guest and assign a room");

            label1.Text = Language.T("الاسم الكامل", "Full name");
            label9.Text = Language.T("رقم الجوال", "Mobile");
            label8.Text = Language.T("الجنسية", "Nationality");
            label4.Text = Language.T("الجنس", "Gender");
            label7.Text = Language.T("إثبات الهوية", "ID proof");
            label5.Text = Language.T("العنوان", "Address");
            label11.Text = Language.T("تاريخ الميلاد", "Date of birth");
            label12.Text = Language.T("تاريخ الوصول", "Check-in date");
            label3.Text = Language.T("نوع السرير", "Bed type");
            label2.Text = Language.T("نوع الغرفة", "Room type");
            label6.Text = Language.T("رقم الغرفة", "Room number");
            label10.Text = Language.T("السعر", "Price");

            txtName.PlaceholderText = Language.T("الاسم الكامل", "Full name");
            txtMobileNo.PlaceholderText = Language.T("رقم الجوال", "Mobile number");
            txtNationality.PlaceholderText = Language.T("الجنسية", "Nationality");
            txtIDProof.PlaceholderText = Language.T("إثبات الهوية", "ID proof");
            txtAddress.PlaceholderText = Language.T("العنوان", "Address");
            txtPrice.PlaceholderText = Language.T("السعر", "Price");

            allotebtn.Text = Language.T("تخصيص الغرفة", "Assign room");

            // Swapping the items fires SelectedIndexChanged, which would clear
            // the chosen room and its price. Suppress the handlers meanwhile.
            updatingLanguage = true;

            try
            {
                SetComboItems(cmBoxGender, Localization.GenderItems());
                SetComboItems(cmBoxRoomType, Localization.RoomTypeItems());
                SetComboItems(cmboxBed, Localization.BedItems());
            }
            finally
            {
                updatingLanguage = false;
            }
        }
    }
}
