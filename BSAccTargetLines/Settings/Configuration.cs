using IPA.Config;
using IPA.Config.Stores;

namespace BSAccTargetLines.Settings
{
	public class PluginConfig
	{
		public static PluginConfig Instance { get; set; }
		public bool Enabled { get; set; } = true;
		public bool EnableInMenu { get; set; } = true;
		public bool EnableInSong { get; set; } = true;

		public string Shader { get; set; } = "Sprites/Default";
		public float R { get; set; } = 0.25f;
		public float G { get; set; } = 0.25f;
		public float B { get; set; } = 0.25f;
		public float A { get; set; } = 0.25f;

		public float GridLineWidth { get; set; } = 1f;
		public float GridLineLength { get; set; } = 10f;

		public float PlayerHeight { get; set; } = 1.6f;

		public virtual void Changed()
		{
			NoteGrid.Instance?.UpdateGridScale();
			NoteGrid.Instance?.UpdateGridAppearance();

			if (Enabled && EnableInMenu)
				NoteGrid.Instance?.ShowGrid(true);
			else
				NoteGrid.Instance?.ShowGrid(false);

		}

		public virtual void OnReload()
		{
			// this is called whenever the config file is reloaded from disk
			// use it to tell all of your systems that something has changed

			// this is called off of the main thread, and is not safe to interact
			//   with Unity in
		}
	}

	public class Configuration
	{
		public static PluginConfig config;

		internal static void Init(Config cfgProvider)
		{
			PluginConfig.Instance = cfgProvider.Generated<PluginConfig>();
			config = PluginConfig.Instance;
		}

		internal static void Save()
		{
			config.Changed();
		}
	}
}
/*
//private Color col = new Color(Configuration.config.R, Configuration.config.G, Configuration.config.B, Configuration.config.A);
//public Color Col
//{
//	get { return col; }
//	set
//	{
//		if (col == value) return;
//		col = value;
//		OnGridColorChange?.Invoke();
//	}
//}

//private float playerHeight = 0f;
//public float PlayerHeight
//{
//	get { return playerHeight; }
//	set
//	{
//		if (playerHeight == value) return;
//		playerHeight = value;
//		OnPlayerHeightChange?.Invoke();
//	}
//}

//public delegate void OnPlayerHeightChangeDelegate();
//public event OnPlayerHeightChangeDelegate OnPlayerHeightChange;

//public delegate void OnGridColorChangeDelegate();
//public event OnGridColorChangeDelegate OnGridColorChange;
*/