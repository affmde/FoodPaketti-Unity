using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
	private HandleBonus bonusHandling;

	private void Awake()
	{
		bonusHandling = FindObjectOfType<HandleBonus>();
	}
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket")
		{
			bonusHandling.slider.gameObject.SetActive(true);
			bonusHandling.bonusOn = true;
			PlayerPrefs.SetInt("multiplier", 2);
			bonusHandling.currentAmount = 1;
			Destroy(gameObject);
		}
	}
}
