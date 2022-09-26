using UnityEngine;

public class tyktyk : MonoBehaviour
{
	public Animator anim;

	public GameObject flopik;

	public AudioSource audio;

	public int once;

	private void Start()
	{
	}

	private void Update()
	{
		mainBrain component = GameObject.Find("Mosters").GetComponent<mainBrain>();
		energy component2 = GameObject.Find("batary").GetComponent<energy>();
		if (component2.off)
		{
			if (component.FloppaHere && once == 0)
			{
				audio.Play();
				anim.SetInteger("DoorOpened", 2);
				once = 1;
			}
			else if (once == 1 && !component.FloppaHere)
			{
				anim.SetInteger("DoorOpened", 1);
				once = 0;
			}
		}
		if (!component2.off)
		{
			flopik.SetActive(false);
			anim.SetInteger("DoorOpened", 2);
		}
	}
}
