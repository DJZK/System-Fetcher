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

        }
    }
}