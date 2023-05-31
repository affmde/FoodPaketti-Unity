using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
	private Image fruitPowerup;
	[SerializeField]
	private float	fruitLimit = 2f;
	private int		currentFruit;
	private	int		referenceValue;
	private string	fruitRef;
	[SerializeField]
	private GameObject anaimationManager;
	private AnimatedFruits fruitAnim;
	private	AudioSource powerupSound;
	private void GetFruitRef()
	{
		if (fruitPowerup.name == "ApplePowerup")
			fruitRef = "apples";
		else if (fruitPowerup.name == "OrangePowerup")
			fruitRef = "oranges";
		else if (fruitPowerup.name == "BananaPowerup")
			fruitRef = "bananas";
	}

	private void Awake()
	{
		fruitAnim = anaimationManager.GetComponent<AnimatedFruits>();
		fruitPowerup = GetComponent<Image>();
		powerupSound = GameObject.Find("PowerupSound").GetComponent<AudioSource>();
	}

	private void Start()
	{
		GetFruitRef();
		fruitPowerup.fillAmount = 0;
		referenceValue = PlayerPrefs.GetInt(fruitRef);
		SceneManagement.ToogleAudioSource(powerupSound);
	}

	private void Update()
	{
		currentFruit = PlayerPrefs.GetInt(fruitRef) - referenceValue;
		if (currentFruit >= fruitLimit)
		{
			referenceValue = PlayerPrefs.GetInt(fruitRef);
			powerupSound.Play();
			fruitAnim.AnimateFruits(fruitPowerup.name);
		}
		fruitPowerup.fillAmount = currentFruit / fruitLimit;
	}
}
