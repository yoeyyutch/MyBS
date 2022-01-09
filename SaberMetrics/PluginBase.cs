using IPA;

namespace SaberMetrics
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class PluginBase
	{
		internal static PluginConfig Config;
		//internal const string HARMONYID = "com.yoeyyutch.BeatSaber.SaberMetrics";
		//internal static bool harmonyPatchesLoaded = false;
		//internal static readonly HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony(HARMONYID);

		private DataStreamBS dataStreamBS;
		private StatusManager statusManager;
		private GameStatus gameStatus;
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }


		//private StatusManager statusManager = new StatusManager();
		//internal NoteEventManager NoteEventManager;
		//internal GameCoreManager gMan;
		//
		//private GameplayCoreSceneSetupData gameplayCoreSceneSetupData;
		//private PauseController pauseController;
		//private ScoreController scoreController;
		//private MultiplayerSessionManager multiplayerSessionManager;
		//private MultiplayerController multiplayerController;
		//private MultiplayerLocalActivePlayerFacade multiplayerLocalActivePlayerFacade;
		//private MonoBehaviour gameplayManager;
		//private GameplayModifiersModelSO gameplayModifiersSO;
		//private GameplayModifiers gameplayModifiers;
		//private AudioTimeSyncController audioTimeSyncController;
		//private BeatmapObjectCallbackController beatmapObjectCallbackController;
		//private PlayerHeadAndObstacleInteraction playerHeadAndObstacleInteraction;
		//private GameSongController gameSongController;
		//private GameEnergyCounter gameEnergyCounter;
		//private Dictionary<NoteCutInfo, NoteData> noteCutMapping = new Dictionary<NoteCutInfo, NoteData>();

		///// private PlayerHeadAndObstacleInteraction ScoreController._playerHeadAndObstacleInteraction;
		//private FieldInfo scoreControllerHeadAndObstacleInteractionField = typeof(ScoreController).GetField("_playerHeadAndObstacleInteraction", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		///// protected NoteCutInfo CutScoreBuffer._noteCutInfo
		//private FieldInfo noteCutInfoField = typeof(CutScoreBuffer).GetField("_noteCutInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		///// protected List<CutScoreBuffer> ScoreController._cutScoreBuffers // contains a list of after cut buffers
		//private FieldInfo afterCutScoreBuffersField = typeof(ScoreController).GetField("_cutScoreBuffers", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		///// private int CutScoreBuffer#_multiplier
		//private FieldInfo cutScoreBufferMultiplierField = typeof(CutScoreBuffer).GetField("_multiplier", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		///// private static LevelCompletionResults.Rank LevelCompletionResults.GetRankForScore(int score, int maxPossibleScore)
		//private MethodInfo getRankForScoreMethod = typeof(LevelCompletionResults).GetMethod("GetRankForScore", BindingFlags.NonPublic | BindingFlags.Static);


		[Init]
		public void Init(Config config, IPALogger logger)
		{
			Config = config.Generated<PluginConfig>();
			Log = logger;
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			dataStreamBS = null;
			//BS_Utils.Utilities.BSEvents.gameSceneActive -= OnGameSceneActive;
			//SceneManager.activeSceneChanged -= OnActiveSceneChanged;
			//PluginConfig.StartingHeight = Plugin.Config.CurrentHeight;
			//NoteResults.notesLogged = 0;
			//UnloadHarmonyPatches();
		}



		[OnStart]
		public void OnApplicationStart()
		{
			if (Instance != null) return;
			Instance = this;
			dataStreamBS = new DataStreamBS();
			gameStatus = statusManager.gameStatus;

			//
			//BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneActive;
			//BS_Utils.Utilities.BSEvents.gameSceneActive += OnGameSceneActive;
			//SceneManager.activeSceneChanged += OnActiveSceneChanged;

			//Plugin.Log.Info("OnApplicationStart");
			//if (Config.Enabled)
			//{
			//	Plugin.Config.CurrentHeight = PluginConfig.StartingHeight;
			//	LoadHarmonyPatches();
			//	new FileManager().Init();
			//	//new PlayerHeight().Init();
			//	new NoteEvents().Init();
			//}
			//else
			//	Plugin.Log.Info("Plugin disabled ");
		}

		//public void OnActiveSceneChanged(Scene oldScene, Scene newScene)
		//{

		//	if (oldScene.name == "GameCore")
		//	{
		//		// Song finished. Do something.
		//		// 
		//		if(newScene.name == "MenuViewControllers")
		//		{
		//			//On Song results screen. 
		//			//Do something.
		//		}

		//	}

		//	if (newScene.name == "MenuCore")
		//	{
		//		//
		//		// Menu
		//		// TODO: get the current song, mode and mods while in menu
		//		//HandleMenuStart();
		//	}
		//	else if (newScene.name == "GameCore")
		//	{
		//		if (gMan != null)
		//			gMan = null;
		//		gMan = new GameCoreManager();

		//		// In game
		//		//HandleSongStart();
		//	}

		//}

		public void OnGameSceneActive()
		{
			//gameplayCoreSceneSetupData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			//IDifficultyBeatmap map = gameplayCoreSceneSetupData.difficultyBeatmap;
			//int mapNoteCount = map.beatmapData.cuttableNotesType;
			//var beatmapObjects = gameplayCoreSceneSetupData.difficultyBeatmap.beatmapData.beatmapObjectsData;
			//BeatmapData mapData = gameplayCoreSceneSetupData.difficultyBeatmap.beatmapData.GetCopyWithoutEvents();
			//pauseController = Utilities.FindFirstOrDefaultOptional<PauseController>();
			//scoreController = Utilities.FindFirstOrDefault<ScoreController>();
			//gameplayManager = Utilities.FindFirstOrDefaultOptional<StandardLevelGameplayManager>() as MonoBehaviour ?? Utilities.Utilities.FindFirstOrDefaultOptional<MissionLevelGameplayManager>();
			//beatmapObjectCallbackController = Utilities.FindFirstOrDefault<BeatmapObjectCallbackController>();
			//gameplayModifiersSO = Utilities.FindFirstOrDefault<GameplayModifiersModelSO>();
			//audioTimeSyncController = Utilities.FindFirstOrDefault<AudioTimeSyncController>();
			//playerHeadAndObstacleInteraction = (PlayerHeadAndObstacleInteraction)scoreControllerHeadAndObstacleInteractionField.GetValue(scoreController);
			//gameSongController = Utilities.FindFirstOrDefault<GameSongController>();
			//gameEnergyCounter = Utilities.FindFirstOrDefault<GameEnergyCounter>();
		}
	}
}