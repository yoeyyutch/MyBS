using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BSCoach
{
	/// <summary>
	/// Monobehaviours (scripts) are added to GameObjects.
	/// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
	/// </summary>
	public class MyScriptableObject : ScriptableObject
	{

		#region
		/// <summary>
		/// Called when the script becomes enabled and active
		/// </summary>
		private void OnEnable()
		{

		}

		/// <summary>
		/// Called when the script becomes disabled or when it is being destroyed.
		/// </summary>
		private void OnDisable()
		{

		}

		/// <summary>
		/// Called when the script is being destroyed.
		/// </summary>
		private void OnDestroy()
		{

		}
		#endregion
	}
}
