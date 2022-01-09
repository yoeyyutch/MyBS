using UnityEngine;

namespace SaberMetrics
{
	class NoteEvents
	{

		private NoteCutInfo cut = null;
		private NoteData note = null;
		private int comboX = 0;

		///int cutCount;

		internal void Init()
		{
			//Plugin.Log.Info("NoteEvents called");
			//cutCount = 0;
			BS_Utils.Utilities.BSEvents.noteWasCut += OnNoteCut;
			BS_Utils.Utilities.BSEvents.noteWasMissed += OnNoteMissed;
			//IGameNoteControllerInitializable<GameNoteController> game =
			//game.d
		}

		void OnNoteCut(NoteData noteData, NoteCutInfo noteCutInfo, int multiplier)
		{
			GameObject GO = new GameObject();
			noteData.beatmapObjectType.GetType();
			//Plugin.Log.Info("OnNoteCut called");
			if (!noteCutInfo.allIsOK)
				return;

			else
			{
				NoteResults.ProcessBasicResult(noteData, noteCutInfo);
				//comboX = multiplier;
				//note = noteData;
				//cut = noteCutInfo;
				//cut.swingRatingCounter.didFinishEvent += OnSaberSwingRatingCounterFinished;
			}

		}
		private void OnSaberSwingRatingCounterFinished(ISaberSwingRatingCounter saberSwingRatingCounter)
		{
			//Plugin.Log.Info("OnSaberSwingRatingCounterFinished called");
			ScoreModel.RawScoreWithoutMultiplier(cut, out var beforeCutRawScore, out var afterCutRawScore, out var cutDistanceRawScore);
			//NoteResults.ProcessNote(note, cut, beforeCutRawScore, afterCutRawScore, cutDistanceRawScore, comboX);
			//cutCount++;
			cut.swingRatingCounter.didFinishEvent -= OnSaberSwingRatingCounterFinished;
		}
		void OnNoteMissed(NoteData noteData, int multiplier)
		{
			//Not going to process missed notes for now
			//unless I can figureout how to get info about the swing.

			//if (noteData.colorType != ColorType.None)
			//{

			//	//NoteResults.ProcessNote(noteData, null, 0, 0, 0, multiplier);
			//}
		}

		//public void OnExit()
		//{
		//	BS_Utils.Utilities.BSEvents.noteWasCut -= OnNoteCut;
		//	BS_Utils.Utilities.BSEvents.noteWasMissed -= OnNoteMissed;
		//}
	}
}
/*
 * Note xy position:
 * public virtual Vector3 GetNoteOffset(int noteLineIndex, NoteLineLayer noteLineLayer)
{
	return new Vector2((-1.5 + (float)noteLineIndex) * 0.6, this.LineYPosForLineLayer(noteLineLayer));
	note noteLineIndex starts at 1 for the left lane so using the above method 
	
X Positions
	lane 1 = -0.9
	lane 2 = -0.3
	lane 3 = 0.3
	lane 4 = 0.9
		
}
	n = -(4-1) * .5
n = -3 *.5 = -1.5
n = (-1.5 +

Note Y Position:
Add the result of JumpOffestForPlayerHeight to the starting values for each line.

	protected float _baseLinesYPos = 0.25f;

	protected float _upperLinesYPos = 0.85f;
 
	protected float _topLinesYPos = 1.45f;

public class BeatmapObjectSpawnControllerPlayerHeightSetter : MonoBehaviour
{
	...
	public static float JumpOffsetYForPlayerHeight(float playerHeight)
	{
		return Mathf.Clamp((playerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
	}
Depends on player height. jumpOffsetY is initialized in GameplayCoreInstaller

public class GameplayCoreInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		....
		float jumpOffsetY = BeatmapObjectSpawnControllerPlayerHeightSetter.JumpOffsetYForPlayerHeight(playerSpecificSettings.playerHeight);

 */


