using BeatSaberMarkupLanguage.Settings;
using BSAccTargetLines.Settings;
using IPA;
using IPA.Config;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BSAccTargetLines
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		public static IPA.Logging.Logger log;
			
		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.BSAccTargetLines";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony(HARMONYID);

		public static bool InMenu = true;
		public static float PlayerHeight = 1.7f;

		[Init]
		public void Init(IPA.Logging.Logger logger, Config conf)
		{
			log = logger;
			Configuration.Init(conf);
			log.Info("Config loaded");
		}

		[OnStart]
		public void OnApplicationStart()
		{
			LoadHarmonyPatches();
			new GameObject("NoteGrid").AddComponent<NoteGrid>();
			BSMLSettings.instance.AddSettingsMenu("NoteGrid", "BSAccTargetLines.Settings.NotegridSettings.bsml", NotegridSettings.instance);

			AddEvents();
		}

		private void AddEvents()
		{
			RemoveEvents();
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			//BS_Utils.Utilities.BSEvents.gameSceneActive += GameSceneActive;
			//BS_Utils.Utilities.BSEvents.menuSceneActive += MenuSceneActive;
		}

		private void RemoveEvents()
		{
			SceneManager.activeSceneChanged -= OnActiveSceneChanged;
			//BS_Utils.Utilities.BSEvents.gameSceneActive -= GameSceneActive;
			//BS_Utils.Utilities.BSEvents.menuSceneActive -= MenuSceneActive;
		}


		public static void HeightChanged(float value)
		{
			PlayerHeight = value;
			NoteGrid.Instance.UpdateGridPosition();

		}

		public void OnActiveSceneChanged(Scene prevScene, Scene newScene)
		{
			if (!Configuration.config.Enabled)
			{
				NoteGrid.Instance.ShowGrid(false);
				return;
			}

			InMenu = newScene.name == "GameCore" ? false : true;
			
			if (!InMenu)
			{
				if(!Configuration.config.EnableInSong || Resources.FindObjectsOfTypeAll<MultiplayerController>().LastOrDefault() != null)
				{
					NoteGrid.Instance.ShowGrid(false);
					return;
				}
			}

			if (InMenu)
			{
				if (!Configuration.config.EnableInMenu)
				{
					NoteGrid.Instance.ShowGrid(false);
					return;
				}
			}

			NoteGrid.Instance.ShowGrid(true);

			if (newScene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
			{

				//SettingUiLoad?.Invoke();
			}
		}

		internal void LoadHarmonyPatches()
		{
			if (harmonyPatchesLoaded)
			{
				//Logger.Log.Info("Harmony patches already loaded. Skipping...");
				return;
			}
			try
			{
				harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
				log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				log.Error("Harmony failed to load");
				log.Error(e.ToString());
			}
			harmonyPatchesLoaded = true;
		}
		internal void UnloadHarmonyPatches()
		{
			if (!harmonyPatchesLoaded)
			{
				return;
			}
			try
			{
				harmonyInstance.UnpatchAll(HARMONYID);
				log.Info("Harmony patches unloaded");
			}
			catch (Exception e)
			{
				log.Error("Harmony failed to unload");
				log.Error(e.ToString());
			}
			harmonyPatchesLoaded = false;
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			RemoveEvents();
			UnloadHarmonyPatches();
			GameObject.Destroy(NoteGrid.Instance);
		}
	}
}

//public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
//{

//}
//public void InitializeNoteGrid()
//{
//	if (gridGO == null)
//	{
//		gridGO = new GameObject("NoteGrid", typeof(NoteGrid));
//		//noteGrid = gridGO.GetComponent<NoteGrid>();
//		GameObject.DontDestroyOnLoad(gridGO);

//	}
//}

//public void UpdateNoteGrid()
//{

//	NoteGrid.Instance.DrawGrid();
//}
///*
//         Log("actve scene : {0}", scene.name);
//         LogGameobjects();
//         /*Scene[] scenes=UnityEngine.SceneManagement.SceneManager.GetAllScenes();
//         foreach (Scene s in scenes) {
//             Log("\tscene name : {0}", s.name);
//             LogGameobjects(s);
//         }//*/


//public void LoadConfig()
//{
//	EnablePlugin = Config.EnablePlugin;
//	VisibleInMenu = Config.VisibleInMenu;
//	VisibleInSong = Config.VisibleInSong;
//}

//static public void DrawGrid()
//{
//	DestroyGrid();
//	CreateGrid();
//}

//static public void CreateGrid()
//{
//	grid = new GameObject("Grid");
//	Object.DontDestroyOnLoad(grid);
//	grid.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

//	float yOffset = YOffset(playerHeight);
//	float[] xGrid = { -.9f, -.3f, .3f, .9f };
//	float[] yGrid = { _baseY + yOffset, _midY + yOffset, _topY + yOffset };

//	GameObject[] gridlines = new GameObject[12];
//	Color col = new Color(.3f, .6f, .9f, 0.25f);
//	string shader = BSShaders.shaders[0];
//	Vector3 scale = new Vector3(0.01f, 0.01f, 60f);
//	int i = 0;
//	for (int y = 0; y < 3; y++)
//	{
//		for (int x = 0; x < 4; x++)
//		{

//			gridlines[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			Object.DontDestroyOnLoad(gridlines[i]);
//			gridlines[i].SetActive(true);

//			gridlines[i].transform.SetParent(grid.transform);
//			gridlines[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1.5f);
//			if (i == 5 || i == 6)
//			{
//				gridlines[i].transform.localScale = Vector3.zero;
//			}
//			else
//				gridlines[i].transform.localScale = scale;

//			Renderer renderer = gridlines[i].GetComponent<Renderer>();
//			renderer.material = BSShaders.SetMaterial(col, shader, "whocares");

//			//Log.Info(col.ToString());
//			i++;
//		}
//	}
//}

//static public void DestroyGrid()
//{
//	if (grid != null)
//	{
//		Object.Destroy(grid);
//		//grid=null;
//	}
//}

//public static float YOffset(float playerHeight)
//{
//	return Mathf.Clamp((playerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
//}

//void OnGameSceneActive()
//{
//	grid.SetActive(false);
//}

//void OnMenuSceneActive()
//{
//	grid.SetActive(true);
//}

//void OnResultsSceneActive()
//{
//	grid.SetActive(true);
//}
