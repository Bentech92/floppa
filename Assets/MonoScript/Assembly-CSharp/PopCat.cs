using System.Collections;
using UnityEngine;

public class PopCat : MonoBehaviour
{
	public Sprite[] sprites = new Sprite[2];

	private void Start()
	{
		StartCoroutine(Pop());
	}

	private void Update()
	{
	}

	private IEnumerator Pop()
	{
		yield return new WaitForSeconds(0.2f);
		base.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
		StartCoroutine(Pop2());
	}

	private IEnumerator Pop2()
	{
		yield return new WaitForSeconds(0.2f);
		base.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
		StartCoroutine(Pop());
	}
}
