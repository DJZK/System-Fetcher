using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Fetcher.Interfaces;

namespace System_Fetcher.Functions
{
    public partial class MainActivity : Form
    {
        public MainActivity()
        {
            InitializeComponent();

            try
            {
                Handles.CheckIniFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Exit the application in case of critical failure
            }

        }

        private void MainActivity_Load(object sender, EventArgs e)
        {

            // App Version. 
            labelVerison.Text = Properties.Resources.appVersion;

            // Timer and Time label
            labelTime.Text = DateTime.Now + "";
            ticker.Enabled = true;


            Fetchers.FetchSystem();
        }

        private void ticker_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now + "";
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            Viewer vw = new Viewer();
            vw.ShowDialog();
        }
    }
}