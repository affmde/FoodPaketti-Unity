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
		Debug.Log("Name: " + UserData.name);
		Debug.Log("Facebook id: " + UserData.facebookId);
	}
	public void	StartGame()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("Highscores");
	}

	public void	QuitApp()
	{
		Application.Quit();
	}
}
