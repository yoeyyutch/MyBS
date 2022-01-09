using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyBS
{
	public static class Utilities
	{
		public static Vector2[] XYCoordinates(float[] xValues, float[] yvalues)
		{
			Vector2[] v = new Vector2[xValues.Length * yvalues.Length];
			for (int i = 0; i < v.Length; i++)
			{
				for (int y = 0; y < yvalues.Length; y++)
				{
					for (int x = 0; x < xValues.Length; x++)
					{
						v[i] = new Vector2(xValues[x], yvalues[y]);
					}
				}
			}
			return v;
		}

		public static int ArrayIndex(int width, int column, int row)
		{
			return (row * width) + column;
		}

		public static Material GetMaterialFromShaderInScene(string shader, Color color, string name)
		{
			Material material = new Material(Shader.Find(shader))
			{
				color = color,
				name = shader + name
			};
			return material;
		}
	}
}
