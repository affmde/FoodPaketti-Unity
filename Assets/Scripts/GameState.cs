using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
	public PlayerData playerData;
	private void Awake()
	{
		playerData = new PlayerData();
		DontDestroyOnLoad(transform.gameObject);
	}

	public void	ResetData()
	{
		playerData.username = "";
		playerData.score = 0;
		playerData.duration = 0;
		playerData.apples = 0;
		playerData.oranges = 0;
		playerData.bananas = 0;
		playerData.gameOver = false;
		playerData.totalFruits = 0;
	}

	/*void Update()
	{
		if (playerData.gameOver)
		{
			playerData.gameOver = false;
			SceneManager.LoadScene("GameOver");
		}
	}*/
}
