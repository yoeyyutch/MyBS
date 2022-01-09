using UnityEngine;

namespace SaberMetrics
{
	class NoteResults
	{
		static public int notesLogged;
		//internal static List<Entry> NoteLog;

		// lane, level, type, direction

		static NoteResults()
		{
			notesLogged = 0;
			//NoteLog = new List<Entry>();

		}

		public struct Entry
		{
			public NoteData Note;
			public NoteCutInfo Cut;
			public int BeforeCutScore;
			public int AfterCutScore;
			public int AccCutScore;
			public int Multiplier;

			public Entry(NoteData noteData, NoteCutInfo cutInfo, int beforeCutScore, int afterCutScore, int accCutScore, int multiplier)
			{
				Note = noteData;
				Cut = cutInfo;
				BeforeCutScore = beforeCutScore;
				AfterCutScore = afterCutScore;
				AccCutScore = accCutScore;
				Multiplier = multiplier;
			}

		}

		public struct BasicResult
		{
			public float noteTime;
			public int noteX;
			public int noteY;
			public string noteType;
			public NoteCutDirection noteDirection;

			public Vector3 cutPoint;
			public Vector3 cutNormal;
			public float cutMissDistance;
			public float cutTimeDeviation;

			//public Vector3Int cutScore;
			

			public BasicResult(NoteData note, NoteCutInfo cut)
			{
				noteTime = note.time;
				noteX = note.lineIndex;
				noteY = (int)note.noteLineLayer;
				noteType = NoteTypeString((int)note.colorType);
				noteDirection = note.cutDirection;


				cutPoint = cut.cutPoint;
				cutNormal = cut.cutNormal;
				cutMissDistance = cut.cutDistanceToCenter;
				cutTimeDeviation = cut.timeDeviation;

				//cutScore = new Vector3Int(beforeCutScore, afterCutScore, accCutScore);
			}
		}

		public static Vector2 NoteCenter(int line, int layer)
		{
			float x = (-1.5f + (float)line) * 0.6f;
			float y = PlayerHeightOffset(Harmony.PlayerHeightGrabber.PlayerHeight);
			if (layer == 0)
				y += 0.85f; // 0.85 - .033038 = 0.816962
			if (layer == 1)
				y += 1.4f;  // 1.40 - .033038 = 1.366962
			if (layer == 2)
				y += 1.9f;  // 1.90 - .033038 = 1.866962

			return new Vector2(x, y);

		}

		public static float PlayerHeightOffset(float height)
		{
			return Mathf.Clamp((height - 1.8f) * 0.5f, -0.2f, 0.6f);
			// Height of 1.733924 gives offset of  -.033038
		}

		public static string NoteTypeString(int noteType)
		{
			if (noteType == 0)
				return "L";
			if (noteType == 1)
				return "R";
			else
				return "Bomb";
		}

		static public void ProcessBasicResult(NoteData noteData, NoteCutInfo cutInfo) 
		{
			BasicResult result = new BasicResult(noteData, cutInfo);
			if (notesLogged == 0)
			{
				string header = "{notesLogged}, {result.noteType}, {NoteCenter(result.noteX,result.noteY).ToString()}, { result.cutPoint.ToString()}, Normal:{result.cutNormal.ToString()}, {result.cutMissDistance : 0.000}, {result.cutTimeDeviation : 0.000}, {result.noteDirection}";

				PluginOld.Log.Info(header);
				notesLogged++;

			}
			PluginOld.Log.Info($"{notesLogged}, {result.noteType}, {NoteCenter(result.noteX,result.noteY).ToString("F3")}, { result.cutPoint.ToString("F3")}, Normal:{result.cutNormal.ToString("F3")}, {result.cutMissDistance : 0.000}, {result.cutTimeDeviation : 0.000}, {result.noteDirection}");
			notesLogged++;
		}

		//public struct Cal
		//{
		//	public NoteData Note;
		//	public NoteCutInfo Cut;
		//	public int BeforeCutScore;
		//	public int AfterCutScore;
		//	public int AccCutScore;
		//	public int Multiplier;

		//	public Cal(NoteData noteData, NoteCutInfo cutInfo, int beforeCutScore, int afterCutScore, int accCutScore, int multiplier)
		//	{
		//		Note = noteData;
		//		Cut = cutInfo;
		//		BeforeCutScore = beforeCutScore;
		//		AfterCutScore = afterCutScore;
		//		AccCutScore = accCutScore;
		//		Multiplier = multiplier;
		//	}

		//}
		//static public Entry ProcessedNote(NoteData noteData, NoteCutInfo cutInfo, int beforeCutScore, int afterCutScore, int accCutScore, int multiplier) 
		//{
		//	Entry result = new Entry(noteData, cutInfo, beforeCutScore, afterCutScore, accCutScore, multiplier);
		//	return result;
		//}

//		static public void ProcessNote(NoteData noteData, NoteCutInfo cutInfo, int beforeCutScore, int afterCutScore, int accCutScore, int multiplier)
//		{
//			//if (notesLogged < PluginConfig.Instance.LogCapacity)
//			//{


//			Entry result = new Entry(noteData, cutInfo, beforeCutScore, afterCutScore, accCutScore, multiplier);
			
//;

//			string dataEntry = "{ notesLogged}, { noteData.colorType}, { noteData.cutDirection}, { noteData.lineIndex}, {(int)noteData.noteLineLayer}, [{ cutInfo.cutPoint : 0.000}], { cutInfo.cutAngle}, { cutInfo.cutDistanceToCenter : 0.000}, {cutInfo.timeDeviation : 0.000},  {accCutScore}";

			

//			if (notesLogged == 0)
//			{
//				Plugin.Log.Info(dataEntry);
//				notesLogged++;

//			}
//			Plugin.Log.Info($"{ notesLogged}, {accCutScore}, { noteData.colorType}, { noteData.cutDirection}, { noteData.lineIndex}, {(int)noteData.noteLineLayer}, { cutInfo.cutPoint : F3}, {cutInfo.cutDistanceToCenter : 0.000}");

//			/*
//			Unused data:
//			{cutInfo.timeDeviation : 0.000},  
			
//			 */
//			notesLogged++;
//			//}
//			//if (PluginConfig.Instance.LogAllNoteAndCutStats) 
//			//{
//			//	NoteLog.Add(result);
//			//}

//		}
	}

}

//public enum NoteCutDirection
//{
//	Up = 0,
//	Down = 1,
//	Left = 2,
//	Right = 3,
//	UpLeft = 4,
//	UpRight = 5,
//	DownLeft = 6,
//	DownRight = 7,
//	Any = 8,
//	None = 9
//}