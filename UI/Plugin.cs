
using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using UI.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using BS_Utils;

namespace UI
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;


		/// <summary>
		/// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
		/// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
		/// Only use [Init] with one Constructor.
		/// </summary>
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

			BSMLSettings.instance.AddSettingsMenu("UI", "UI.Settings.TestSettingsResource.bsml", Settings.TestSettingsHost.instance);

			new GameObject("UIController").AddComponent<UIController>();
			AddEvents();
		}

		void GameSceneActive()
		{
			//if (PluginConfig.Instance.enabled) PerformanceMeterController.instance.GetControllers();
		}

		public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
		{
			//if (ShaderLogCount < Settings.Configuration.config.ShaderLogMax)
			{
				//ShaderLogCount++;
				//Plugin.log.Info(ShaderLogCount.ToString());
				//Utilities.GetMaterials(nextScene);
				//Utilities.GetRenderers(nextScene);
				//Utilities.GetGameObjects(nextScene);
			}
		}

		private void AddEvents()
		{
			RemoveEvents();
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			BS_Utils.Utilities.BSEvents.gameSceneActive += GameSceneActive;
		}

		private void RemoveEvents()
		{
			SceneManager.activeSceneChanged -= OnActiveSceneChanged;
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			RemoveEvents();
			log.Debug("OnApplicationQuit");

		}
	}
}

//GameObject g = UIController.Instance.gameObject;
//g.GetComponent<UIController>().ToggleState();

//if (UIController.Instance.enabled != Configuration.config.Enabled)
//{
//	UIController.Instance.enabled = true;
//	UIController.Instance.ToggleState();
//}

//if (nextScene.name == "GameCore" && !loggedSongShaders)
//{
//	Utilities.GetSceneShaders(nextScene.name);
//	loggedSongShaders = true;
//}

//if (nextScene.name != "GameCore" && Settings.Configuration.config.ShaderLogMax > ShaderLogCount) 
//{
//	Utilities.GetSceneShaders(nextScene.name);
//	ShaderLogCount++;
//}

//if (nextScene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
//{
//	BSMLSettings.instance.AddSettingsMenu("UI", "UI.Settings.TestSettingsResource.bsml", Settings.TestSettingsHost.instance);
//}
