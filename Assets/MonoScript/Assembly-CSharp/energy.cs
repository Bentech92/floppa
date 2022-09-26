using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
	public Text text;

	public int AllEnergy = 100;

	public int minus = 1;

	public bool off = true;

	private void Start()
	{
		StartCoroutine(energ());
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("night") == 5)
		{
			AllEnergy = 0;
		}
		if (AllEnergy <= 0 && off)
		{
			lampLight component = GameObject.Find("Old_USSR_Lamp_01").GetComponent<lampLight>();
			clickButton component2 = GameObject.Find("buttonR").GetComponent<clickButton>();
			OnOff component3 = GameObject.Find("Large_round_lamp").GetComponent<OnOff>();
			component.monaa = true;
			AllEnergy = 0;
			component2.open = false;
			component3.lightsOn = false;
			off = false;
		}
		text.text = AllEnergy.ToString() ?? "";
	}

	private IEnumerator energ()
	{
		if (PlayerPrefs.GetInt("night") > 5)
		{
			yield return new WaitForSeconds(5f);
		}
		else
		{
			yield return new WaitForSeconds(3f);
		}
		minus = 1;
		lampLight component = GameObject.Find("Old_USSR_Lamp_01").GetComponent<lampLight>();
		clickButton component2 = GameObject.Find("buttonR").GetComponent<clickButton>();
		noiceSwitch1 component3 = GameObject.Find("Button").GetComponent<noiceSwitch1>();
		if (!component.monaa)
		{
			minus++;
		}
		if (component2.open)
		{
			minus++;
		}
		if (!component3.flashOn)
		{
			minus++;
		}
		AllEnergy -= minus;
		if (AllEnergy >= 1)
		{
			StartCoroutine(energ());
		}
	}
}
