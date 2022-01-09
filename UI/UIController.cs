using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Monobehaviours (scripts) are added to GameObjects.
	/// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
	/// </summary>
	public class UIController : MonoBehaviour
	{
		public static UIController Instance { get; private set; }
		public static bool Enabled { get; private set; }
		GameObject TC;
		Material matl;


		/// <summary>
		/// Only ever called once, mainly used to initialize variables.
		/// </summary>
		private void Awake()
		{
			// For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
			//   and destroy any that are created while one already exists.
			if (Instance != null)
			{
				Plugin.log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
				GameObject.DestroyImmediate(this);
				return;
			}
			DontDestroyOnLoad(this); // Don't destroy this object on scene changes
			Instance = this;
			Plugin.log?.Debug($"{name}: Awake()");
		}

		/// <summary>
		/// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
		/// </summary>
		private void Start()
		{
			Enabled = Settings.Configuration.config.Enabled;
			Plugin.log?.Debug($"{name}: Start()");
			string s = Enabled ? "enabled" : "disabled";
			Plugin.log.Info($"Mod has been {s}.");

			matl = new Material(Shader.Find("Sprites/Default"));
			matl.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		}

		public void TestMethod(bool show)
		{
			if (!show)
			{
				Plugin.log.Info("Plugin disabled in mod settings.");
				if (TC != null)
				{
					TC.transform.localScale = Vector3.zero;
				}
					
				return;
			}

			if (show)
			{
				Plugin.log.Info("Plugin enabled in mod settings.");
				if (TC != null)
				{
					TC.transform.localScale = Vector3.one *.5f;
					return;
				}

				else
				{ 
					TC = GameObject.CreatePrimitive(PrimitiveType.Cube);
					TC.transform.parent = transform;
					TC.transform.SetPositionAndRotation(new Vector3(0.3f, .9f, 0f), Quaternion.identity);
					TC.transform.localScale = Vector3.one * .5f;
					Renderer re = TC.GetComponent<Renderer>();
					re.sharedMaterial = matl;
				} 
			}
		}

		//public void ToggleState()
		//{
		//	Enabled = Settings.Configuration.config.Enabled;
		//	string s = Enabled ? "enabled" : "disabled";
		//	Plugin.log.Info($"Mod has been {s}.");
		//}

		/// <summary>
		/// Called every frame if the script is enabled.
		/// </summary>
		//private void Update()
		//{

		//}

		/// <summary>
		/// Called every frame after every other enabled script's Update().
		/// </summary>
		//private void LateUpdate()
		//{

		//}

		/// <summary>
		/// Called when the script becomes enabled and active
		/// </summary>
		//private void OnEnable()
		//{

		//}

		/// <summary>
		/// Called when the script becomes disabled or when it is being destroyed.
		/// </summary>
		//private void OnDisable()
		//{

		//}

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
