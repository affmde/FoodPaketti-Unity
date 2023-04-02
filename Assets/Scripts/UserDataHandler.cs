using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataHandler : MonoBehaviour
{
	[SerializeField] UserDataForSend userData;
	public void	UserDataParser()
	{
		Debug.Log(UserData.jsonUserDataString);
		userData = JsonUtility.FromJson<UserDataForSend>(UserData.jsonUserDataString);
		Debug.Log("USer data received");
		Debug.Log("message: " + userData.message);
		Debug.Log("success status: " + userData.success);
		PopulateUserData();
	}

	public void	PopulateUserData()
	{
		UserData.name = userData.data.name;
		UserData.username = userData.data.username;
		//UserData.email = userData.userData.email;
		UserData.level = userData.data.level;
		UserData.experience = userData.data.xp;
		UserData.completedLevels = userData.data.completedLevels;
		UserData.totalFruits = userData.data.totalFruits;
		UserData.apples = userData.data.apples;
		UserData.oranges = userData.data.oranges;
		UserData.bananas = userData.data.bananas;
		UserData.ownBestScores = userData.data.ownBestScores;
		UserData.totalHighscoreGames = userData.data.totalHighscoreGames;
		UserData.totalTimePlayed = userData.data.totalTimePlayed;
	}

	private void	Awake()
	{
		UserDataParser();
	}

	private void	Start()
	{
		PopulateUserData();
	}
}
