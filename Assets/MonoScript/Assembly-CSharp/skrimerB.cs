using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skrimerB : MonoBehaviour
{
	public Animation anim;

	private void Start()
	{
		anim.Play();
		StartCoroutine(lose());
		CameraShake.Shake(1f, 0.5f);
	}

	private IEnumerator lose()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("loseOtFloppa");
	}
}
