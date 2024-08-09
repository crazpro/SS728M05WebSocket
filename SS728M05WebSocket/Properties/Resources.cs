using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SS728M05WebSocket.Properties
{
	// Token: 0x0200000C RID: 12
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00002564 File Offset: 0x00000764
		internal Resources()
		{
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002FE6 File Offset: 0x000011E6
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("SS728M05WebSocket.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003012 File Offset: 0x00001212
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00003019 File Offset: 0x00001219
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

		// Token: 0x0400002D RID: 45
		private static ResourceManager resourceMan;

		// Token: 0x0400002E RID: 46
		private static CultureInfo resourceCulture;
	}
}
