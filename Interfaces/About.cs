using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace System_Fetcher.Interfaces
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.favicon;
            labelVersion.Text = Properties.Resources.appVersion;
            pictureLogo.Image = Properties.Resources._5595;
        }

        private void labelRepo_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/DJZK/System-Fetcher");
        }
    }
}
