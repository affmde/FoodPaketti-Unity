using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
	}
	public void	StartGame()
	{
		audioSource.Play();
		SceneManagement.ChangeScene("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		audioSource.Play();
		SceneManagement.ChangeScene("Highscores");
	}
}
