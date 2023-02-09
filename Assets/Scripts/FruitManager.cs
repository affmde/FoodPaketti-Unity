using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	private PlayerData playerData;
    

	private void Awake()
	{
		playerData = FindAnyObjectByType<PlayerData>();
	}

    private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "DownBorder")
			Destroy(gameObject);
		if (col.collider.name == "Basket")
		{
			if (gameObject.name == "Banana")
			{
				playerData.points += 25;
				playerData.bananas++;
			}
			else if (gameObject.name == "Orange")
			{
				playerData.points += 15;
				playerData.oranges++;
			}
			else if (gameObject.name == "Apple")
			{
				playerData.apples++;
				playerData.points += 10;
			}
			playerData.totalFruits++;
			Destroy(gameObject);
		}
	}
}
