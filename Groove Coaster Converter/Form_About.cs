using Groove_Coaster_Converter.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groove_Coaster_Converter
{
    public partial class Form_About : Form
    {



        public Form_About()
        {
            InitializeComponent();
        }


        private void link_Twitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link_Twitter.LinkVisited = true;
            System.Diagnostics.Process.Start("https://twitter.com/cyberteamnews");
        }

        private void link_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            link_Github.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/oocyberkevinoo/Groove-Coaster-Converter");
        }

        private void Form_About_Shown(object sender, EventArgs e)
        {
            DarkUI.Dark(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
