using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
	private AudioSource audioSource;
	private AudioSource backtrack;
	private SceneLoader loadingScreen;
	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		loadingScreen = FindAnyObjectByType<SceneLoader>();
	}

	private void Start()
	{
		PlayerData.ResetData();
	}
	public void	StartGame()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		//SceneManagement.ChangeScene("SampleScene", Color.black, 1f);
		loadingScreen.StartGame("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		//SceneManagement.ChangeScene("Highscores", Color.black, 1f);
		loadingScreen.StartGame("Highscores");
	}

	public void	QuitApp()
	{
		Application.Quit();
	}
}
