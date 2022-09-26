using UnityEngine;

public class lampLight : MonoBehaviour
{
	public bool monaa;

	public Light lightAboba;

	public void Update()
	{
		energy component = GameObject.Find("batary").GetComponent<energy>();
		if (component.off)
		{
			if (monaa)
			{
				lightAboba.intensity = 0f;
			}
			else if (!monaa)
			{
				lightAboba.intensity = 1.7f;
			}
		}
		if (!component.off)
		{
			if (monaa)
			{
				lightAboba.intensity = 0f;
			}
			else if (!monaa)
			{
				lightAboba.intensity = 0f;
			}
		}
	}
}
