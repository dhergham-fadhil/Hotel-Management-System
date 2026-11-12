using System;
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

        public static void StyleDatePicker(Guna2DateTimePicker dtp)
        {
            dtp.BorderRadius = 8;
            dtp.BorderColor = Border;
            dtp.BorderThickness = 1;
            dtp.FillColor = Surface;
            dtp.ForeColor = TextPrimary;
            dtp.Font = BodyFont;
        }

        // ------------------------------------------------------------------
        // Shared screen layout helpers
        // ------------------------------------------------------------------

        /// <summary>Applies the standard page heading style (20pt bold).</summary>
        public static void StyleScreenTitle(Label lbl)
        {
            lbl.AutoSize = true;
            lbl.Font = TitleFont;
            lbl.ForeColor = TextPrimary;
        }

        /// <summary>Applies the standard page subtitle style (10pt muted).</summary>
        public static void StyleScreenSubtitle(Label lbl)
        {
            lbl.AutoSize = true;
            lbl.Font = BodyFont;
            lbl.ForeColor = TextSecondary;
        }

        /// <summary>
        /// Adds a rounded white "card" behind the existing controls.
        /// The panel is sent to the back so it never covers a field or a grid.
        /// </summary>
        public static Guna2Panel AddCard(Control parent, Rectangle bounds)
        {
            Guna2Panel card = new Guna2Panel
            {
                Location = bounds.Location,
                Size = bounds.Size,
                FillColor = Surface,
                BorderColor = Border,
                BorderThickness = 1,
                BorderRadius = 14,
                BackColor = Color.Transparent
            };

            parent.Controls.Add(card);
            card.SendToBack();
            return card;
        }

        /// <summary>
        /// Creates a styled search text box in the page header.
        /// </summary>
        public static Guna2TextBox AddSearchBox(Control parent, Point location, Size size,
                                                string placeholder, EventHandler onTextChanged)
        {
            Guna2TextBox box = new Guna2TextBox
            {
                PlaceholderText = placeholder,
                BorderRadius = 10,
                BorderColor = Border,
                FillColor = Surface,
                ForeColor = TextPrimary,
                Font = BodyFont,
                HoverState = { BorderColor = SidebarActive },
                FocusedState = { BorderColor = SidebarActive }
            };

            if (onTextChanged != null)
                box.TextChanged += onTextChanged;

            parent.Controls.Add(box);

            // The bounds are applied after parenting: WinForms may scale a new
            // child while it is being added, which would shift a fixed layout.
            box.Bounds = new Rectangle(location, size);
            box.BringToFront();
            return box;
        }

        /// <summary>
        /// Creates a styled filter combo box in the page header.
        /// </summary>
        public static Guna2ComboBox AddFilterCombo(Control parent, Point location, Size size,
                                                   string[] items, EventHandler onSelectedIndexChanged)
        {
            Guna2ComboBox combo = new Guna2ComboBox
            {
                BorderRadius = 10,
                BorderColor = Border,
                FillColor = Surface,
                ForeColor = TextPrimary,
                Font = BodyFont,
                HoverState = { BorderColor = SidebarActive },
                FocusedState = { BorderColor = SidebarActive }
            };

            combo.Items.AddRange(items);

            if (onSelectedIndexChanged != null)
                combo.SelectedIndexChanged += onSelectedIndexChanged;

            parent.Controls.Add(combo);
            combo.Bounds = new Rectangle(location, size);
            combo.BringToFront();
            return combo;
        }

        /// <summary>
        /// Right-aligns the small labels that sit directly above an input.
        /// Arabic forms read naturally when the label hugs the right edge of
        /// its field, so the label is widened to match the field below it.
        /// </summary>
        public static void AlignFieldLabels(Control root)
        {
            foreach (Control child in root.Controls)
            {
                Label label = child as Label;
                if (label != null && label.AutoSize)
                {
                    Control field = FindFieldBelow(root, label);
                    if (field != null)
                    {
                        int height = label.Height;
                        label.AutoSize = false;
                        label.Width = field.Width;
                        label.Height = height;
                        label.TextAlign = ContentAlignment.MiddleRight;
                    }
                }

                if (child.HasChildren)
                    AlignFieldLabels(child);
            }
        }

        private static Control FindFieldBelow(Control root, Label label)
        {
            Control best = null;
            int bestDistance = int.MaxValue;

            foreach (Control candidate in root.Controls)
            {
                if (!IsInput(candidate))
                    continue;

                int horizontal = Math.Abs(candidate.Left - label.Left);
                int vertical = candidate.Top - label.Top;

                if (horizontal <= 8 && vertical > 4 && vertical <= 40 && vertical < bestDistance)
                {
                    best = candidate;
                    bestDistance = vertical;
                }
            }

            return best;
        }

        private static bool IsInput(Control control)
        {
            return control is Guna2TextBox
                || control is Guna2ComboBox
                || control is Guna2DateTimePicker
                || control is TextBox
                || control is ComboBox
                || control is DateTimePicker;
        }
    }
}
