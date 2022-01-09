using System;
using System.Reflection;
using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using IPALogger = IPA.Logging.Logger;
using BS_Utils.Utilities;
using Config = BSCutChart.Configuration.Config;



namespace BSCutChart
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static string PluginName => "BSCutchart";
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }

		private GameObject root;

		//internal static Config PluginConfig;
		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.BSCutchart";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony(HARMONYID);
		[Init]
		/// <summary>
		/// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
		/// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
		/// Only use [Init] with one Constructor.
		/// </summary>
		public void Init(IPALogger logger)
		{
			Instance = this;
			Config.Init();
			Log = logger;
			Log.Info("BSCutChart initialized.");
		}

		#region BSIPA Config
		//Uncomment to use BSIPA's config
		/*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
		#endregion

		[OnStart]
		public void OnApplicationStart()
		{//Log.Debug("OnApplicationStart") 

			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			BSEvents.gameSceneActive += OnGameSceneActive;

			root = new GameObject("MenuCubeGrid");
			Object.DontDestroyOnLoad(root);
			root.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			CreateMenuCubes();
			//new GameObject().AddComponent<BSCutChartController>();
			int x = Configuration.Config.ShaderIndex;
		}

		void CreateMenuCubes()
		{
			float r = .5f;
			float g = .25f;
			float b = .25f;
			float a = 0.75f;
			Color good = Color.green;
			Color blockColor;
			float scale = 0.4f;
			GameObject[] menuCubes = new GameObject[12];

			float[] xGrid = { -.9f, -.3f, .3f, .9f };
			float[] yGrid = { 0.7f, 1.25f, 1.75f };

			int i = 0;
			for (int x = 0; x < 4; x++)
			{
				for (int y = 0; y < 3; y++)
				{
					string shade = BSShaders.shaders[Mathf.Clamp(Config.ShaderIndex + i, 0, BSShaders.shaders.Length-1)];

					//r = Mathf.Clamp01((float)(y+1) / 4);
					//g = Mathf.Clamp01((float)(x+1) / 5);
					//b = Mathf.Clamp01((float)1-(i / 12));
					blockColor = new Color(r, g, b, a);
					menuCubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
					Object.DontDestroyOnLoad(menuCubes[i]);
					menuCubes[i].SetActive(true);
					menuCubes[i].transform.SetParent(root.transform);
					menuCubes[i].transform.position = new Vector3(xGrid[x], yGrid[y], 1.5f);
					menuCubes[i].transform.localScale = Vector3.one * scale;
					Renderer renderer = menuCubes[i].GetComponent<Renderer>();
					renderer.material = BSShaders.SetMaterial(blockColor, shade, "_menublock");
					Log.Info(blockColor.ToString());
					i++;
				}
			}
		}

		private Material SetMaterial(Color color, string name)
		{
			Material glowy = new Material(Shader.Find("Custom/Glowing"));
			Material peebox = new Material(Shader.Find("UI/Default"));
			Material missingMaterial = new Material(Shader.Find("Hidden/InternalErrorShader"));
			Material material = peebox ?? glowy ?? missingMaterial; 
			//Material m = Resources.FindObjectsOfTypeAll<Material>().Where(m => m.name == "Custom/Glowing").FirstOrDefault();

			//Material uinoglow = new Material(Shader.Find("UINoGlow"));
			//
			 

			//if material== null)
			//{
			//	material = uinoglow;
			//}
			//else
			//{
			//	material = glowy != null ? glowy : missingMaterial;
			//}

			material.name = name;
			material.SetColor("_Color", color);

			Log.Info("material : " + material.name);
			Log.Info("Shader    : " + material.shader.name);

			return material;
		}

		public void OnActiveSceneChanged(Scene oldScene, Scene newScene)
		{
			if (newScene.name == "MenuViewControllers")
			{
				BSEvents.menuSceneActive += OnResultsSceneActive;
			}

			if (newScene.name == "MenuCore")
			{
				BSEvents.menuSceneActive += OnMenuSceneActive;
			}

			if (newScene.name == "GameCore")
			{

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
				Log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				Log.Error("Harmony failed to load");
				Log.Error(e.ToString());
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
				Log.Info("Harmony patches unloaded");
			}
			catch (Exception e)
			{
				Log.Error("Harmony failed to unload");
				Log.Error(e.ToString());
			}
			harmonyPatchesLoaded = false;
		}

		void OnGameSceneActive()
		{
			root.SetActive(false);
		}

		void OnMenuSceneActive()
		{
			root.SetActive(true);
		}

		void OnResultsSceneActive()
		{
			root.SetActive(true);
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			BSEvents.gameSceneActive -= OnGameSceneActive;
			BSEvents.menuSceneActive -= OnMenuSceneActive;
			BSEvents.menuSceneActive -= OnResultsSceneActive;


			Object.Destroy(root);
			Log.Debug("OnApplicationQuit");

		}
	}
}
