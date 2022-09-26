using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class CubeController : MonoBehaviour
	{
		public float moveSpeed;

		private Camera cam;

		private void Start()
		{
			cam = Camera.main;
		}

		private void Update()
		{
			Vector3 forward = cam.transform.forward;
			forward.y = 0f;
			Vector3 right = cam.transform.right;
			right.y = 0f;
			base.transform.position += forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
			base.transform.position += right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		}
	}
}
