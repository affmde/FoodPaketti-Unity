using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	//private PlayerData playerData;
    

	private void Awake()
	{
		//playerData = FindAnyObjectByType<PlayerData>();
	}

    private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "DownBorder")
			Destroy(gameObject);
		if (col.collider.name == "Basket")
		{
			if (gameObject.name == "banana(Clone)")
			{
				PlayerData.points += 25;
				PlayerData.bananas++;
			}
			else if (gameObject.name == "orange(Clone)")
			{
				PlayerData.points += 10;
				PlayerData.oranges++;
			}
			else if (gameObject.name == "green-apple(Clone)")
			{
				PlayerData.apples++;
				PlayerData.points += 5;
			}
			else if (gameObject.name == "bombVertical(Clone)")
			{
				PlayerData.gameOver = true;
			}
			PlayerData.totalFruits++;
			Destroy(gameObject);
		}
	}
}
