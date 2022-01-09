using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace HeightUtility
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{

		internal static string PluginName => "HeightUtility";
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;


		[Init]
		public void Init(IPA.Logging.Logger logger, Config conf)
		{
			log = logger;
			Instance = this;
			HeightUtility.Co.Configuration.Init(conf);
			MyHarmony.LoadHarmonyPatches();
			log.Info("Init");
		}

		#region BSIPA Config
		//Uncomment to use BSIPA's config
		/*
		[Init]
		public void InitWithConfig(Config conf)
		{
			Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
			Log.Debug("Config loaded");
		}
		*/
		#endregion

		[OnStart]
		public void OnApplicationStart()
		{
			Log.Debug("OnApplicationStart");
			new GameObject("HeightUtilityController").AddComponent<HeightUtilityController>();

		}

		[OnExit]
		public void OnApplicationQuit()
		{
			Log.Debug("OnApplicationQuit");

		}
	}
}
