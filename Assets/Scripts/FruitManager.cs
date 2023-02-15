using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	private PlayerData playerData;
    

	private void Awake()
	{
		playerData = FindAnyObjectByType<GameState>().playerData;
	}

    private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "DownBorder")
			Destroy(gameObject);
		if (col.collider.name == "Basket")
		{
			if (gameObject.name == "banana(Clone)")
			{
				playerData.score += 25;
				playerData.bananas++;
			}
			else if (gameObject.name == "orange(Clone)")
			{
				playerData.score += 10;
				playerData.oranges++;
			}
			else if (gameObject.name == "green-apple(Clone)")
			{
				playerData.apples++;
				playerData.score += 5;
			}
			else if (gameObject.name == "bombVertical(Clone)")
			{
				playerData.gameOver = true;
			}
			playerData.totalFruits++;
			Destroy(gameObject);
		}
	}
}
