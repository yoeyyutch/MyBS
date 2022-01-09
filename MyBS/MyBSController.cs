using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyBS
{

	public class MyBSController : MonoBehaviour
	{
		public static MyBSController Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Plugin.log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
				GameObject.DestroyImmediate(this);
				return;
			}
			GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
			Instance = this;
			Plugin.log?.Debug($"{name}: Awake()");
			gameObject.AddComponent<NoteLanes>();
		}

		private void Start()
		{

		}


		private void Update()
		{

		}

		private void LateUpdate()
		{

		}

		private void OnEnable()
		{

		}

		private void OnDisable()
		{

		}

		private void OnDestroy()
		{
			Plugin.log?.Debug($"{name}: OnDestroy()");
			if (Instance == this)
				Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.
		}
	}
}
