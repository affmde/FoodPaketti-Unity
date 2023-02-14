using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
	public void	StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		SceneManager.LoadScene("Heighscores");
	}
}
