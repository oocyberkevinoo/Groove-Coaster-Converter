using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groove_Coaster_Converter.Class
{
    public static class DarkUI
    {

        private static Color colorButtonBack;
        private static Color colorButtonFore;
        private static Color colorTextBoxBack;
        private static Color colorTextBoxFore;
        private static Color colorComboBoxBack;
        private static Color colorComboBoxFore;
        private static Color colorListBoxBack;
        private static Color colorListBoxFore;
        private static Color colorTabPageBack;
        private static Color colorTabPageFore;
        private static Color colorFormBack;
        private static Color colorFormFore;
        private static Color colorStatusStripBack;
        private static Color colorStatusStripFore;
        private static Color colorNumBack;
        private static Color colorNumFore;

        private static Color colorLinkNormal;
        private static Color colorLinkUsed;



        public static void Dark(Control control)
        {
            bool dark = Program.darkUI;



            if (dark)
            {
                //Form_About.ActiveForm.BackColor = Color.Black;
                //Form_About.ActiveForm.ForeColor = Color.White;


            }
            else
            {
                //Form_About.ActiveForm.BackColor = ;
                //Form_About.ActiveForm.ForeColor = colorFore;
            }

            foreach (Button button in GetAll(control, typeof(Button)))
            {
                DarkMe(button);
            }
            foreach (TextBox text in GetAll(control, typeof(TextBox)))
            {

                DarkMe(text);
            }
            foreach (ComboBox combo in GetAll(control, typeof(ComboBox)))
            {

                DarkMe(combo);
            }
            foreach (ListBox listBox in GetAll(control, typeof(ListBox)))
            {

                DarkMe(listBox);
            }

            foreach (TabPage tabPage in GetAll(control, typeof(TabPage)))
            {

                DarkMe(tabPage);
            }
            foreach (LinkLabel linkLabel in GetAll(control, typeof(LinkLabel)))
            {

                DarkMe(linkLabel);
            }
            foreach (StatusStrip statusStrip in GetAll(control, typeof(StatusStrip)))
            {

                DarkMe(statusStrip);
            }
            foreach (NumericUpDown numeric in GetAll(control, typeof(NumericUpDown)))
            {

                DarkMe(numeric);
            }

            DarkMe(control.FindForm());
        }
        private static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private static void DarkMe(Form control)
        {

            if (Program.darkUI)
            {
                colorFormBack = control.BackColor;
                colorFormFore = control.ForeColor;

                control.BackColor = Color.Black;
                control.ForeColor = Color.White;

                
            }
            else
            {
                control.BackColor = colorFormBack;
                control.ForeColor = colorFormFore;
                //control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(Button control)
        {


            if (Program.darkUI)
            {
                control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                colorButtonBack = control.BackColor;
                colorButtonFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.FlatStyle = System.Windows.Forms.FlatStyle.System;
                control.BackColor = colorButtonBack;
                control.ForeColor = colorButtonFore;
                control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(LinkLabel control)
        {


            if (Program.darkUI)
            {
                colorLinkNormal = control.LinkColor;
                colorLinkUsed = control.ActiveLinkColor;


                control.LinkColor = Color.Orange;
                control.ActiveLinkColor = Color.OrangeRed;
            }
            else
            {
                control.LinkColor = colorLinkNormal;
                control.ActiveLinkColor = colorLinkUsed;
                //control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(TextBox control)
        {
            if (Program.darkUI)
            {
                colorTextBoxBack = control.BackColor;
                colorTextBoxFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorTextBoxBack;
                control.ForeColor = colorTextBoxFore;
                //control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(ComboBox control)
        {
            if (Program.darkUI)
            {
                colorComboBoxBack = control.BackColor;
                colorComboBoxFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorComboBoxBack;
                control.ForeColor = colorComboBoxFore;
                //control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(NumericUpDown control)
        {
            if (Program.darkUI)
            {
                colorNumBack = control.BackColor;
                colorNumFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorNumBack;
                control.ForeColor = colorNumFore;
                //control.UseVisualStyleBackColor = true;

            }

        }
        private static void DarkMe(ListBox control)
        {
            if (Program.darkUI)
            {
                colorListBoxBack = control.BackColor;
                colorListBoxFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorListBoxBack;
                control.ForeColor = colorListBoxFore;
                //control.UseVisualStyleBackColor = true;

            }
        }

        private static void DarkMe(TabPage control)
        {
            if (Program.darkUI)
            {
                colorTabPageBack = control.BackColor;
                colorTabPageFore = control.ForeColor;

                //control.BackColor = SystemColors.ControlDark;
                control.BackColor = Color.Black;
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorTabPageBack;
                control.ForeColor = colorTabPageFore;
                control.UseVisualStyleBackColor = true;

            }

        }

        private static void DarkMe(StatusStrip control)
        {
            if (Program.darkUI)
            {
                colorStatusStripBack = control.BackColor;
                colorStatusStripFore = control.ForeColor;

                control.BackColor = Color.FromArgb(0xff, 0x30, 0x30, 0x30);
                control.ForeColor = Color.White;
            }
            else
            {
                control.BackColor = colorStatusStripBack;
                control.ForeColor = colorStatusStripFore;
                //control.UseVisualStyleBackColor = true;

            }

        }

    }
}