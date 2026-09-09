using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Fetcher.Functions;

namespace System_Fetcher.Interfaces
{
    public partial class Confirmator : Form
    {
        public Confirmator()
        {
            InitializeComponent();
        }

        private void Confirmator_Load(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
            textDetails.Text = GlobalVariables.SystemInfo;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
