using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class CameraController : MonoBehaviour
	{
		public Transform player;

		private void Update()
		{
			base.transform.LookAt(player.transform.position);
		}
	}
}
