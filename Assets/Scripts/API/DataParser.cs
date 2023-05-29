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
	}
}
