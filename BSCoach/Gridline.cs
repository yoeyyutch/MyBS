using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BSCoach
{
	class Gridline : MonoBehaviour
	{
		GameObject line;
		private Renderer _renderer;
		private MaterialPropertyBlock _propBlock;

		void Awake()
		{
			_propBlock = new MaterialPropertyBlock();
			_renderer = GetComponent<Renderer>();
		}

		void Start()
		{
			line = GameObject.CreatePrimitive(PrimitiveType.Cube);
		}
	}
}
