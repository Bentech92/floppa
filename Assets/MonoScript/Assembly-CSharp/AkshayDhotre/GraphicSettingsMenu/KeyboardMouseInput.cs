using UnityEngine;
using UnityEngine.EventSystems;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public class KeyboardMouseInput : MonoBehaviour
	{
		[Tooltip("Object which shows that the current object is selected, it can be a simple pointer next to the optionor an image overlay over the option")]
		public GameObject optionMarker;

		private bool selected;

		private Option myOption;

		private EventSystem currentEventSystem;

		private void Awake()
		{
			myOption = GetComponent<Option>();
			currentEventSystem = EventSystem.current;
		}

		private void Update()
		{
			if (IsMenuActive())
			{
				KeyboardControls();
			}
		}

		private void KeyboardControls()
		{
			if (selected)
			{
				if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
				{
					myOption.SelectNextSubOption();
				}
				else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
				{
					myOption.SelectPreviousSubOption();
				}
			}
		}

		private bool IsMenuActive()
		{
			if (base.transform.root.GetComponent<Canvas>().enabled)
			{
				return true;
			}
			return false;
		}

		public void SetMarkerActive(bool val)
		{
			optionMarker.SetActive(val);
			selected = val;
			if (val && currentEventSystem.currentSelectedGameObject != base.gameObject)
			{
				currentEventSystem.SetSelectedGameObject(null);
				currentEventSystem.SetSelectedGameObject(base.gameObject);
			}
		}
	}
}
