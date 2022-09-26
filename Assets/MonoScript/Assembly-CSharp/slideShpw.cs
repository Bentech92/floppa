using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class slideShpw : MonoBehaviour
{
	public Image image;

	public Sprite[] sprites = new Sprite[40];

	public int it;

	private void Start()
	{
		image.sprite = sprites[it];
		it++;
		StartCoroutine(Aboba());
	}

	private IEnumerator Aboba()
	{
		yield return new WaitForSeconds(0.09f);
		image.sprite = sprites[it];
		if (it <= 39)
		{
			it++;
		}
		if (it > 39)
		{
			it = 0;
		}
		StartCoroutine(Aboba());
	}
}
