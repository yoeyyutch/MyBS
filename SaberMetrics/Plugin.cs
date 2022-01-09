using IPA;
using IPA.Utilities;
using IPA.Config;
using IPA.Config.Stores;
using IPALogger = IPA.Logging.Logger;
using UnityEngine.SceneManagement;
using BeatSaberHTTPStatus;

namespace SaberMetrics
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	class Plugin
	{
		internal static string PluginName => "SaberMetrics";
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }
		internal static Settings.PluginConfig Config;

		private BSEvents events;
		private BSData data;

		[Init]
		public void Init(IPALogger logger)
		{
			Log = logger;
			Log.Info("  ");
		}

		[OnStart]
		public void OnApplicationStart()
		{
			if (data != null)
				data = null;
			data = new BSData();

			if (events != null)
				events = null;

			events = new BSEvents();
		}

		[OnExit]
		public void OnApplicationQuit()
		{
		
		}
	}
}
