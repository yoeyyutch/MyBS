using BeatSaberHTTPStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace SaberMetrics
{
	public class BSEvents
	{
		
		public BSEvents()
		{ 
			//BSData.status.statusChange += OnStatusUpdate;
			SceneManager.activeSceneChanged += OnSceneChange;
		}

		void OnSceneChange(Scene oldScene, Scene newScene)
		{
			Plugin.Log.Info(BSData.liveData.scene);
		}

		void OnStatusUpdate(StatusManager statusManager, ChangedProperties props, string cause)
		{	
			BSData.liveData = statusManager.gameStatus;
			//LiveData = statusManager.gameStatus;
		}
	}
}
