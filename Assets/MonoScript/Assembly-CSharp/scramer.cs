using UnityEngine;

public class scramer : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Pop")
		{
			GameObject.Find("Mosters").GetComponent<mainBrain>();
		}
	}
}
