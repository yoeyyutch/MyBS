using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;


namespace MyBS.Settings
{
	public class SettingsViewController : PersistentSingleton<SettingsViewController>
	{
		[UIParams]
		private BSMLParserParams parserParams;

		[UIValue("show-note-lanes")]
		public bool Enabled
		{
			get => Configuration.config.ShowNoteLanes;
			set => Configuration.config.ShowNoteLanes = value;
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
			parserParams.EmitEvent("refresh-ui-values");
		}


	}
}
