using UnityEngine;

public class Flashlight_PRO : MonoBehaviour
{
	[Space(10f)]
	[SerializeField]
	private GameObject Lights;

	[SerializeField]
	private AudioSource switch_sound;

	[SerializeField]
	private ParticleSystem dust_particles;

	private Light spotlight;

	private Material ambient_light_material;

	private Color ambient_mat_color;

	private bool is_enabled;

	private void Start()
	{
		spotlight = Lights.transform.Find("Spotlight").GetComponent<Light>();
		ambient_light_material = Lights.transform.Find("ambient").GetComponent<Renderer>().material;
		ambient_mat_color = ambient_light_material.GetColor("_TintColor");
	}

	public void Change_Intensivity(float percentage)
	{
		percentage = Mathf.Clamp(percentage, 0f, 100f);
		spotlight.intensity = 8f * percentage / 100f;
		ambient_light_material.SetColor("_TintColor", new Color(ambient_mat_color.r, ambient_mat_color.g, ambient_mat_color.b, percentage / 2000f));
	}

	public void Switch()
	{
		is_enabled = !is_enabled;
		Lights.SetActive(is_enabled);
		if (switch_sound != null)
		{
			switch_sound.Play();
		}
	}

	public void Enable_Particles(bool value)
	{
		if (dust_particles != null)
		{
			if (value)
			{
				dust_particles.gameObject.SetActive(true);
				dust_particles.Play();
			}
			else
			{
				dust_particles.Stop();
				dust_particles.gameObject.SetActive(false);
			}
		}
	}
}
