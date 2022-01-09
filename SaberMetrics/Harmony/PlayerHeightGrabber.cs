using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaberMetrics.Harmony
{
	class PlayerHeightGrabber
	{
		public static float PlayerHeight;

		[HarmonyPatch(typeof(PlayerHeightSettingsController), "Init")]
		class PleyerHeightSettingsControllerInit
		{
			public static void Postfix(float ____value)
			{
				if (Plugin.Config.CurrentHeight!= ____value) 
				{
					PlayerHeight  = ____value;
					Plugin.Config.CurrentHeight = PlayerHeight;
					Plugin.Log.Info($"Height set: {____value}");
				}
				
				
			}
		}

		[HarmonyPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
		class PleyerHeightSettingsControllerRefreshUI
		{		
			public static void Postfix(float ____value)
			{
				if (Plugin.Config.CurrentHeight != ____value)
				{
					PlayerHeight = ____value;
					Plugin.Config.CurrentHeight = PlayerHeight;
					Plugin.Log.Info($"Height change: {____value}");
				}
			}
		}


	}
}

