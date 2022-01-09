using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace MyBS
{
	public class GameData : ScriptableObject
	{
		public static GameData Instance { get; set; }
		
		public static float PlayerHeight;
		public static readonly float[] Lane = { -0.9f, -0.3f, 0.3f, 0.9f };
		public static readonly float[] Level = { 0.85f, 1.4f, 1.9f };
		public static Vector2 notePositions;

	public static NoteData noteData;
		NoteLineLayer layer;

		public static Vector2[] NotePositions()
		{
			return Utilities.XYCoordinates(Lane, Level);
		}

		//public static void OnEnable()
		//{
		//	ObservableVariable<float> PlayerHeight = new ObservableVariable<float>();
		//	obs.didChangeEvent += OnChange;
		//}

		static void OnChange()
		{

		}

		public static int NoteArrayIndex(int lineIndex, NoteLineLayer lineLayer, NoteCutInfo nci)
		{

			return ((int)lineLayer * 4) + lineIndex;

		}

		public static Vector2 NotePosition(int lineIndex, NoteLineLayer lineLayer)
		{
			return new Vector2(Lane[lineIndex], Level[(int)lineLayer]);
		}



		public static Vector2[] NoteXY()
		{
			Vector2[] v = new Vector2[Lane.Length * Level.Length];
			for(int i=0; i<v.Length; i++)
			{

			}
			return v;
		}

		public static float GetNoteX(int lineIndex)
		{

			/*
			 * Layer = 0 
			 * Multiply times 4
			 * 4*0 = 0
			 * Add lineIndex to result
			 * 0: 0
			 * 1: 1
			 * 2: 2
			 * 3: 3
			 * 
			 * Layer =1
			 * Multiply times 4
			 * 4*1 = 4
			 * Add line index to result
			 * 4+0=4
			 * 4+1=5
			 * 4+2=6
			 * 4+3=7
			 */
			return Lane[lineIndex];
		}
	}

	public class PlayerHeighListener : FloatSignalListener
	{

	}
}
