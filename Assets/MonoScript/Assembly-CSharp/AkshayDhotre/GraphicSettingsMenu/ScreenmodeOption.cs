using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class ScreenmodeOption : Option
	{
		private void Awake()
		{
			if (currentSubOption.name == "" && subOptionList.Count > 0)
			{
				currentSubOptionIndex = 0;
				currentSubOption = subOptionList[currentSubOptionIndex];
				UpdateSuboptionText();
			}
		}

		public override void Apply()
		{
			GraphicSettingHelperMethods.ChangeScreenMode(currentSubOption.integerValue);
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
