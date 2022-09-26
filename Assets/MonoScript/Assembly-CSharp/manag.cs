using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class manag : MonoBehaviour
{
	public GameObject FadeIn;

	public int ok;
    private void Awake()
    {
		AdController.Instance.InitializeBannerAds();
		AdController.Instance.InitializeRewardedInterstitialAds();
	}
    public void Start()
	{

		//Cursor.visible = true;
		//Cursor.lockState = CursorLockMode.None;
		ok = 0;
		
	}

	private void Update()
	{
		if ( ok == 0 && SceneManager.GetActiveScene().buildIndex < 7)
		{
			AdController.Instance.showinters();
			ok = 1;
		}
		if (Input.GetKeyDown("space"))
		{
			if (SceneManager.GetActiveScene().buildIndex == 0)
			{
				FadeIn.SetActive(true);
				StartCoroutine(S());
			}
			if (SceneManager.GetActiveScene().buildIndex == 2)
			{
				FadeIn.SetActive(true);
				StartCoroutine(M());
			}
			if (SceneManager.GetActiveScene().buildIndex == 3)
			{
				FadeIn.SetActive(true);
				StartCoroutine(M());
			}
			if (SceneManager.GetActiveScene().buildIndex == 5)
			{
				FadeIn.SetActive(true);
				StartCoroutine(M());
			}
		}
	}

	public void StartGame()
	{
		FadeIn.SetActive(true);
		StartCoroutine(S());
	}

	public void Inst()
	{
		SceneManager.LoadScene("Inst");
	}

	public void Menu()
	{
		FadeIn.SetActive(true);
		StartCoroutine(M());
	}

	public void Reset()
	{
		PlayerPrefs.SetInt("night", 1);
		SceneManager.LoadScene("Menu");
	}

	public void Exit()
	{
		Application.Quit();
	}

	private IEnumerator M()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Menu");
	}

	private IEnumerator S()
	{
		yield return new WaitForSeconds(1f);
		if (!PlayerPrefs.HasKey("night"))
		{
			PlayerPrefs.SetInt("night", 1);
		}
		if (PlayerPrefs.GetInt("night") <= 5)
		{
			SceneManager.LoadScene("SampleScene");
		}
		else
		{
			SceneManager.LoadScene("SampleScene");
		}
	}
}
