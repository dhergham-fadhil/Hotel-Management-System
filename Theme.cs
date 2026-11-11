using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;

namespace Hotel_Managment_System
{
    /// <summary>
    ///Central theme for the Hotel Management System UI.
    /// Provides a consistent luxury color palette and styling helpers
    /// so every screen looks cohesive and elegant.
    /// </summary>
    public static class Theme
    {
        // ------------------------------------------------------------------
        // Color palette (luxury hotel: deep slate + gold accent)
        // ------------------------------------------------------------------
        public static readonly Color Background   = Color.FromArgb(243, 246, 249); // slate-50
        public static readonly Color Surface      = Color.FromArgb(255, 255, 255); // white
        public static readonly Color Sidebar      = Color.FromArgb(15, 23, 42);   // slate-900
        public static readonly Color SidebarItem  = Color.FromArgb(30, 41, 59);   // slate-800
        public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);   // slate-700
        public static readonly Color SidebarActive= Color.FromArgb(37, 99, 235);  // indigo-600
        public static readonly Color AccentGold   = Color.FromArgb(212, 175, 55); // gold
        public static readonly Color TextPrimary  = Color.FromArgb(15, 23, 42);   // slate-900
        public static readonly Color TextSecondary= Color.FromArgb(71, 85, 105);  // slate-600
        public static readonly Color TextMuted    = Color.FromArgb(100, 116, 139);// slate-500
        public static readonly Color Border       = Color.FromArgb(226, 232, 240);// slate-200
        public static readonly Color Success      = Color.FromArgb(16, 185, 129); // emerald-500
        public static readonly Color Danger       = Color.FromArgb(239, 68, 68);  // red-500
        public static readonly Color Warning      = Color.FromArgb(245, 158, 11); // amber-500

        private static readonly Font TitleFont      = new Font("Segoe UI", 20F, FontStyle.Bold);
        private static readonly Font HeadingFont    = new Font("Segoe UI", 12F, FontStyle.Bold);
        private static readonly Font BodyFont       = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font SmallFont      = new Font("Segoe UI", 9F, FontStyle.Regular);
        private static readonly Font NavFont        = new Font("Segoe UI", 10.5F, FontStyle.Regular);

        // ------------------------------------------------------------------
        // Button styling
        // ------------------------------------------------------------------
        public static void StyleNavButton(Guna2Button btn, bool active = false)
        {
            btn.BorderRadius = 12;
            btn.ButtonMode = ButtonMode.RadioButton;
            btn.CustomBorderThickness = new Padding(0, 0, 4, 0);
            btn.CustomBorderColor = Color.Transparent;
            btn.FillColor = active ? SidebarActive : SidebarItem;
            btn.ForeColor = active ? Color.White : Color.FromArgb(148, 163, 184);
            btn.Font = NavFont;
            btn.DisabledState.BorderColor = Color.FromArgb(209, 213, 219);
            btn.DisabledState.CustomBorderColor = Color.FromArgb(209, 213, 219);
            btn.DisabledState.FillColor = Color.FromArgb(75, 85, 99);
            btn.DisabledState.ForeColor = Color.FromArgb(156, 163, 175);
            btn.HoverState.FillColor = SidebarHover;
            btn.HoverState.ForeColor = Color.White;
            btn.CheckedState.FillColor = SidebarActive;
            btn.CheckedState.ForeColor = Color.White;
            btn.CheckedState.CustomBorderColor = AccentGold;
            btn.ImageAlign = HorizontalAlignment.Left;
            btn.TextAlign = HorizontalAlignment.Left;
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleActionButton(Guna2Button btn, bool primary = true)
        {
            btn.BorderRadius = 10;
            btn.FillColor = primary ? SidebarActive : Surface;
            btn.ForeColor = primary ? Color.White : TextPrimary;
            btn.Font = BodyFont;
            btn.HoverState.FillColor = primary ? SidebarHover : Border;
            btn.HoverState.ForeColor = primary ? Color.White : TextPrimary;
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleDangerButton(Guna2Button btn)
        {
            btn.BorderRadius = 10;
            btn.FillColor = Danger;
            btn.ForeColor = Color.White;
            btn.Font = BodyFont;
            btn.HoverState.FillColor = Color.FromArgb(199, 45, 45);
            btn.HoverState.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }

        // ------------------------------------------------------------------
        // Panel / label styling
        // ------------------------------------------------------------------
        public static void StyleCard(Panel panel)
        {
            panel.BackColor = Surface;
            panel.BorderStyle = BorderStyle.None;
        }

        public static void StyleHeading(Label lbl)
        {
            lbl.Font = HeadingFont;
            lbl.ForeColor = TextPrimary;
        }

        public static void StyleBody(Label lbl)
        {
            lbl.Font = BodyFont;
            lbl.ForeColor = TextSecondary;
        }

        public static void StyleSmall(Label lbl)
        {
            lbl.Font = SmallFont;
            lbl.ForeColor = TextMuted;
        }

        // ------------------------------------------------------------------
        // Combo box / text box styling
        // ------------------------------------------------------------------
        public static void StyleInput(Guna2TextBox txt)
        {
            txt.BorderRadius = 8;
            txt.BorderColor = Border;
            txt.FillColor = Surface;
            txt.ForeColor = TextPrimary;
            txt.Font = BodyFont;
            txt.HoverState.BorderColor = SidebarActive;
            txt.FocusedState.BorderColor = SidebarActive;
        }

        public static void StyleCombo(Guna2ComboBox cbo)
        {
            cbo.BorderRadius = 8;
            cbo.BorderColor = Border;
            cbo.FillColor = Surface;
            cbo.ForeColor = TextPrimary;
            cbo.Font = BodyFont;
            cbo.FocusedState.BorderColor = SidebarActive;
            cbo.HoverState.BorderColor = SidebarActive;
        }
    }
}
