using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace MyBS
{
	class NoteLanes : MonoBehaviour
	{
		Material laneMaterial;
		Color laneColor;
		GameObject[] laneGO;

		void Awake()
		{
			laneGO = new GameObject[12];
			Vector2[] notePos = GameData.NotePositions();
			for(int i = 0; i<laneGO.Length; i++)
			{
				laneGO[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				laneGO[i].transform.parent = transform;
				laneGO[i].transform.position = new Vector3(notePos[i].x, notePos[i].y, 0);
				laneGO[i].GetComponent<Renderer>().sharedMaterial = laneMaterial;
			}
		}
	}
}
