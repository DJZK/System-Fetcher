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
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.favicon;
            textInfo.Width = Width - 15;
            textInfo.Height = Height - 70;
           
            textInfo.Text = GlobalVariables.SystemInfo;
        }

        private void Viewer_SizeChanged(object sender, EventArgs e)
        {
            textInfo.Width = Width - 15;
            textInfo.Height = Height - 70;
        }
    }
}
