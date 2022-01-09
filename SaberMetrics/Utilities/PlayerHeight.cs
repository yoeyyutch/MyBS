using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaberMetrics.Utilities
{
	class PlayerHeight
	{
		private PlayerHeightSettingsController playerHeightSettings;

		public static float Height { get; set; }

		internal void Init()
		{
			playerHeightSettings = Resources.FindObjectsOfTypeAll<PlayerHeightSettingsController>().Last();
			Height = playerHeightSettings.value;
			playerHeightSettings.valueDidChangeEvent += OnPlayerHeightChanged;

			Plugin.Log.Info("___________________________");
			Plugin.Log.Info($" Player Height = {Height: 0.00}m");
			Plugin.Log.Info("___________________________");

		}


		void OnPlayerHeightChanged(float height)
		{
			Height = height;
			Plugin.Log.Info("___________________________");
			Plugin.Log.Info($" Player Height = {Height : 0.00}m");
			Plugin.Log.Info("___________________________");

		}

		//internal void OnExit()
		//{
		//	playerHeightSettings.valueDidChangeEvent -= OnPlayerHeightChanged;
		//}
	}
}
