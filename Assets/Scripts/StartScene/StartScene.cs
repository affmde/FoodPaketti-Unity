using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
	private AudioSource audioSource;
	private AudioSource backtrack;
	private SceneLoader loadingScreen;
	public TextMeshProUGUI	welcomeText;
	[SerializeField] TextMeshProUGUI level;
	[SerializeField] private Image	fillBar;
	
	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		loadingScreen = FindAnyObjectByType<SceneLoader>();
	}

	private void Start()
	{
		PlayerData.ResetData();

		welcomeText.text = "Welcome " + UserData.name;
		//Fill XP bar
		float xpLimit = 2000 * (UserData.level + 1);
		float xpToShow = xpLimit - 2000 + UserData.experience;
		fillBar.fillAmount = Mathf.Clamp01(xpToShow / 2000);
		Debug.Log("xpLimit: " + xpLimit + "xpToShow: " + xpToShow + "camlp: " + fillBar.fillAmount);
		//Set Top left level value
		level.text = UserData.level.ToString();
	}
	public void	StartGame()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		PlayerPrefs.SetInt("isLoggedIn", 1);
		loadingScreen.StartGame("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("Highscores");
	}

	public void	GoToProfile()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("ProfileScene");
	}

	public void	QuitApp()
	{
		Application.Quit();
	}
}
