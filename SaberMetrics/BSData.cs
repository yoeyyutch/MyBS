using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeatSaberHTTPStatus;
using SimpleJSON;
using UnityEngine;

namespace SaberMetrics
{
	public class BSData 
	{
		private StatusManager status;
		static public GameStatus liveData;

		public BSData()
		{

			status = new StatusManager();
			liveData = status.gameStatus;
			status.statusChange += OnStatusUpdate;

		}

		void OnStatusUpdate(StatusManager statusManager, ChangedProperties props, string cause)
		{
			status = statusManager;
			liveData = status.gameStatus;

		}
	}
}
