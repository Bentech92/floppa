using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class QualityLevelOption : Option
	{
		private void Awake()
		{
			Inititalize();
		}

		private void Inititalize()
		{
			GenerateQualityLevelSuboptions();
			if (currentSubOption.name == "" && subOptionList.Count > 0)
			{
				currentSubOptionIndex = 0;
				currentSubOption = subOptionList[0];
				UpdateSuboptionText();
			}
		}

		public override void Apply()
		{
			GraphicSettingHelperMethods.ChangeQualitySettings(currentSubOption.integerValue);
		}

		private void GenerateQualityLevelSuboptions()
		{
			int num = 0;
			string[] names = QualitySettings.names;
			foreach (string text in names)
			{
				SubOption subOption = new SubOption();
				subOption.name = text;
				subOption.indexInList = num;
				subOption.integerValue = num;
				subOptionList.Add(subOption);
				num++;
			}
		}

		public void SetCurrentsuboptionByValue(int v)
		{
			if (subOptionList.Count > 0)
			{
				foreach (SubOption subOption in subOptionList)
				{
					if (subOption.integerValue == v)
					{
						currentSubOption = subOption;
						currentSubOptionIndex = subOption.indexInList;
						UpdateSuboptionText();
						return;
					}
				}
				Debug.LogWarning("Suboption with value : " + v + " ,not found in :" + base.gameObject.name + ",using fallback option instead");
				currentSubOption = fallBackOption;
				currentSubOptionIndex = fallBackOption.indexInList;
			}
			else
			{
				Debug.LogError("No items in suboption list : " + base.gameObject.name);
			}
		}
	}
}
