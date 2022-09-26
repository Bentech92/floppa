using UnityEngine;
using UnityEngine.UI;

public class textSw : MonoBehaviour
{
	private Text text;

	private void Start()
	{
		text = GetComponent<Text>();
		if (PlayerPrefs.GetInt("night") < 5)
		{
			text.text = "Ночь пройдена!";
		}
		else if (PlayerPrefs.GetInt("night") >= 5)
		{
			text.text = "Продолжение следует...";
		}
	}

	private void Update()
	{
	}
}
