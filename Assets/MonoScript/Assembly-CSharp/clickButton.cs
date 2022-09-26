using UnityEngine;

public class clickButton : MonoBehaviour
{
	public Animation anim;

	public Animator animator;

	public int clicked;

	public AudioSource au;

	public bool open;

	public bool onceEnerg = true;

	private void Update()
	{
		energy component = GameObject.Find("batary").GetComponent<energy>();
		if (component.off && clicked == 1)
		{
			if (!animator.GetBool("openVent"))
			{
				au.Play();
				anim.Play();
				open = !open;
				animator.SetBool("openVent", true);
				clicked = 0;
			}
			else if (animator.GetBool("openVent"))
			{
				au.Play();
				anim.Play();
				open = !open;
				animator.SetBool("openVent", false);
				clicked = 0;
			}
		}
		if (!component.off && onceEnerg)
		{
			open = false;
			animator.SetBool("openVent", false);
			clicked = 0;
			onceEnerg = false;
		}
	}

	public void Start()
	{
		clicked = 1;
	}
}
