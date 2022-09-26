using System.Collections;
using UnityEngine;

public class lever : MonoBehaviour
{
	public int onse;

	public int onse2;

	public bool energy = true;

	public Animation anim;

	public bool up;

	private void Start()
	{
	}

	private void Update()
	{
		if (GameObject.Find("batary").GetComponent<energy>().off)
		{
			if (up && onse2 == 0 && onse == 1)
			{
				anim.Play("1");
				StartCoroutine(uped());
				onse2 = 1;
			}
			if (!energy && onse == 0)
			{
				GameObject.Find("Large_round_lamp").GetComponent<OnOff>().lightsOn = false;
				up = false;
				anim.Play("1 1");
				onse = 1;
				onse2 = 0;
			}
		}
		else
		{
			energy = false;
			onse = 12;
		}
	}

	private IEnumerator uped()
	{
		yield return new WaitForSeconds(anim.clip.length);
		energy = true;
		GameObject.Find("Large_round_lamp").GetComponent<OnOff>().lightsOn = true;
		onse = 0;
	}
}
