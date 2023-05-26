using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class PlayerData
{
	public static bool	gameOver = false;
	public static bool	bombDefused = false;

	public static void	ResetData()
	{
		PlayerPrefs.SetInt("score", 0);
		PlayerPrefs.SetInt("apples", 0);
		PlayerPrefs.SetInt("bananas", 0);
		PlayerPrefs.SetInt("oranges", 0);
		PlayerPrefs.SetInt("totalFruits", 0);
		PlayerPrefs.SetFloat("duration", 0);
		PlayerPrefs.SetString("username", "");
		PlayerPrefs.SetInt("multiplier", 1);
		PlayerData.gameOver = false;
		PlayerData.bombDefused = false;
	}
}

[System.Serializable]
public class DataForSend
{
	public int		apples;
	public int		oranges;
	public int		bananas;
	public int		totalFruits;
	public int		score;
	public float	duration;
	public string	username;
}

public static class UserData
{
	public static string	username;
	public static string	email;
	public static bool		logedIn;
}