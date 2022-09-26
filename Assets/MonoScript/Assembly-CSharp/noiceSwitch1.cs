using UnityEngine;
using UnityEngine.UI;

public class noiceSwitch1 : MonoBehaviour
{
	public Image image;

	public GameObject flashLigts;

	public GameObject flashLigtsAll;

	public bool flashOn = true;
	public bool flash = true;
	public int it;

	public Sprite[] sprites = new Sprite[2];
	public Button flashon;
	public Button flashoff;
	private void Awake()
	{
		flashon.onClick.AddListener(NoParamaterOnclick);
		flashoff.onClick.AddListener(NoParamaterOnclick1);
	}
	private void NoParamaterOnclick()
	{
		flash = true;
		flashon.gameObject.SetActive(false);
		flashoff.gameObject.SetActive(true);
		Debug.Log("Button clicked with no parameters");
	}
	private void NoParamaterOnclick1()
	{
		flash = false;
		flashon.gameObject.SetActive(true);
		flashoff.gameObject.SetActive(false);
		Debug.Log("Button clicked with no parameters");
	}
	private void Start()
	{
		it = 1;
	}

	public void Update()
	{
        if (flash)
        {
            flashOn = !flashOn;
            if (it <= 1)
            {
                it++;
            }
            if (it > 1)
            {
                it = 0;
            }
        }
        if (it==1)
		{
			image.sprite = sprites[0];
			if (!GameObject.Find("batary").GetComponent<energy>().off)
			{
				flashLigts.SetActive(true);
				flashLigtsAll.SetActive(true);
				flashLigts.GetComponent<Light>().intensity = 0.7f;
			}
			else
			{
				flashLigtsAll.SetActive(true);
				flashLigts.SetActive(true);
			}
		}
		if (it == 0)
		{
			image.sprite = sprites[1];
			flashLigts.SetActive(false);
			flashLigtsAll.SetActive(false);
		}
	}

	public void LOL()
	{
	}
}
