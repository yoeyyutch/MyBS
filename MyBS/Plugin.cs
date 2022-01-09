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


namespace MyBS
{

	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static string PluginName => "MyBS";
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;


		[Init]
		public void Init(IPA.Logging.Logger logger, Config conf)
		{
			log = logger;
			Instance = this;
			Settings.Configuration.Init(conf);
			MyHarmony.LoadHarmonyPatches();
			log.Info("Init");
		}

		[OnStart]
		public void OnApplicationStart()
		{
			log.Debug("OnApplicationStart");
			new GameObject("MyBSController").AddComponent<MyBSController>();

		}

		[OnExit]
		public void OnApplicationQuit()
		{
			log.Debug("OnExit");
			MyHarmony.UnloadHarmonyPatches();

		}
	}
}
