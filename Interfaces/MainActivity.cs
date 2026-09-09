using System;
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
            Icon = Properties.Resources.favicon;
            // App Version. 
            labelVerison.Text = Properties.Resources.appVersion;

            // Timer and Time label
            labelTime.Text = DateTime.Now + "";
            ticker.Enabled = true;

            // Automatically Loads 1 on Service Type DropDown
            comboServiceType.SelectedIndex = 0;

            // Automatically Loads 1 on Machine Type DropDown
            comboMachineType.SelectedIndex = 0;

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

            // Confirm Before Saving the stupid shit
            Confirmator cf = new Confirmator();
            if (!(cf.ShowDialog() == DialogResult.OK))
            {
                return; 
            }

            // Finally
            Handles.SaveSystemInfo(GlobalVariables.SystemInfo);
            if (MessageBox.Show("Success", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        private void LockandLoad()
        {
            GlobalVariables.sysInfo.PSU = textPSU.Text;
            GlobalVariables.sysInfo.FAN = textCPU.Text;
            GlobalVariables.sysInfo.CHASSIS = textChassy.Text;
            GlobalVariables.sysInfo.AT = textAT.Text;
            GlobalVariables.sysInfo.WORKINGTECH = textWorkingTechnician.Text;
            GlobalVariables.sysInfo.ST = comboServiceType.Text;
            GlobalVariables.sysInfo.MT = comboMachineType.Text;

        }

        private void labelVerison_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void comboMachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboMachineType.SelectedIndex)
            {
                case 0: // DESKTOP
                    textPSU.Enabled = true;
                    textPSU.Text = "";
                    textCPU.Enabled = true;
                    textCPU.Text = "";
                    textChassy.Enabled = true;
                    textChassy.Text = "";
                    comboServiceType.Enabled = true;
                    break;

                case 1: // LAPTOP
                    textPSU.Enabled = false;
                    textPSU.Text = "AC ADAPTER";
                    textCPU.Enabled = false;
                    textCPU.Text = "N/A";
                    textChassy.Enabled = true;
                    comboServiceType.Enabled = false;
                    comboServiceType.SelectedIndex = 1;
                    break;

                case 2: // MINIPC
                    textPSU.Enabled = false;
                    textPSU.Text = "AC ADAPTER";
                    textCPU.Enabled = false;
                    textCPU.Text = "N/A";
                    textChassy.Enabled = true;
                    comboServiceType.Enabled = false;
                    comboServiceType.SelectedIndex = 1;
                    break;

                case 3: // OEM
                    textPSU.Enabled = true;
                    textPSU.Text = "OEM";
                    textCPU.Enabled = true;
                    textCPU.Text = "OEM";
                    textChassy.Enabled = true; 
                    comboServiceType.Enabled = false;
                    comboServiceType.SelectedIndex = 1;
                    break;

                case 4: // MICRO
                    textPSU.Enabled = false;
                    textPSU.Text = "N/A";
                    textCPU.Enabled = false;
                    textCPU.Text = "N/A";
                    textChassy.Enabled = true;
                    comboServiceType.Enabled = false;
                    comboServiceType.SelectedIndex = 1;
                    break;

                case 5: // OTHER
                    textPSU.Enabled = true;
                    textPSU.Text = "";
                    textCPU.Enabled = true;
                    textCPU.Text = "";
                    textChassy.Enabled = true;
                    comboServiceType.Enabled = true;
                    break;

                default:
                    break;
            }
        }
    }
}