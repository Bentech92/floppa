using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControllerPanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	public bool pressed;

	public bool isMobile = true;

	public float sensitivity;

	public CinemachineVirtualCamera CVC;

	private int fingerId;

	private void Start()
	{
		if (isMobile)
		{
			CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = sensitivity;
			CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = sensitivity;
			CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
			CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
		}
		else
		{
			CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
			CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.pointerCurrentRaycast.gameObject == base.gameObject)
		{
			pressed = true;
			fingerId = eventData.pointerId;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		pressed = false;
		CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0f;
		CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0f;
	}

	private void Update()
	{
		if (!pressed)
		{
			return;
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.fingerId == fingerId)
			{
				if (touch.phase == TouchPhase.Moved)
				{
					CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = touch.deltaPosition.y;
					CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = touch.deltaPosition.x;
				}
				if (touch.phase == TouchPhase.Stationary)
				{
					CVC.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0f;
					CVC.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0f;
				}
			}
		}
	}
}
