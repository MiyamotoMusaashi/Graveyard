using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace RecoilTime.Properties
{
	// Token: 0x02000019 RID: 25
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000121D2 File Offset: 0x000103D2
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000137 RID: 311
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
