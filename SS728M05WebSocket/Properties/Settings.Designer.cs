using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace SS728M05WebSocket.Properties
{
	// Token: 0x0200000D RID: 13
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003021 File Offset: 0x00001221
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400002F RID: 47
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
