using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataParser
{
	[SerializeField]private static UserDataToAPI userData;
	
	public static void	UserDataParser()
	{
		userData = JsonUtility.FromJson<UserDataToAPI>(UserData.userDataJson);
		if (PlayerPrefs.HasKey("username") && PlayerPrefs.GetString("username").Length > 0)
			UserData.username = PlayerPrefs.GetString("username");
		else
			UserData.username = userData.data.username;
		UserData.facebookId = userData.data.facebookId;
		UserData.level = userData.data.level;
		UserData.xp = userData.data.xp;
		UserData.completedLevels = userData.data.completedLevels;
		UserData.totalFruits = userData.data.totalFruits;
		UserData.bananas = userData.data.bananas;
		UserData.oranges = userData.data.oranges;
		UserData.apples = userData.data.apples;
		UserData.parsimmons = userData.data.parsimmons;
		UserData.watermelons = userData.data.watermelons;
		UserData.totalHighScoreGames = userData.data.totalHighScoreGames;
		UserData.totalTimePlayed = userData.data.totalTimePlayed;
		UserData.ownBestScores = userData.data.ownBestScores;
		UserData.totalPointsAcomolated = userData.data.totalPointsAcomolated;
		UserData.maxPoints = GetPersonalBestScore();
		UserData.maxDuration = GetPersonalBestTime();
	}

	private static int	GetPersonalBestScore()
	{
		int best = 0;
		foreach(var score in UserData.ownBestScores)
		{
			if (score.score > best)
				best = score.score;
		}
		return (best);
	}

	private static int	GetPersonalBestTime()
	{
		int best = 0;
		foreach(var game in UserData.ownBestScores)
		{
			if (game.duration > best)
				best = Mathf.FloorToInt(game.duration);
		}
		return (best);
	}
}
