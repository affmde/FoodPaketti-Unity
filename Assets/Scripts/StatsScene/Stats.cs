using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Stats : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI	name;
	[SerializeField] private TextMeshProUGUI	apples;
	[SerializeField] private TextMeshProUGUI	bananas;
	[SerializeField] private TextMeshProUGUI	oranges;
	[SerializeField] private TextMeshProUGUI	totalFruits;
	[SerializeField] private GameObject			fruitsStatsArea;
	[SerializeField] private GameObject			startArea;
	[SerializeField] private GameObject			gameStatsArea;
	[SerializeField] private GameObject			ScoresStatsArea;
	[SerializeField] private TextMeshProUGUI	totalHighScoreGames;
	[SerializeField] private TextMeshProUGUI	totalTimePlayed;
	[SerializeField] private TextMeshProUGUI	maxScore;
	[SerializeField] private TextMeshProUGUI	maxTime;
	[SerializeField] private TextMeshProUGUI	totalScoreTogether;
	[SerializeField] private TextMeshProUGUI	totalXP;
	[SerializeField] private List<AudioSource>	audioList;

	private void	Awake()
	{
		foreach(AudioSource audioS in audioList)
			SceneManagement.ToogleAudioSource(audioS);
	}
	private void	Start()
	{
		audioList[0].Play();
		startArea.SetActive(true);
		fruitsStatsArea.SetActive(false);
		gameStatsArea.SetActive(false);
		ScoresStatsArea.SetActive(false);
		name.text = UserData.username;
		StartCoroutine(API.GetUserData());
	}

	public void	ShowFruitsStas()
	{
		apples.text = UserData.apples.ToString();
		bananas.text = UserData.bananas.ToString();
		oranges.text = UserData.oranges.ToString();
		totalFruits.text = UserData.totalFruits.ToString();
		fruitsStatsArea.SetActive(true);
		startArea.SetActive(false);
		gameStatsArea.SetActive(false);
		ScoresStatsArea.SetActive(false);
		audioList[1].Play();
	}

	public void	ShowGameStats()
	{
		string	hours = TimeSpan.FromSeconds(UserData.totalTimePlayed).Hours.ToString();
		string	minutes = TimeSpan.FromSeconds(UserData.totalTimePlayed).Minutes.ToString();
		string	seconds = TimeSpan.FromSeconds(UserData.totalTimePlayed).Seconds.ToString();
		fruitsStatsArea.SetActive(false);
		startArea.SetActive(false);
		gameStatsArea.SetActive(true);
		ScoresStatsArea.SetActive(false);
		totalHighScoreGames.text = UserData.totalHighScoreGames.ToString();
		totalTimePlayed.text = hours + "h " + minutes + "m " + seconds + "s";
		totalXP.text = UserData.xp.ToString();
		totalScoreTogether.text = UserData.totalPointsAcomolated.ToString();
		audioList[1].Play();
	}

	public void	ShowScoresStats()
	{
		fruitsStatsArea.SetActive(false);
		startArea.SetActive(false);
		gameStatsArea.SetActive(false);
		ScoresStatsArea.SetActive(true);
		maxScore.text = UserData.maxPoints.ToString();
		maxTime.text = UserData.maxDuration.ToString();
		audioList[1].Play();
	}

	public void	GoToHome()
	{
		audioList[1].Play();
		SceneManagement.ChangeScene("StartScene", Color.black, 0.5f);
	}
}
