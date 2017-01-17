using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HideRedWindowSkype
{
    public partial class KillRed : Form
    {
        private bool hidden = false;
        public KillRed()
        {
            InitializeComponent();
            hidden = false;
            if (WndMgmt.NativeMethods.FindWindow("TSimpleSelection", "") == IntPtr.Zero)
            {
                MessageBox.Show("No red window found.", "Error");
            }
            else
            {
                WndMgmt.wHide();
                hidden = true;
                checkBox1.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            hidden = checkBox1.Checked;
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
