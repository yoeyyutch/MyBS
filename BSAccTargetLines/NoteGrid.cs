using BSAccTargetLines.Settings;
using UnityEngine;


namespace BSAccTargetLines
{
	public class NoteGrid : MonoBehaviour
	{
		public static NoteGrid Instance;
		private GameObject[] _notes = new GameObject[12];
		private Material gridMat = new Material(Shader.Find("Sprites/Default"));
		private Color gridcolor = new Color(0.5f, 0.6f, 0.7f, 0.3f);

		private void Awake()
		{
			Plugin.log?.Debug($"{name}: Awake()");
			if (Instance != null)
			{
				Plugin.log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
				DestroyImmediate(this);
				return;
			}
			DontDestroyOnLoad(this); // Don't destroy this object on scene changes
			Instance = this;
			transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			Init();
		}

		void Init()
		{
			Plugin.log.Info("InitNotegrid()");
			for (int i = 0; i < _notes.Length; i++)
			{
				_notes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				_notes[i].transform.SetParent(transform);
			}

			UpdateGridPosition();
			UpdateGridScale();
			UpdateGridAppearance();
		}


		public void UpdateGridPosition()
		{
			Plugin.log.Info("UpdateGridTransform()");

			float yOffset = Mathf.Clamp((Configuration.config.PlayerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
			float[] noteX = { -0.9f, -0.3f, 0.3f, 0.9f };
			float[] noteY = { 0.85f + yOffset, 1.4f + yOffset, 1.9f + yOffset};


			int i = 0;
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 4; x++)
				{
					_notes[i].transform.SetPositionAndRotation(new Vector3(noteX[x], noteY[y], 0f), Quaternion.identity);
					Plugin.log.Info($"{i} : {_notes[i].transform.position}");
					i++;
				}
			}
		}

		public void UpdateGridScale()
		{
			Plugin.log.Info("UpdateGridTransform()");

			float xyScale = Configuration.config.GridLineWidth *.01f;
			float zScale = Configuration.config.GridLineLength;
			for (int i = 0; i < _notes.Length; i++)
			{
				_notes[i].transform.localScale = new Vector3(xyScale, xyScale, zScale);
			}
		}

		public void UpdateGridAppearance()
		{
			Plugin.log.Info("UpdateGridAppearance()");
			gridcolor = new Color(Configuration.config.R, Configuration.config.G, Configuration.config.B, Configuration.config.A);

			for (int i = 0; i < _notes.Length; i++)
			{
				Renderer r = _notes[i].GetComponent<Renderer>();
				r.sharedMaterial = gridMat;
				gridMat.color = gridcolor;
			}

			
			//gridMat.color=gridcolor;
		}

		public void ShowGrid(bool show)
		{
			transform.localScale = show ? Vector3.one : Vector3.zero;
		}

		private void OnDestroy()
		{
			Plugin.log?.Debug($"{name}: OnDestroy()");
			if (Instance == this)
				Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.
		}
	}
}



//public void DrawGrid()
//{



//	Color col = new Color(.3f, .6f, .9f, 0.25f);
//	string shader = BSShaders.shaders[0];
//	Vector3 scale = new Vector3(0.01f, 0.01f, 60f);
//	int i = 0;
//	for (int y = 0; y < 3; y++)
//	{
//		for (int x = 0; x < 4; x++)
//		{

//			_notes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

//			_notes[i].SetActive(true);


//			_notes[i].transform.position = new Vector3(noteX[x], noteY[y] + YOffset, 1.5f);
//			if (i == 5 || i == 6)
//			{
//				_notes[i].transform.localScale = Vector3.zero;
//			}
//			else
//				_notes[i].transform.localScale = scale;

//			Renderer renderer = _notes[i].GetComponent<Renderer>();
//			renderer.material = BSShaders.SetMaterial(col, shader, "whocares");

//			Log.Info(col.ToString());
//			i++;
//		}
//	}

