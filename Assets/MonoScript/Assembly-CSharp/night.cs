using UnityEngine;
using UnityEngine.UI;

public class night : MonoBehaviour
{
	public Text text2;

	public Text text;

	private void Start()
	{
		text = GetComponent<Text>();
		if (!PlayerPrefs.HasKey("night"))
		{
			PlayerPrefs.SetInt("night", 1);
		}
		if (PlayerPrefs.GetInt("night") < 6)
		{
			text.text = PlayerPrefs.GetInt("night") + " ночь";
		}
		else
		{
			text.text = "хардкор";
		}
		if (PlayerPrefs.GetInt("secret") == 1)
		{
			text2.text = "Секретная концовка открыта";
			return;
		}
		PlayerPrefs.SetInt("secret", 0);
		text2.text = "Секретная концовка не открыта";
	}

	private void Update()
	{
	}
}
