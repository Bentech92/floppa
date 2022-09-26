using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waitAndSecret : MonoBehaviour
{
	public GameObject came;

	public GameObject scremier;

	public AudioSource audio;

	public GameObject floppik;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		PlayerPrefs.SetInt("secret", 1);
		audio.Play();
		StartCoroutine(DF());
		StartCoroutine(l());
	}

	private void Update()
	{
	}

	private IEnumerator l()
	{
		yield return new WaitForSeconds(10f);
		came.transform.position = new Vector3(255f, 255f, 255f);
		StartCoroutine(l1());
		StartCoroutine(l2());
	}

	private IEnumerator l1()
	{
		yield return new WaitForSeconds(2f);
		scremier.SetActive(true);
	}

	private IEnumerator l2()
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("secretEnd");
	}

	private IEnumerator DF()
	{
		yield return new WaitForSeconds(0.5f);
		floppik.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		StartCoroutine(DF2());
	}

	private IEnumerator DF2()
	{
		yield return new WaitForSeconds(0.5f);
		floppik.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
		StartCoroutine(DF3());
	}

	private IEnumerator DF3()
	{
		yield return new WaitForSeconds(0.5f);
		floppik.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
		StartCoroutine(DF2());
	}
}
