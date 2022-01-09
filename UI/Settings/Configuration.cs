﻿using IPA.Config;
using IPA.Config.Stores;

namespace UI.Settings
{
	public class PluginConfig
	{
		public static PluginConfig Instance { get; set; }
		public bool Enabled { get; set; } = true;

		public virtual void Changed()
		{
			Plugin.log.Info("Changed called");
			
			// this is called whenever one of the virtual properties is changed
			// can be called to signal that the content has been changed
		}

		public virtual void OnReload()
		{
			// this is called whenever the config file is reloaded from disk
			// use it to tell all of your systems that something has changed

			// this is called off of the main thread, and is not safe to interact
			//   with Unity in
		}
	}

	public class Configuration
	{

		public static PluginConfig config;

		internal static void Init(Config cfgProvider)
		{
			PluginConfig.Instance = cfgProvider.Generated<PluginConfig>();
			config = PluginConfig.Instance;
		}

		internal static void Save()
		{
			config.Changed();
			UIController.Instance.TestMethod(config.Enabled);
		}
	}
}
