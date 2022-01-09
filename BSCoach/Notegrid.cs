using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BSCoach.Settings;

namespace BSCoach
{
	public class Notegrid : MonoBehaviour
	{
		public static Notegrid Instance { get; private set; }
		public static float PlayerHeight = 1.8f;

		GameObject[] Note = new GameObject[12];

		public Material LineMaterial;

		private readonly float[] noteX = { -.9f, -.3f, .3f, .9f };
		private readonly float[] noteY = { 0.85f, 1.4f, 1.9f };

		public static Vector3[] NotePos = new Vector3[12];

		private Vector3[] notePositions = new Vector3[12];

		private GameObject gridline(int i, Vector3 p)
		{
			GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
			return g;

		}

		void ExampleMethod()
		{
			GameObject GO = gridline(1, Vector3.zero);
		}

		private void Awake()
		{
			//Plugin.log?.Debug($"{name}: Awake()");
			if (Instance != null)
			{
				Plugin.log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
				GameObject.DestroyImmediate(this);
				return;
			}

			GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
			Instance = this;
			transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			gameObject.SetActive(true);

			LineMaterial = new Material(Shader.Find("Sprites/Default"))
			{
				color = new Color(.25f, .25f, .25f, .25f)
			};
		}

		void CreateNotes()
		{
			foreach (GameObject n in Note)
			{
				GameObject.CreatePrimitive(PrimitiveType.Cube);
				n.transform.parent = transform;
				transform.localScale = new Vector3(0.01f, 0.01f, 10f);
				Renderer renderer = n.GetComponent<Renderer>();
				renderer.sharedMaterial = LineMaterial;
			}
		}

		void PositionNotes()
		{
			//float yo = Mathf.Clamp((Plugin.playerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
			//for (int i = 0; i < Note.Length; i++)
			//{
			//	for (int y = 0; y < 3; y++)
			//	{
			//		for (int x = 0; x < 4; x++)
			//		{
			//			Note[i].transform.position = new Vector3(noteX[x], noteY[y], 1.125f);
			//		}
			//	}
			//}
		}



		void Start()
		{
			CreateNotes();
			UpdateNotePositions();
		}


		void UpdateNotePositions()
		{
			//float yo = Mathf.Clamp((PlayerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
			//int i = 0;
			//for (int y = 0; y < 3; y++)
			//{
			//	for (int x = 0; x < 4; x++)
			//	{
			//		Note[i].transform.position = new Vector3(noteX[x], noteY[y] + yo, 1.5f);
			//	}
			//}
		}
	}
}



			//this.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			//Instance = this;

			//for (int i = 0; i < NotePos.Length; i++)
			//{
			//	for (int y = 0; y < noteY.Length; y++)
			//	{
			//		for (int x = 0; x < noteX.Length; x++)
			//		{
			//			NotePos[i] = new Vector3(x, y, 1.125f);
			//		}
			//	}

			//	foreach (GameObject note in Notes)
			//	{
			//		GameObject.DontDestroyOnLoad(note);
			//		GameObject.CreatePrimitive(PrimitiveType.Cube);
			//		note.SetActive(true);
			//		note.transform.SetParent(transform);

			//	}

			//	Plugin.log?.Debug($"{name}: Awake()");
			//	}
			//}

