using UnityEngine;

public class warnScript : MonoBehaviour
{
	public bool BingusDef;

	public Sprite[] sprites = new Sprite[2];

	private void Start()
	{
	}

	private void Update()
	{
		mainBrain component = GameObject.Find("Mosters").GetComponent<mainBrain>();
		lever component2 = GameObject.Find("Lever Switch").GetComponent<lever>();
		if (component.BingusHere)
		{
			if (BingusDef)
			{
				component.BingusHere = false;
				BingusDef = false;
			}
			base.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
		}
		else if (component.PopCatHere && component2.energy)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
		}
		else if (component.FloppaHere && component2.energy)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
		}
		else
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = null;
		}
	}
}
