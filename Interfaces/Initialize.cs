using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Fetcher.Functions
{
    public partial class Initialize : Form
    {
        public Initialize()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text) || string.IsNullOrWhiteSpace(textOrg.Text))
            {
                MessageBox.Show("Please fill in both fields.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Handles.SaveConfig(textName.Text, textOrg.Text))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Something went wrong",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                }
                
            }
        }
    }
}
