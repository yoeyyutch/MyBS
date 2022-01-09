using IPA.Utilities;
using System.IO;

namespace SaberMetrics
{
	public class FileManager
	{
		readonly string userDataFolder = Path.Combine(UnityGame.UserDataPath, PluginOld.PluginName);

		internal void Init()
		{
			Directory.CreateDirectory(userDataFolder);
			//JsonConvert.SerializeObject(NoteResults.NoteLog);
		}
	}
}
