using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDefuser : MonoBehaviour
{
	private Image image;
	private Button button;
	private float	timeToFill = 45;
	private float	fillTimeRef;
	private float	currentTime;
	private void Awake()
	{
		image = GetComponent<Image>();
		button = GetComponent<Button>();
	}

	private void Start()
	{
		image.fillAmount = 0;
		button.interactable = false;
		PlayerData.bombDefused = false;
	}

	IEnumerator resetDefuseBool()
	{
		yield return (new WaitForSeconds(25));
		fillTimeRef = PlayerPrefs.GetFloat("duration");
		PlayerData.bombDefused = false;
	}

	public void	DefuseBomb()
	{
		PlayerData.bombDefused = true;
		image.fillAmount = 0;
		StartCoroutine(resetDefuseBool());
	}

	private void Update()
	{
		if (!PlayerData.bombDefused)
		{
			currentTime = PlayerPrefs.GetFloat("duration") - fillTimeRef;
			image.fillAmount = Mathf.Clamp01(currentTime / timeToFill);
		}
		if (image.fillAmount == 1)
		{
			button.interactable = true;
			currentTime = 0;
		}
		else
			button.interactable = false;
	}
}
