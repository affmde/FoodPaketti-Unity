using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
	private Image fruitPowerup;
	[SerializeField]
	private float	fruitLimit = 10f;
	private int		currentFruit;
	private	int		referenceValue;
	private string	fruitRef;


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
		fruitPowerup = GetComponent<Image>();
	}

	private void Start()
	{
		GetFruitRef();
		fruitPowerup.fillAmount = 0;
		referenceValue = PlayerPrefs.GetInt(fruitRef);
	}

	private void Update()
	{
		currentFruit = PlayerPrefs.GetInt(fruitRef) - referenceValue;
		if (currentFruit >= fruitLimit)
		{
			currentFruit = 0;
		}
		fruitPowerup.fillAmount = currentFruit / fruitLimit;
		if (fruitPowerup.name == "BananaPowerup")
			Debug.Log("fill amount: " + fruitPowerup.fillAmount);
	}
}
