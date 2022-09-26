using UnityEngine;

public class OnOff : MonoBehaviour
{
	public Light light;

	public bool lightsOn = true;

	public int once;

	private void Start()
	{
		light = GetComponent<Light>();
	}

	private void Update()
	{
		if (!lightsOn)
		{
			light.intensity = 0f;
		}
		else if (lightsOn)
		{
			light.intensity = 5.5f;
		}
	}
}
