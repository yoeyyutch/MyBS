using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UI
{
	class Utilities
	{
		//public static IEnumerable<Material> AllMaterials { get; private set; }

		//public static void GetMaterials()
		//{
		//	// This object should be created in the Menu Scene
		//	// Grab materials from Menu Scene objects
		//	AllMaterials = Resources.FindObjectsOfTypeAll<Material>();
		//}

		//public static Material WhiteSemitransparentMaterial = 

		public static void GetMaterials(Scene scene)
		{
			IEnumerable<Material> sceneMaterials = Resources.FindObjectsOfTypeAll<Material>();
			Plugin.log.Info("________________________________");
			Plugin.log.Info("Scene: " + scene.name);
			foreach(Material m in sceneMaterials)
			{
				
				Plugin.log.Info(m.name);
				Plugin.log.Info("   Shader......" + m.shader.name);
			}
			Plugin.log.Info("________________________________");
		}

		public static void GetRenderers(Scene scene)
		{
			IEnumerable<Renderer> renderers = Resources.FindObjectsOfTypeAll<Renderer>();
			Plugin.log.Info("________________________________");
			Plugin.log.Info("Scene: " + scene.name);
			foreach (Renderer r in renderers)
			{
				GameObject g = r.GetComponent<GameObject>();
				Material m = r.material;
				Shader s = m.shader;
				Plugin.log.Info("___________________________");
				Plugin.log.Info("GameObject......" + g.name);
				Plugin.log.Info("  Matl.........." + m.name);
				Plugin.log.Info("   Shader......." + s.name);
				Plugin.log.Info("___________________________");
			}
			Plugin.log.Info("________________________________");
		}

		public static void GetGameObjects(Scene scene)
		{
			IEnumerable<GameObject> go = Resources.FindObjectsOfTypeAll<GameObject>();
			Plugin.log.Info("________________________________");
			Plugin.log.Info("Scene: " + scene.name);
			foreach (GameObject g in go)
			{
				
				//Plugin.log.Info("___________________________");
				Plugin.log.Info("GameObject......" + g.name);
				//Plugin.log.Info("  Matl.........." + m.name);
				//Plugin.log.Info("   Shader......." + s.name);
				//Plugin.log.Info("___________________________");
			}
			Plugin.log.Info("________________________________");
		}

		public static void GetSceneShaders(string scene)
		{
			//List<string> shadersInScene = new List<string>();
			Plugin.log.Info("________________________________");
			Plugin.log.Info("________________________________");
			Plugin.log.Info("Scene: " + scene);
			foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
			{
				Plugin.log.Info("............................");
				Plugin.log.Info("GameObject: " + go.name) ;
				Shader s = go.GetComponent<Renderer>().material.shader;
				int c = s.GetPropertyCount();
				for (int i = 0; i < c; i++)
				{
					Plugin.log.Info("........" + s.name + "." + c + ": " + s.GetPropertyName(c));
				}
			}
			Plugin.log.Info("________________________________");
		}

	}
}
