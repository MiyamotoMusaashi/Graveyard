using System;
using System.Windows.Forms;

namespace RecoilTime
{
	// Token: 0x02000015 RID: 21
	internal static class Program
	{
		// Token: 0x06000145 RID: 325 RVA: 0x000120C6 File Offset: 0x000102C6
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
