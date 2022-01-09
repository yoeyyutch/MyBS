using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SaberMetrics
{
	internal static class Utilities
	{
		internal static T FindLast<T>() where T : UnityEngine.Object
		{
			T obj = Resources.FindObjectsOfTypeAll<T>().Last();
			if (obj == null)
			{
				PluginOld.Log.Error("Couldn't find " + typeof(T).FullName);
				throw new InvalidOperationException("Couldn't find " + typeof(T).FullName);
			}
			return obj;
		}

		internal static T FindFirstOrDefault<T>() where T : UnityEngine.Object
		{
			T obj = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
			if (obj == null)
			{
				PluginOld.Log.Error("Couldn't find " + typeof(T).FullName);
				throw new InvalidOperationException("Couldn't find " + typeof(T).FullName);
			}
			return obj;
		}

		internal static T FindFirstOrDefaultOptional<T>() where T : UnityEngine.Object
		{
			T obj = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
			return obj;

		}

		internal static NoteData[] BeatmapNoteList(IDifficultyBeatmap beatmap, BeatmapObjectData[] beatmapObjects)
		{
			var output = new NoteData[beatmap.beatmapData.cuttableNotesType];

			int i = 0;

			foreach (BeatmapObjectData beatmapObject in beatmap.beatmapData.beatmapObjectsData)
			{
				if (beatmapObject is NoteData noteData)
				{
					output[i++] = noteData;
				}
			}

			return output;

		}

		public static long GetCurrentTime()
		{
			return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		}
	}
}
