using UnityEngine;

public class fiveNight : MonoBehaviour
{
	private void Start()
	{
		if (PlayerPrefs.GetInt("night") == 5)
		{
			base.transform.position = new Vector3(2.295f, 2.087338f, 1.524f);
		}
	}

	private void Update()
	{
	}
}
