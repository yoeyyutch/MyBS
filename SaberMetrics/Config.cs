using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace SaberMetrics
{
	internal class Config
	{
		public static Config Instance { get; set; }
		public virtual bool Enabled { get; set; } = true;
		public virtual float CurrentHeight { get; set; } = StartingHeight;
		public static float StartingHeight = 1.8f;
	}
}
