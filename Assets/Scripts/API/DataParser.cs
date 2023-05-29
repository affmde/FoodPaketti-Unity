using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataParser
{
	[SerializeField]private static UserDataToAPI userData;
	
	public static void	UserDataParser()
	{
		userData = JsonUtility.FromJson<UserDataToAPI>(UserData.userDataJson);
		UserData.username = userData.data.username;
		UserData.facebookId = userData.data.facebookId;
		UserData.level = userData.data.level;
		UserData.xp = userData.data.xp;
		UserData.completedLevels = userData.data.completedLevels;
		UserData.totalFruits = userData.data.totalFruits;
		UserData.bananas = userData.data.bananas;
		UserData.oranges = userData.data.oranges;
		UserData.apples = userData.data.apples;
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
			Debug.Log(game.duration);
			if (game.duration > best)
				best = Mathf.FloorToInt(game.duration);
		}
		return (best);
	}

	public static void	GameSettings()
	{
		for(int i = 0; i < 20; i++)
		{
			PlayerData.levelRamp[i] = 2000 * Mathf.Pow(i, 1.5f);
		}
	}
}
