using System;
using System.Threading;

namespace RecoilTime
{
	// Token: 0x02000016 RID: 22
	internal class Recoil
	{
		// Token: 0x06000146 RID: 326 RVA: 0x000120E0 File Offset: 0x000102E0
		public static void Loop()
		{
			for (;;)
			{
				Thread.Sleep(Recoil.sleeptime);
				if (((int)Win32.GetKeyState(45U) & 32768) > 0)
				{
					Recoil.Enabled = !Recoil.Enabled;
					if (Recoil.Enabled)
					{
						Win32.Beep(0U, 0U);
					}
					else
					{
						Win32.Beep(0U, 0U);
					}
					Thread.Sleep(1000);
				}
				if (Recoil.Enabled && ((int)Win32.GetKeyState(1U) & 32768) > 0)
				{
					for (int i = 0; i < Recoil.strength; i++)
					{
						Win32.Move(0, 1);
					}
				}
			}
		}

		// Token: 0x04000126 RID: 294
		public static bool Enabled = false;

		// Token: 0x04000127 RID: 295
		public static int sleeptime = 1;

		// Token: 0x04000128 RID: 296
		public static int strength = 2;
	}
}
