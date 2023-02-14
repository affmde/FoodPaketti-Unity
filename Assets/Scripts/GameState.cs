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

	void Update()
	{
		if (playerData.gameOver)
			SceneManager.LoadScene("GameOver");
	}
}
