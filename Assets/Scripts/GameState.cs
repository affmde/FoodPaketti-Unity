using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
	void Update()
	{
		if (PlayerData.gameOver)
			SceneManager.LoadScene("GameOver");
	}
}
