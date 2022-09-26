using UnityEngine;

public class ExplodableMonitor : MonoBehaviour
{
	[SerializeField]
	private GameObject screenExplosionParticleSystem;

	[SerializeField]
	private GameObject screenOff;

	[SerializeField]
	private GameObject screenOn;

	[SerializeField]
	private GameObject shards;

	private bool broken;

	private void Start()
	{
		broken = true;
		screenOff.SetActive(false);
		screenOn.SetActive(false);
		shards.SetActive(true);
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		screenExplosionParticleSystem.SetActive(true);
		Rigidbody[] array = componentsInChildren;
		foreach (Rigidbody obj in array)
		{
			float num = Random.Range(1, 5);
			float xAngle = Random.Range(-20, 20);
			float yAngle = Random.Range(-20, 20);
			float zAngle = Random.Range(-20, 20);
			obj.transform.Rotate(xAngle, yAngle, zAngle);
			obj.AddRelativeForce(Vector3.forward * num, ForceMode.Impulse);
		}
	}
}
