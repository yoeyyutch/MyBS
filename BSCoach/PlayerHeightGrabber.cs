using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace BSCoach
{
	class PlayerHeightGrabber
	{
		[HarmonyPatch(typeof(PlayerHeightSettingsController), "Init")]
		class PleyerHeightSettingsControllerInit
		{
			public static void Postfix(float ____value)
			{
				UpdatePlayerHeight(____value);
			}
		}

		[HarmonyPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
		class PleyerHeightSettingsControllerRefreshUI
		{
			public static void Postfix(TextMeshProUGUI ____text, float ____value)
			{
				____text.text = string.Format("{0:0.000}m", ____value);
				UpdatePlayerHeight(____value);
			}
		}

		private static void UpdatePlayerHeight(float value)
		{
			if (Notegrid.PlayerHeight != value)
			{
				Notegrid.PlayerHeight = value;
				//Notegrid.Instance.UpdateNotePositions();
				//Plugin.log.Info($"Height set: {value}");
			}
		}


	}
}

