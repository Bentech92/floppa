using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class ResolutionOption : Option
	{
		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			GenerateResolutionSubOptions();
			if (currentSubOption.name == "" && subOptionList.Count > 0)
			{
				currentSubOptionIndex = 0;
				currentSubOption = subOptionList[currentSubOptionIndex];
			}
			UpdateSuboptionText();
		}

		public override void Apply()
		{
			GraphicSettingHelperMethods.ChangeResolution((int)currentSubOption.vector2Value.x, (int)currentSubOption.vector2Value.y);
		}

		private void GenerateResolutionSubOptions()
		{
			subOptionList.Clear();
			int num = 0;
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				SubOption subOption = new SubOption();
				subOption.name = resolution.width + "x" + resolution.height;
				subOption.vector2Value = new Vector2(resolution.width, resolution.height);
				subOption.indexInList = num;
				subOptionList.Add(subOption);
				num++;
			}
		}

		public void SetCurrentsuboptionByValue(Vector2 v)
		{
			if (subOptionList.Count > 0)
			{
				foreach (SubOption subOption in subOptionList)
				{
					if (subOption.vector2Value == v)
					{
						currentSubOption = subOption;
						currentSubOptionIndex = subOption.indexInList;
						UpdateSuboptionText();
						return;
					}
				}
				string[] obj = new string[5] { "Suboption with value : ", null, null, null, null };
				Vector2 vector = v;
				obj[1] = vector.ToString();
				obj[2] = " ,not found in :";
				obj[3] = base.gameObject.name;
				obj[4] = ",using fallback option instead";
				Debug.LogWarning(string.Concat(obj));
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
