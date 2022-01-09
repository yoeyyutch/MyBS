using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BSCoach
{
	public static class Utilities
	{
		public static void LogShaderProperties(string shader)
		{
			//Resources.FindObjectsOfTypeAll()
		}
        
        public static void GetSceneShaders()
		{
            List<string> shadersInScene = new List<string>();
            foreach (Shader shader in Resources.FindObjectsOfTypeAll(typeof(Shader)))
			{
                int c = shader.GetPropertyCount();
                for(int i = 0; i < c; i++)
				{
                    Plugin.log.Info(shader.name + "." + c + ": " + shader.GetPropertyName(c));
				}


			}
		}

        //List<GameObject> GetNonSceneObjects()
        //{
        //    List<GameObject> objectsInScene = new List<GameObject>();

        //    foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        //    {
        //        if (EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
        //            objectsInScene.Add(go);
        //    }

        //    return objectsInScene;
        //}
    
    }

}
