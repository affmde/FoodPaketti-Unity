using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
	public static string	facebookId;
	public static string	name;
	public static string	first_name;
	public static string	last_name;
	public static string	username;
	public static string	email;
	public static int		level;
	public static int		experience;
	public static int[]		completedLevels;
	public static int		totalFruits;
	public static int		apples;
	public static int		oranges;
	public static int		bananas;
	public static List<DataForSend>		ownBestScores;
	public static int		totalHighscoreGames;
	public static int		totalTimePlayed;
	public static string	jsonUserDataString;

}

[System.Serializable]
public class UserDataForSend
{
	public bool		success;
	public string	message;
	public DataUSer	data;
}

[System.Serializable]
public struct DataUSer
{
	public string	name;
	public string	username;
	public int		level;
	public int		xp;
	public int[]		completedLevels;
	public int		totalFruits;
	public int		apples;
	public int		oranges;
	public int		bananas;
	public List<DataForSend>	ownBestScores;
	public int		totalHighscoreGames;
	public int		totalTimePlayed;
}
