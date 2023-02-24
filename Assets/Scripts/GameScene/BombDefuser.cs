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
	}
	public void	DefuseBomb()
	{
		PlayerData.bombDefused = true;
		fillTimeRef = PlayerPrefs.GetFloat("duration");
	}

	private void Update()
	{
		currentTime = PlayerPrefs.GetFloat("duration") - fillTimeRef;
		image.fillAmount = Mathf.Clamp01(currentTime / timeToFill);
		if (currentTime >= timeToFill)
			button.interactable = true;
	}
}
