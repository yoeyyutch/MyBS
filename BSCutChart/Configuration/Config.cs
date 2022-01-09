namespace BSCutChart.Configuration
{
	static public class Config
	{
		static BS_Utils.Utilities.Config config;


		static readonly string s = "Settings";




		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(Plugin.PluginName);
		}

		internal static int ShaderIndex
		{
			
			get
			{
				
				return config.GetInt(s, "ShaderIndex", 18, true);
			}
			set
			{
				config.SetInt(s, "ShaderIndex", value);
			}
		}
	}
}