using System;
using System.Xml.Serialization;

namespace AkshayDhotre.GraphicSettingsMenu
{
	[Serializable]
	[XmlRoot("Settings")]
	public class GraphicSettingDataContainer
	{
		public int screenWidth;

		public int screenHeight;

		public int screenMode = -1;

		public int qualityLevel = -1;
	}
}
