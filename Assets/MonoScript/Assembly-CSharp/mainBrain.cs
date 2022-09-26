using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainBrain : MonoBehaviour
{
	public int oboba;

	public int timerText = 99;

	public Text text;

	public AudioSource audio;

	public GameObject player;

	public int floppaMove;

	public int PopCatMove;

	public int BingusMove;

	public int LightsOff;

	public int waitTime;

	public bool LightsOnOff;

	public int randMove;

	public int FloppaScreamer;

	public int BingusScreamer;

	public int PopScreamer;

	public int BingusChance;

	public int LightsChance;

	public bool FloppaHere;

	public bool BingusHere;

	public bool PopCatHere;

	public GameObject PopCat;

	public GameObject PopCatScr;

	public GameObject Key1;

	public GameObject FloppaScr;

	public GameObject BingusScr;

	public GameObject leverGame;

	private void Start()
	{
		Debug.Log("night " + PlayerPrefs.GetInt("night"));
		if (PlayerPrefs.GetInt("night") == 1)
		{
			waitTime = 10;
			StartCoroutine(BeforeWait());
		}
		if (PlayerPrefs.GetInt("night") == 2)
		{
			waitTime = 7;
			BingusChance = 5;
			StartCoroutine(BeforeWait2());
		}
		if (PlayerPrefs.GetInt("night") == 3)
		{
			LightsChance = 5;
			waitTime = 6;
			BingusChance = 4;
			StartCoroutine(BeforeWait3());
		}
		if (PlayerPrefs.GetInt("night") == 4)
		{
			waitTime = 5;
			LightsChance = 4;
			BingusChance = 3;
			StartCoroutine(BeforeWait4());
		}
		if (PlayerPrefs.GetInt("night") == 5)
		{
			StartCoroutine(timerT());
			text.gameObject.SetActive(true);
		}
		else
		{
			text.gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetInt("night") >= 6)
		{
			waitTime = 5;
			LightsChance = 4;
			BingusChance = 4;
			StartCoroutine(BeforeWait4());
			Time.timeScale = 1.5f;
		}
		if (PlayerPrefs.GetInt("night") != 5)
		{
			Key1.SetActive(false);
		}
	}

	private void Update()
	{
		if ((double)player.transform.position.x >= 10.847)
		{
			SceneManager.LoadScene("secret");
		}
		if (PopScreamer == 1)
		{
			PopCatScr.SetActive(true);
			StartCoroutine(EndScreen());
		}
		if (BingusScreamer == 1)
		{
			BingusScr.SetActive(true);
			StartCoroutine(EndScreen());
		}
		if (FloppaScreamer == 1)
		{
			FloppaScr.SetActive(true);
			StartCoroutine(EndScreen());
		}
	}

	private IEnumerator Wait()
	{
		GameObject gameObject = GameObject.Find("Old_USSR_Lamp_01");
		lampLight myScript2 = gameObject.GetComponent<lampLight>();
		GameObject gameObject2 = GameObject.Find("batary");
		energy myScript3 = gameObject2.GetComponent<energy>();
		GameObject.Find("VentWarn").GetComponent<warnScript>();
		yield return new WaitForSeconds(waitTime);
		if (BingusHere)
		{
			BingusScreamer = 1;
		}
		if (myScript3.off)
		{
			if (FloppaHere)
			{
				if ((double)player.transform.position.z <= -12.065)
				{
					FloppaHere = false;
				}
				else
				{
					FloppaScreamer = 1;
				}
			}
			if (PlayerPrefs.GetInt("night") == 1)
			{
				randMove = Random.RandomRange(1, 3);
			}
			if (PlayerPrefs.GetInt("night") == 2)
			{
				randMove = Random.RandomRange(1, 4);
			}
			if (PlayerPrefs.GetInt("night") == 3)
			{
				randMove = Random.RandomRange(1, 5);
			}
			if (PlayerPrefs.GetInt("night") == 4)
			{
				randMove = Random.RandomRange(1, 5);
			}
			if (PlayerPrefs.GetInt("night") >= 6)
			{
				randMove = Random.RandomRange(1, 5);
			}
			if (randMove == 1)
			{
				floppaMove = Random.RandomRange(1, 3);
				if (floppaMove == 1)
				{
					FloppaHere = true;
				}
			}
			if (randMove == 2)
			{
				PopCatMove = Random.RandomRange(1, 3);
				if (PopCatMove == 1)
				{
					PopCatHere = true;
					PopCat.SetActive(true);
				}
			}
			if (randMove == 3)
			{
				BingusMove = Random.RandomRange(1, BingusChance);
				if (BingusMove == 1 && myScript2.monaa)
				{
					BingusHere = true;
				}
			}
			if (randMove == 4)
			{
				LightsOff = Random.RandomRange(1, LightsChance);
				if (LightsOff == 1)
				{
					GameObject.Find("Lever Switch").GetComponent<lever>().energy = false;
				}
			}
		}
		else if (!myScript3.off && oboba == 0 && PlayerPrefs.GetInt("night") != 5)
		{
			audio.Play();
			oboba = 1;
		}
		else if (!myScript3.off && PlayerPrefs.GetInt("night") != 5)
		{
			randMove = Random.RandomRange(1, 4);
			if (randMove == 1 || randMove == 2 || randMove == 3)
			{
				FloppaScreamer = 1;
			}
		}
		StartCoroutine(Wait());
	}

	private IEnumerator EndScreen()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("loseOtFloppa");
	}

	private IEnumerator BeforeWait()
	{
		yield return new WaitForSeconds(waitTime * 3);
		StartCoroutine(Wait());
	}

	private IEnumerator BeforeWait2()
	{
		yield return new WaitForSeconds(waitTime * 2);
		StartCoroutine(Wait());
	}

	private IEnumerator BeforeWait3()
	{
		yield return new WaitForSeconds((float)waitTime * 1.5f);
		StartCoroutine(Wait());
	}

	private IEnumerator BeforeWait4()
	{
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(Wait());
	}

	private IEnumerator timerT()
	{
		yield return new WaitForSeconds(1f);
		timerText--;
		text.text = timerText.ToString() ?? "";
		if (timerText <= 0)
		{
			if (Random.RandomRange(1, 3) == 1)
			{
				FloppaScreamer = 1;
			}
			else
			{
				PopScreamer = 1;
			}
		}
		StartCoroutine(timerT());
	}
}
