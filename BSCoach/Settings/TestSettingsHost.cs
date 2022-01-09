using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;


namespace BSCoach.Settings
{
	public class TestSettingsHost : PersistentSingleton<TestSettingsHost>
	{
		[UIParams]
		private BSMLParserParams parserParams;

		[UIValue("notegrid-enabled")]
		public bool Enabled
		{
			get => Configuration.config.Enabled;
			set => Configuration.config.Enabled = value;
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
