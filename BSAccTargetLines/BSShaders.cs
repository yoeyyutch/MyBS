using System;
using System.Linq;
using UnityEngine;

namespace BSAccTargetLines
{

	public class BSShaders
	{
		static public readonly string[] shaders = {

			"Sprites/Default", //0 ok
			"UI/Default", //1 ok
			"Hidden/HM/KawaseBlur",//2 ok invis
			"Hidden/BlitCopyWithDepth",//3
			"Hidden/InternalErrorShader",//4 purple
			"GUI/Text Shader",//5 alpha
			"Custom/SmokeParticle",//6 smoky
			"Custom/Glowing",//7
			"Hidden/MainEffect",
			"Custom/CustomParticles",
			"TextMeshPro/Sprite",//invis
			"TextMeshPro/Mobile/Distance Field",
			"Custom/ShadowCasterOnly",
			"Custom/SimpleTexture",
			"Custom/ParametricBox", // invisible
			"Custom/BloomSkyboxQuad", 
			"Custom/ParametricBoxOpaque", //gray
			"Hidden/BlitAdd",//33
			"Custom/CustomUI"};//35 black broken

		static public Material SetMaterial(Color color, string shader, string name)
		{
			var gameObject = new GameObject("go");
			
			Material material = new Material(Shader.Find(shader))
			
			{
				color = color,
				name = String.Concat(shader, name)
			};

			Plugin.log.Info(material.shader.name);

			return material;
		}

	}
}
//Color bad = Color.red; 
//Material material = new Material(Shader.Find(shader));
//Material fallback = new Material(Shader.Find("Custom/Glowing"));
//fallback.name = String.Concat(shader, name);
//fallback.SetColor("_Color", bad);

//if (material.shader = null)
//{

//	Plugin.log.Info("Material : Fallback" + shader);
//	return fallback;
//}

//else
//{
//	//material.name = String.Concat(shader, name);
//	//if (material.
//	//{
//	//	material.SetColor("_Color", color);
//	//	Plugin.log.Info("material : " + material.name);
//	//	return material;
//	//}
//	//else
//	//{
//	//	Plugin.log.Info("Material : Fallback(nocolorproperty)" + shader);
//	//	return fallback;
//	//}

//	material.SetColor("_Color", color);
//	material.name = String.Concat(shader, name);
//	return material;

//enum Shaders
//{
//	LegacyShadersDiffuse,
//	Sprites_Default,
//	UI_Default,
//	Custom_MROverlayAlpha,
//	Hidden_HMKawaseBlur,
//	Custom_FadeOutTexture1,
//	Custom_DepthAndLuminanceToWhite,
//	Custom_ClearAll,
//	Custom_MROverlayColor,
//	Hidden_BlitCopy,
//	Hidden_BlitCopyWithDepth,
//	Sprites_Mask,
//	Hidden_InternalErrorShader,
//	Hidden_InternalClear,
//	GUI_TextShader,
//	Legacy_Shaders_VertexLit,
//	Custom_ScreenDisplacement,
//	Custom_SmokeParticle,
//	Custom_GlowingInstanced,
//	Custom_Mirror,
//	Custom_Sprite,
//	Custom_Glowing,
//	Hidden_MainEffect,
//	Custom_CustomParticles,
//	TextMeshPro_Sprite,
//	TextMeshPro_Mobile_Distance_Field,
//	Custom_ShadowCasterOnly,
//	Custom_UIBlurredScreenGrab,
//	Custom_SimpleTexture,
//	Hidden_BloomPrePassLine,
//	Custom_ParametricBox,
//	Custom_FogLighting,
//	Custom_BloomSkyboxQuad,
//	Hidden_BloomLinesHDRToLDR,
//	Custom_ParametricBoxOpaque,
//	TextMeshPro_Mobile_Distance_Field_ZeroAlphaWrite,
//	Hidden_BlitAdd,
//	Custom_CustomUI
//}



/*
"Sprites/Default",
"UI/Default",
"Custom/MROverlayAlpha",
"Hidden/HM/KawaseBlur",
"Custom/FadeOutTexture1",
"Custom/DepthAndLuminanceToWhite",
"Custom/ClearAll",
"Custom/MROverlayColor",
"Hidden/BlitCopy",
"Hidden/BlitCopyWithDepth",
"Sprites/Mask",
"Hidden/InternalErrorShader",
"Hidden/InternalClear",
"GUI/Text Shader",
"Legacy Shaders/VertexLit",
"Custom/ScreenDisplacement",
"Custom/SmokeParticle",
"Custom/GlowingInstanced",
"Custom/Mirror",
"Custom/Sprite",
"Custom/Glowing",
"Hidden/MainEffect",
"Custom/CustomParticles",
"TextMeshPro/Sprite",
"TextMeshPro/Mobile/Distance Field",
"Custom/ShadowCasterOnly",
"Custom/UIBlurredScreenGrab",
"Custom/SimpleTexture",
"Hidden/BloomPrePassLine",
"Custom/ParametricBox",
"Custom/FogLighting",
"Custom/BloomSkyboxQuad",
"Hidden/BloomLinesHDRToLDR",
"Custom/ParametricBoxOpaque",
"TextMeshPro/Mobile/Distance Field ZeroAlphaWrite",
"Hidden/BlitAdd",
"Custom/CustomUI"
*/

