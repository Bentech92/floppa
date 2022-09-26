using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public enum ShakeMode
	{
		OnlyX = 0,
		OnlyY = 1,
		OnlyZ = 2,
		XY = 3,
		XZ = 4,
		XYZ = 5
	}

	private static Transform tr;

	private static float elapsed;

	private static float i_Duration;

	private static float i_Power;

	private static float percentComplete;

	private static ShakeMode i_Mode;

	private static Vector3 originalPos;

	private void Start()
	{
		percentComplete = 1f;
		tr = GetComponent<Transform>();
	}

	public static void Shake(float duration, float power)
	{
		if (percentComplete == 1f)
		{
			originalPos = tr.localPosition;
		}
		i_Mode = ShakeMode.XYZ;
		elapsed = 0f;
		i_Duration = duration;
		i_Power = power;
	}

	public static void Shake(float duration, float power, ShakeMode mode)
	{
		if (percentComplete == 1f)
		{
			originalPos = tr.localPosition;
		}
		i_Mode = mode;
		elapsed = 0f;
		i_Duration = duration;
		i_Power = power;
	}

	private void Update()
	{
		if (elapsed < i_Duration)
		{
			elapsed += Time.deltaTime;
			percentComplete = elapsed / i_Duration;
			percentComplete = Mathf.Clamp01(percentComplete);
			Vector3 vector = Random.insideUnitSphere * i_Power * (1f - percentComplete);
			switch (i_Mode)
			{
			case ShakeMode.XYZ:
				tr.localPosition = originalPos + vector;
				break;
			case ShakeMode.OnlyX:
				tr.localPosition = originalPos + new Vector3(vector.x, 0f, 0f);
				break;
			case ShakeMode.OnlyY:
				tr.localPosition = originalPos + new Vector3(0f, vector.y, 0f);
				break;
			case ShakeMode.OnlyZ:
				tr.localPosition = originalPos + new Vector3(0f, 0f, vector.z);
				break;
			case ShakeMode.XY:
				tr.localPosition = originalPos + new Vector3(vector.x, vector.y, 0f);
				break;
			case ShakeMode.XZ:
				tr.localPosition = originalPos + new Vector3(vector.x, 0f, vector.z);
				break;
			}
		}
	}
}
