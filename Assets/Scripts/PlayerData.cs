using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public bool		gameOver = false;
	public int		apples;
	public int		oranges;
	public int		bananas;
	public int		totalFruits;
	public int		points;
	public float	duration;
	public string	username;
}


[System.Serializable]
public class Player
{
    public string playerId;
    public string playerLoc;
    public string playerNick;
}