using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
	public Text text;

	public int min;

	public int hour;

	private void Start()
	{
		StartCoroutine(clockTime());
	}

	public void Update()
	{
	}

	private IEnumerator clockTime()
	{
		if (PlayerPrefs.GetInt("night") < 5)
		{
			yield return new WaitForSeconds(0.5f);
		}
		else
		{
			yield return new WaitForSeconds(1f);
		}
		min++;
		if (min == 60)
		{
			hour++;
			min = 0;
		}
		if (min < 10)
		{
			text.text = hour + ":0" + min;
		}
		else
		{
			text.text = hour + ":" + min;
		}
		if (hour == 6)
		{
			SceneManager.LoadScene("Win");
		}
		StartCoroutine(clockTime());
	}
}
