using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class netbook : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public Animator animator;

	public bool netbookOpen;

	public AudioSource audioS;

	public int cooldown;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (netbookOpen && cooldown == 0)
		{
			animator.SetBool("start", true);
			animator.SetBool("open", false);
			audioS.Play();
			netbookOpen = !netbookOpen;
			StartCoroutine(coolD());
			cooldown = 1;
		}
		else if (!netbookOpen && cooldown == 0)
		{
			animator.SetBool("start", true);
			animator.SetBool("open", true);
			audioS.Play();
			netbookOpen = !netbookOpen;
			StartCoroutine(coolD());
			cooldown = 1;
		}
	}

	private IEnumerator coolD()
	{
		yield return new WaitForSeconds(0.6f);
		cooldown = 0;
	}
}
