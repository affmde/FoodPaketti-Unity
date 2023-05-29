using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
	private void	Start()
	{
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
	}

	public void	ShowGameStats()
	{
		fruitsStatsArea.SetActive(false);
		startArea.SetActive(false);
		gameStatsArea.SetActive(true);
		ScoresStatsArea.SetActive(false);
		totalHighScoreGames.text = UserData.totalHighScoreGames.ToString();
		totalTimePlayed.text = UserData.totalTimePlayed.ToString();
		totalXP.text = UserData.xp.ToString();
		totalScoreTogether.text = UserData.totalPointsAcomolated.ToString();
	}

	public void	ShowScoresStats()
	{
		fruitsStatsArea.SetActive(false);
		startArea.SetActive(false);
		gameStatsArea.SetActive(false);
		ScoresStatsArea.SetActive(true);
		//UserData.ownBestScores.Sort();
		maxScore.text = GetPersonalBestScore().ToString();
		maxTime.text = GetPersonalBestTime().ToString();
	}

	private int	GetPersonalBestScore()
	{
		int best = 0;
		foreach(var score in UserData.ownBestScores)
		{
			if (score.score > best)
				best = score.score;
		}
		return (best);
	}

	private int	GetPersonalBestTime()
	{
		int best = 0;
		foreach(var game in UserData.ownBestScores)
		{
			Debug.Log(game.duration);
			if (game.duration > best)
				best = Mathf.FloorToInt(game.duration);
		}
		return (best);
	}

	public void	GoToHome()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 0.5f);
	}
}
