using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SaberMetrics
{
	class GameCoreManager :IInitializable
	{
		private GameplayCoreSceneSetupData gameplayCoreSceneSetupData;
		private PauseController pauseController;
		private ScoreController scoreController;
		private MultiplayerSessionManager multiplayerSessionManager;
		private MultiplayerController multiplayerController;
		private MultiplayerLocalActivePlayerFacade multiplayerLocalActivePlayerFacade;
		private MonoBehaviour gameplayManager;
		private GameplayModifiersModelSO gameplayModifiersSO;
		private GameplayModifiers gameplayModifiers;
		private AudioTimeSyncController audioTimeSyncController;
		private BeatmapObjectCallbackController beatmapObjectCallbackController;
		private PlayerHeadAndObstacleInteraction playerHeadAndObstacleInteraction;
		private GameSongController gameSongController;
		private GameEnergyCounter gameEnergyCounter;
		private Dictionary<NoteCutInfo, NoteData> noteCutMapping = new Dictionary<NoteCutInfo, NoteData>();
		private BeatmapObjectManager beatmapObjectManager;

		/// private PlayerHeadAndObstacleInteraction ScoreController._playerHeadAndObstacleInteraction;
		private FieldInfo scoreControllerHeadAndObstacleInteractionField = typeof(ScoreController).GetField("_playerHeadAndObstacleInteraction", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		/// protected NoteCutInfo CutScoreBuffer._noteCutInfo
		private FieldInfo noteCutInfoField = typeof(CutScoreBuffer).GetField("_noteCutInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		/// protected List<CutScoreBuffer> ScoreController._cutScoreBuffers // contains a list of after cut buffers
		private FieldInfo afterCutScoreBuffersField = typeof(ScoreController).GetField("_cutScoreBuffers", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		/// private int CutScoreBuffer#_multiplier
		private FieldInfo cutScoreBufferMultiplierField = typeof(CutScoreBuffer).GetField("_multiplier", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
		/// private static LevelCompletionResults.Rank LevelCompletionResults.GetRankForScore(int score, int maxPossibleScore)
		private MethodInfo getRankForScoreMethod = typeof(LevelCompletionResults).GetMethod("GetRankForScore", BindingFlags.NonPublic | BindingFlags.Static);

		public GameCoreManager()
		{
			Initialize();
		}

		public void LoadGameCore()
		{

		}
		public void Initialize()
		{
			gameplayCoreSceneSetupData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			IDifficultyBeatmap map = gameplayCoreSceneSetupData.difficultyBeatmap;
			int mapNoteCount = map.beatmapData.cuttableNotesType;
			var beatmapObjects = gameplayCoreSceneSetupData.difficultyBeatmap.beatmapData.beatmapObjectsData;
			BeatmapData mapData = gameplayCoreSceneSetupData.difficultyBeatmap.beatmapData.GetCopyWithoutEvents();
			pauseController = Utilities.FindFirstOrDefaultOptional<PauseController>();
			scoreController = Utilities.FindFirstOrDefault<ScoreController>();
			gameplayManager = Utilities.FindFirstOrDefaultOptional<StandardLevelGameplayManager>() as MonoBehaviour ?? Utilities.FindFirstOrDefaultOptional<MissionLevelGameplayManager>();
			beatmapObjectCallbackController = Utilities.FindFirstOrDefault<BeatmapObjectCallbackController>();
			gameplayModifiersSO = Utilities.FindFirstOrDefault<GameplayModifiersModelSO>();
			audioTimeSyncController = Utilities.FindFirstOrDefault<AudioTimeSyncController>();
			playerHeadAndObstacleInteraction = (PlayerHeadAndObstacleInteraction)scoreControllerHeadAndObstacleInteractionField.GetValue(scoreController);
			gameSongController = Utilities.FindFirstOrDefault<GameSongController>();
			gameEnergyCounter = Utilities.FindFirstOrDefault<GameEnergyCounter>();
		}

	}
}
