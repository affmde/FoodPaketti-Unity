using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RewardPlayer : MonoBehaviour
{

	private Vector2 screenBounds;
	private bool	RewardReleased;
	private float randomX;

	private void	Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		randomX = Random.Range(-screenBounds.x, screenBounds.x - screenBounds.x / 2);
		ActiveReward();
	}

	private void	ActiveReward()
	{
		int	percent = Random.Range(0, 100);
		if (percent < 50)
			gameObject.SetActive(false);
	}

	public void	ReleaseReward()
	{
		Vector3 newPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
		gameObject.transform.position = newPos;
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket" && PlayerData.gameOver == false)
		{
			PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 200);
			Destroy(gameObject);
		}
	}



	private void	Update()
	{
		if (transform.position.x >= randomX && !RewardReleased)
			RewardReleased = true;
		if (RewardReleased)
			ReleaseReward();
	}
}
