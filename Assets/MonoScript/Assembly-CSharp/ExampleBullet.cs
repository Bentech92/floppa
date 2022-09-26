using UnityEngine;

public class ExampleBullet : MonoBehaviour
{
	public GameObject bullet;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2f, ForceMode.Impulse);
			bullet.GetComponent<Rigidbody>().useGravity = true;
		}
	}
}
