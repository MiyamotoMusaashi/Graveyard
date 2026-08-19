using System;
using System.Runtime.InteropServices;

namespace RecoilTime
{
	// Token: 0x02000017 RID: 23
	internal class Win32
	{
		// Token: 0x06000149 RID: 329
		[DllImport("user32.dll")]
		private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

		// Token: 0x0600014A RID: 330
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Beep(uint dwFreq, uint dwDuration);

		// Token: 0x0600014B RID: 331
		[DllImport("user32.Dll")]
		public static extern short GetKeyState(uint nVirtKey);

		// Token: 0x0600014C RID: 332 RVA: 0x00012179 File Offset: 0x00010379
		public static void Move(int x, int y)
		{
			if (((int)Win32.GetKeyState(2U) & 32768) != 0)
			{
				Win32.mouse_event(1U, x, y, 0U, UIntPtr.Zero);
			}
		}

		// Token: 0x04000129 RID: 297
		private const uint MOUSEEVENTF_ABSOLUTE = 32768U;

		// Token: 0x0400012A RID: 298
		private const uint MOUSEEVENTF_LEFTDOWN = 2U;

		// Token: 0x0400012B RID: 299
		private const uint MOUSEEVENTF_LEFTUP = 4U;

		// Token: 0x0400012C RID: 300
		private const uint MOUSEEVENTF_MIDDLEDOWN = 32U;

		// Token: 0x0400012D RID: 301
		private const uint MOUSEEVENTF_MIDDLEUP = 64U;

		// Token: 0x0400012E RID: 302
		private const uint MOUSEEVENTF_MOVE = 1U;

		// Token: 0x0400012F RID: 303
		private const uint MOUSEEVENTF_RIGHTDOWN = 8U;

		// Token: 0x04000130 RID: 304
		private const uint MOUSEEVENTF_RIGHTUP = 16U;

		// Token: 0x04000131 RID: 305
		private const uint MOUSEEVENTF_XDOWN = 128U;

		// Token: 0x04000132 RID: 306
		private const uint MOUSEEVENTF_XUP = 256U;

		// Token: 0x04000133 RID: 307
		private const uint MOUSEEVENTF_WHEEL = 2048U;

		// Token: 0x04000134 RID: 308
		private const uint MOUSEEVENTF_HWHEEL = 4096U;
	}
}
