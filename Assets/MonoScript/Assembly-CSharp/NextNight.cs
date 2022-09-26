using UnityEngine;

public class NextNight : MonoBehaviour
{
	private void Start()
	{
		PlayerPrefs.SetInt("night", PlayerPrefs.GetInt("night") + 1);
		Debug.Log(PlayerPrefs.GetInt("night"));
	}

	private void Update()
	{
	}
}
