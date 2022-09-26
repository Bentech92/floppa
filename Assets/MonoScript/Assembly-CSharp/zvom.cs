using UnityEngine;

public class zvom : MonoBehaviour
{
	public AudioSource alllllllll;

	private void Start()
	{
		if (PlayerPrefs.GetInt("night") <= 3)
		{
			alllllllll = GetComponent<AudioSource>();
			alllllllll.Play();
		}
	}

	private void Update()
	{
	}
}
