using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HideRedWindowSkype
{
    class WndMgmt
    {
        public class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string className, string windowText);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindowEx(
                   IntPtr parentHwnd,
                   IntPtr childAfterHwnd,
                   IntPtr className,
                   string windowText);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
        }

        public enum ShowWindowCommands
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
                return NativeMethods.FindWindow("TSimpleSelection", ""); // the red border
            }
        }

        protected static IntPtr ButtonHandle
        {
            get
            {
                return NativeMethods.FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);
            }
        }

        public static void wShow()
        {
            NativeMethods.ShowWindow(HandleFromClass, ShowWindowCommands.SW_SHOWNORMAL);
            NativeMethods.ShowWindow(ButtonHandle, ShowWindowCommands.SW_SHOWNORMAL);
        }

        public static void wHide()
        {
            NativeMethods.ShowWindow(HandleFromClass, ShowWindowCommands.SW_HIDE);
            NativeMethods.ShowWindow(ButtonHandle, ShowWindowCommands.SW_HIDE);
        }
    }
}
