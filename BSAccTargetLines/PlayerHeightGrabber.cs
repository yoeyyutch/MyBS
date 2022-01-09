using BSAccTargetLines.Settings;
using HarmonyLib;
using TMPro;

namespace BSAccTargetLines
{
	public class PlayerHeightGrabber
	{

		[HarmonyPatch(typeof(PlayerHeightSettingsController), "Init")]
		class PleyerHeightSettingsControllerInit
		{
			public static void Postfix(float ____value)
			{
				if ( Plugin.PlayerHeight != ____value)
				{
					Configuration.config.PlayerHeight = ____value;
					NoteGrid.Instance?.UpdateGridPosition();
					Plugin.log.Info("Player height set to " + ____value.ToString("0.00"));
				}
			}
		}

		[HarmonyPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
		class PleyerHeightSettingsControllerRefreshUI
		{
			public static void Postfix(TextMeshProUGUI ____text, float ____value)
			{
				Configuration.config.PlayerHeight = ____value;
				NoteGrid.Instance?.UpdateGridPosition();
				Plugin.log.Info("Player height set to " + ____value.ToString("0.00"));
				____text.text = string.Format("{0:0.00}m", ____value);
			}
		}


	}
}

