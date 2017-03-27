using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HideRedWindowSkype
{
    public partial class KillRed : Form
    {
        public KillRed()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool hidden = checkBox1.Checked;
            if (hidden)
            {
                WndMgmt.wHide();
            }
            else
            {
                WndMgmt.wShow();
            }
        }
    }
}
