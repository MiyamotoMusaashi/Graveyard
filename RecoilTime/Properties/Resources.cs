using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RecoilTime.Properties
{
	// Token: 0x02000018 RID: 24
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600014E RID: 334 RVA: 0x00003972 File Offset: 0x00001B72
		internal Resources()
		{
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00012197 File Offset: 0x00010397
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("RecoilTime.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000121C3 File Offset: 0x000103C3
		// (set) Token: 0x06000151 RID: 337 RVA: 0x000121CA File Offset: 0x000103CA
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000135 RID: 309
		private static ResourceManager resourceMan;

		// Token: 0x04000136 RID: 310
		private static CultureInfo resourceCulture;
	}
}
