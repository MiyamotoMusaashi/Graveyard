using System;
using System.Runtime.InteropServices;

namespace RecoilTime
{
    internal class Win32
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("user32.Dll")]
        public static extern short GetKeyState(uint nVirtKey);

        public static void Move(int x, int y)
        {
            if (((int)Win32.GetKeyState(2U) & 32768) != 0)
            {
                Win32.mouse_event(1U, x, y, 0U, UIntPtr.Zero);
            }
        }

        private const uint MOUSEEVENTF_ABSOLUTE = 32768U;
        private const uint MOUSEEVENTF_LEFTDOWN = 2U;
        private const uint MOUSEEVENTF_LEFTUP = 4U;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 32U;
        private const uint MOUSEEVENTF_MIDDLEUP = 64U;
        private const uint MOUSEEVENTF_MOVE = 1U;
        private const uint MOUSEEVENTF_RIGHTDOWN = 8U;
        private const uint MOUSEEVENTF_RIGHTUP = 16U;
        private const uint MOUSEEVENTF_XDOWN = 128U;
        private const uint MOUSEEVENTF_XUP = 256U;
        private const uint MOUSEEVENTF_WHEEL = 2048U;
        private const uint MOUSEEVENTF_HWHEEL = 4096U;
    }
}
