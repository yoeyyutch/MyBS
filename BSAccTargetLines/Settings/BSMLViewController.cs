using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BSAccTargetLines.Settings
{
	public class BSMLViewController : BSMLResourceViewController
	{
		internal static object instance;

		public override string ResourceName => "BSAccTargetLines.Settings.BSMLView.bsml";

		[UIValue("targetlines-enabled")]
		public bool Enabled
		{
			get => Configuration.config.Enabled;
			set => Configuration.config.Enabled = value;
		}

		[UIValue("targetlines-enabled-in-menu")]
		public bool EnableInMenu
		{
			get => Configuration.config.EnableInMenu;
			set => Configuration.config.EnableInMenu = value;
		}

		[UIValue("targetlines-enabled-in-song")]
		public bool EnableInSong
		{
			get => Configuration.config.EnableInSong;
			set => Configuration.config.EnableInSong = value;
		}

		[UIAction("#apply")]
		public void OnApply() => StoreConfiguration();

		[UIAction("#ok")]
		public void OnOk() => StoreConfiguration();

		[UIAction("#cancel")]
		public void OnCancel() => ReloadConfiguration();

		/// <summary>
		/// Save and update configuration
		/// </summary>
		private void StoreConfiguration()
		{
			Configuration.Save();
		}

		/// <summary>
		/// Reload configuration and refresh UI
		/// </summary>
		private void ReloadConfiguration()
		{
			RefreshModSettingsUI();
		}

		/// <summary>
		/// Refresh the entire UI
		/// </summary>
		private void RefreshModSettingsUI()
		{
		}
	}
}
