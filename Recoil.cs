using System;
using System.Threading;

namespace RecoilTime
{
    internal class Recoil
    {
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

        public static bool Enabled = false;
        public static int sleeptime = 1;
        public static int strength = 2;
    }
}
