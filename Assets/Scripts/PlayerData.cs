using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public static class PlayerData
{
	public static bool	gameOver = false;
	public static bool	isPaused = false;
	public static bool	bombDefused = false;
	public static void	ResetData()
	{
		PlayerPrefs.SetInt("score", 0);
		PlayerPrefs.SetInt("apples", 0);
		PlayerPrefs.SetInt("bananas", 0);
		PlayerPrefs.SetInt("oranges", 0);
		PlayerPrefs.SetInt("parsimmons", 0);
		PlayerPrefs.SetInt("watermelons", 0);
		PlayerPrefs.SetInt("totalFruits", 0);
		PlayerPrefs.SetFloat("duration", 0);
		PlayerPrefs.SetInt("multiplier", 1);
		PlayerData.gameOver = false;
		PlayerData.isPaused = false;
		PlayerData.bombDefused = false;
	}
}

[System.Serializable]
public class DataForSend
{
	public int		apples;
	public int		oranges;
	public int		bananas;
	public int		parsimons;
	public int		watermelons;
	public int		totalFruits;
	public int		score;
	public float	duration;
	public string	username;
}

public static class UserData
{
	public static string			userDataJson;
	public static string			username;
	public static string			facebookId;
	public static int				level;
	public static int				xp;
	public static List<int>			completedLevels;
	public static int				totalFruits;
	public static int				bananas;
	public static int				oranges;
	public static int				apples;
	public static int				parsimmons;
	public static int				watermelons;
	public static int				totalHighScoreGames;
	public static int				totalTimePlayed;
	public static int				totalPointsAcomolated;
	public static List<DataForSend> ownBestScores;


	public static int				maxPoints;
	public static int				maxDuration;
	public static float				playerLevelProgress;

}

[System.Serializable]
public class UserDataToAPI
{
	public bool		success;
	public string	message;
	public Data		data;
}


[System.Serializable]
public struct Data
{
	public string			username;
	public string			facebookId;
	public int				level;
	public int				xp;
	public List<int>		completedLevels;
	public int				totalFruits;
	public int				bananas;
	public int				oranges;
	public int				apples;
	public int				parsimmons;
	public int				watermelons;
	public int				totalHighScoreGames;
	public int				totalTimePlayed;
	public int				totalPointsAcomolated;
	public List<DataForSend> ownBestScores;
}