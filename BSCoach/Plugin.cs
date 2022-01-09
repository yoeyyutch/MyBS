
using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using BSCoach.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BSCoach
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;

		[Init]
		public void Init(IPA.Logging.Logger logger, Config conf)
		{
			log = logger;
			Configuration.Init(conf);
			log.Info("UI initialized.");
		}


		[OnStart]
		public void OnApplicationStart()
		{
			log.Debug("OnApplicationStart");
			new GameObject("BSCoachController").AddComponent<BSCoachController>();
			AddEvents();

		}

		public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
		{


		}

		private void AddEvents()
		{
			RemoveEvents();
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
		}

		private void RemoveEvents()
		{
			SceneManager.activeSceneChanged -= OnActiveSceneChanged;
		}


		[OnExit]
		public void OnApplicationQuit()
		{
			log.Debug("OnApplicationQuit");

		}
	}
}
