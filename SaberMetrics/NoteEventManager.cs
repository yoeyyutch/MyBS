using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaberHTTPStatus;
using Zenject;

namespace SaberMetrics
{
	class NoteEventManager : IInitializable
	{
		private BeatmapObjectManager _beatmapObjectManager;
		//public StatusManager StatusManager { get; } = new StatusManager();

		public NoteEventManager(BeatmapObjectManager beatmapObjectManager)
		{
			_beatmapObjectManager = beatmapObjectManager;

			//StatusManager.statusChange += OnStatusChange;
		}

		public void Initialize()
		{
			//_beatmapObjectManager.noteWasCutEvent += OnNoteCut;
			//throw new NotImplementedException();
		}

		private void OnNoteCut(NoteController noteController, NoteCutInfo noteCutInfo)
		{

		}



		public void OnStatusChange(StatusManager status, ChangedProperties properties, string cause)
		{
			if (properties.noteCut)
			{ }
		}
	}
}
