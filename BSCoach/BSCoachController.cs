using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BSCoach.Settings;

namespace BSCoach
{
	public class BSCoachController : MonoBehaviour
	{
		public static BSCoachController Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Plugin.log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
				GameObject.DestroyImmediate(this);
				return;
			}
			GameObject.DontDestroyOnLoad(this);
			Instance = this;

			if (Configuration.config.NoteGrid_Enabled)
			{
				new GameObject("Notegrid", typeof(Notegrid));
			}

			//Plugin.log?.Debug($"{name}: Awake()");


		}



		private void Start()
		{

		}

		/// <summary>
		/// Called every frame if the script is enabled.
		/// </summary>
		private void Update()
		{

		}

		/// <summary>
		/// Called every frame after every other enabled script's Update().
		/// </summary>
		private void LateUpdate()
		{

		}

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
			Plugin.log?.Debug($"{name}: OnDestroy()");
			if (Instance == this)
				Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

		}
	}
}
