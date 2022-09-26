using System.Collections;
using UnityEngine;

public class waitForGov : MonoBehaviour
{
	public GameObject muteO;

	public AudioSource audio;

	private void Start()
	{
		if (PlayerPrefs.GetInt("night") == 1)
		{
			audio = GetComponent<AudioSource>();
			StartCoroutine(wait());
		}
		else
		{
			muteO.SetActive(false);
		}
		if (PlayerPrefs.GetInt("night") >= 4)
		{
			muteO.SetActive(false);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			Mute();
		}
	}

	private IEnumerator wait()
	{
		yield return new WaitForSeconds(4f);
		if (muteO.active)
		{
			audio.Play();
		}
	}

	public void Mute()
	{
		audio.Stop();
		muteO.SetActive(false);
	}
}
