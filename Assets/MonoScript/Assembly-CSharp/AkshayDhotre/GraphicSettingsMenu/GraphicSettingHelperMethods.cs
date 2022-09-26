using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public static class GraphicSettingHelperMethods
	{
		public static void ChangeScreenMode(int screenMode)
		{
			Screen.fullScreenMode = (FullScreenMode)screenMode;
		}

		public static void ChangeResolution(int x, int y)
		{
			Screen.SetResolution(x, y, Screen.fullScreenMode);
		}

		public static void ChangeQualitySettings(int qualityLevelIndex)
		{
			QualitySettings.SetQualityLevel(qualityLevelIndex);
		}
	}
}
