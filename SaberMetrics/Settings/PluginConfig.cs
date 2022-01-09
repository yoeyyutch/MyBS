
using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberMetrics.Settings
{
	internal class PluginConfig
	{
		public static PluginConfig Instance { get; set; }

		public virtual bool Enabled { get; set; } = true;
		public virtual float CurrentHeight { get; set; } = StartingHeight;
		public static float StartingHeight = 1.8f;
		//public virtual bool LogAllNoteAndCutStats { get; set; } = false;
		//public virtual bool LogBasicNoteAndCutStats { get; set; } = true;

		//public virtual int LogCapacity { get; set; } = 10;

		/// <summary>
		/// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
		/// </summary>
		//public virtual void OnReload()
		//{
		//	Plugin.Log.Info("Config.OnReload() called");
		//	// Do stuff after config is read from disk.
		//}

		/// <summary>
		/// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
		/// </summary>
		//public virtual void Changed()
		//{
		//	Plugin.Log.Info("Config.Changed() called");
		//	// Do stuff when the config is changed.
		//}

		/// <summary>
		/// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
		/// </summary>
		//public virtual void CopyFrom(PluginConfig other)
		//{
		//	// This instance's members populated from other
		//}
	}
}

