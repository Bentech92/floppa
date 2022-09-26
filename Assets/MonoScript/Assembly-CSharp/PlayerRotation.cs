using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
	public Transform myCamera;

	private Vector3 firstPoint;

	private Vector3 secondPoint;

	private float xAngle;

	private float yAngle;

	private float xAngleTemp;

	private float yAnleTemp;

	private void Start()
	{
		yAngle = base.transform.localRotation.eulerAngles.y;
	}

	private void Update()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if ((touch.position.x > (float)(Screen.width / 2)) & (touch.phase == TouchPhase.Began))
			{
				firstPoint = touch.position;
				xAngleTemp = xAngle;
				yAnleTemp = yAngle;
			}
			if ((touch.position.x > (float)(Screen.width / 2)) & (touch.phase == TouchPhase.Moved))
			{
				secondPoint = touch.position;
				xAngle = xAngleTemp - (secondPoint.y - firstPoint.y) * 90f / (float)Screen.height;
				yAngle = yAnleTemp + (secondPoint.x - firstPoint.x) * 180f / (float)Screen.width;
				base.transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
				xAngle = Mathf.Clamp(xAngle, -80f, 80f);
				myCamera.transform.rotation = Quaternion.Euler(xAngle, yAngle, 0f);
			}
		}
	}
}
