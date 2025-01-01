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
            // Loads manual inputs to the bitch ass sysinfo
            LockandLoad();

            // Builds it to the system info
            Fetchers.BuildInfo();

            Viewer vw = new Viewer();
            vw.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Loads manual inputs to the bitch ass sysinfo
            LockandLoad();

            // Builds it to the system info
            Fetchers.BuildInfo();

            Handles.SaveSystemInfo(GlobalVariables.SystemInfo);

            if (MessageBox.Show("Success", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void LockandLoad()
        {
            GlobalVariables.sysInfo.PSU = textPSU.Text;
            GlobalVariables.sysInfo.FAN = textCPU.Text;
            GlobalVariables.sysInfo.CHASSIS = textChassy.Text;
            GlobalVariables.sysInfo.AT = textAT.Text;
            GlobalVariables.sysInfo.OWNER = textOwner.Text;

        }
    }
}