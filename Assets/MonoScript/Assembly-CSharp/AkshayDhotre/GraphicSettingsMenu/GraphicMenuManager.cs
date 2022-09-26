using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	[RequireComponent(typeof(GraphicSettingSaveManager))]
	public class GraphicMenuManager : MonoBehaviour
	{
		public ResolutionOption resolutionOption;

		public ScreenmodeOption screenmodeOption;

		public QualityLevelOption qualityLevelOption;

		[Tooltip("The button on keyboard which when pressed will apply the graphic settings")]
		public KeyCode keyboardApplySettingsKey = KeyCode.Return;

		private GraphicSettingDataContainer dataToSave = new GraphicSettingDataContainer();

		private GraphicSettingDataContainer dataToLoad = new GraphicSettingDataContainer();

		private GraphicSettingSaveManager graphicSettingSaveManager;

		private void Start()
		{
			graphicSettingSaveManager = GetComponent<GraphicSettingSaveManager>();
			if (graphicSettingSaveManager.FileExists())
			{
				Load();
				UpdateUIFromLoadedData();
				ApplySettings();
			}
			else
			{
				Debug.Log("New Save file Created!");
				Save();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(keyboardApplySettingsKey))
			{
				ApplySettings();
			}
		}

		public void OnApplyButtonPress()
		{
			ApplySettings();
		}

		private void ApplySettings()
		{
			qualityLevelOption.Apply();
			Save();
		}

		public void Save()
		{
			dataToSave.qualityLevel = qualityLevelOption.currentSubOption.integerValue;
			graphicSettingSaveManager.SaveSettings(dataToSave);
		}

		public void Load()
		{
			graphicSettingSaveManager.LoadSettings(out dataToLoad);
		}

		private void UpdateUIFromLoadedData()
		{
			qualityLevelOption.SetCurrentsuboptionByValue(dataToLoad.qualityLevel);
		}
	}
}
