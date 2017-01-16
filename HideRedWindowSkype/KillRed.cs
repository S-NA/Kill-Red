using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HideRedWindowSkype
{
    public partial class KillRed : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(
               IntPtr parentHwnd,
               IntPtr childAfterHwnd,
               IntPtr className,
               string windowText);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        enum ShowWindowCommands
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_MAXIMIZE = 3,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11
        }

        protected static IntPtr HandleFromClass
        {
            get
            {
                return FindWindow("TSimpleSelection", ""); //the red window
            }
        }

        protected static IntPtr ButtonHandle
        {
            get
            {
                return FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);
            }
        }

        public static void wShow()
        {
            ShowWindow(HandleFromClass, ShowWindowCommands.SW_SHOWNORMAL);
            ShowWindow(ButtonHandle, ShowWindowCommands.SW_SHOWNORMAL);
        }

        public static void wHide()
        {
            ShowWindow(HandleFromClass, ShowWindowCommands.SW_HIDE);
            ShowWindow(ButtonHandle, ShowWindowCommands.SW_HIDE);
        }
        public KillRed()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool hidden = checkBox1.Checked;
            if (hidden)
            {
                wHide();
            }
            else
            {
                wShow();
            }
        }
    }
}
