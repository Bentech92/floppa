using UnityEngine;

public class skrimackPopCat : MonoBehaviour
{
	public GameObject PopCatOb;

	private void Start()
	{
	}

	private void Update()
	{
		if (PopCatOb.transform.position.x <= -2.035f)
		{
			mainBrain component = GameObject.Find("Mosters").GetComponent<mainBrain>();
			if (GameObject.Find("buttonR").GetComponent<clickButton>().open)
			{
				component.PopCatHere = false;
				PopCatOb.transform.position = new Vector2(0.914f, 0.935f);
				PopCatOb.SetActive(false);
			}
			else
			{
				component.PopScreamer = 1;
			}
		}
	}
}
