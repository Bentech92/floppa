using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
	public GameObject indicator;

	public Text message;

	private RaycastHit hit;

	public ObjectType objectType;

	public bool lamp;

	public bool vent1;

	public bool vent2;

	public bool key;

	public bool key2;

	public GameObject FadeIn;

	private void Update()
	{
		if (Physics.Raycast(base.transform.position, base.transform.forward, out hit, 2f))
		{
			if (hit.collider.tag == "Interaction")
			{
				indicator.active = true;
				if (Input.GetKeyUp(KeyCode.Mouse0))
				{
					ItemInteraction();
				}
			}
			else
			{
				indicator.active = false;
			}
		}
		else
		{
			indicator.active = false;
		}
		if (Physics.Raycast(base.transform.position, base.transform.forward, out hit, 6f) && hit.collider.tag == "Bingus")
		{
			warnScript component = GameObject.Find("VentWarn").GetComponent<warnScript>();
			noiceSwitch1 component2 = GameObject.Find("Button").GetComponent<noiceSwitch1>();
			if (GameObject.Find("Mosters").GetComponent<mainBrain>().BingusHere && !component2.flashOn)
			{
				component.BingusDef = true;
			}
		}
	}

	public void ItemInteraction()
	{
		if (hit.collider.name == "Old_USSR_Lamp_01")
		{
			lampLight component = GameObject.Find("Old_USSR_Lamp_01").GetComponent<lampLight>();
			component.monaa = !component.monaa;
		}
		if (hit.collider.name == "buttonR")
		{
			GameObject.Find("buttonR").GetComponent<clickButton>().clicked = 1;
		}
		if (hit.collider.name == "Lever Switch")
		{
			GameObject.Find("Lever Switch").GetComponent<lever>().up = true;
		}
		if (hit.collider.name == "prf_key_01")
		{
			key = true;
			hit.collider.gameObject.SetActive(false);
		}
		if (hit.collider.name == "prf_v_key_04")
		{
			key2 = true;
			hit.collider.gameObject.SetActive(false);
		}
		if (hit.collider.name == "01_low")
		{
			Debug.Log("Дверь открыта");
			if (key)
			{
				hit.collider.GetComponent<Animator>().Play("animSecret");
			}
			else
			{
				message.gameObject.SetActive(true);
				message.text = "Нужен синий ключ";
				StartCoroutine(EndMessage());
			}
		}
		if (hit.collider.name == "DoorV2")
		{
			if (key2)
			{
				FadeIn.SetActive(true);
				StartCoroutine(endGameWin());
			}
			else
			{
				message.gameObject.SetActive(true);
				message.text = "Нужен красный ключ";
				StartCoroutine(EndMessage());
			}
		}
	}

	private IEnumerator EndMessage()
	{
		yield return new WaitForSeconds(1f);
		//Screen.lockCursor = true;
		message.gameObject.SetActive(false);
	}

	private IEnumerator endGameWin()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("Win");
	}
}
