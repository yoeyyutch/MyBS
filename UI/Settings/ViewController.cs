using BeatSaberMarkupLanguage.Attributes;
using System;


namespace UI.Settings
{
	public class ViewController : PersistentSingleton<ViewController>
	{
		[UIValue("text")]
		public bool test;
		double j = Math.Floor(88.989);

	}
}
