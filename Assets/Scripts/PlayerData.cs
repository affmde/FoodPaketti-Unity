using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
	public bool		gameOver = false;
	public int		apples;
	public int		oranges;
	public int		bananas;
	public int		totalFruits;
	public int		points;
	public float	time;
	public string	playerName;


	public string Stringify()
	{
		return JsonUtility.ToJson(this);
	}

	public static PlayerData Parse(string json)
	{
		return (JsonUtility.FromJson<PlayerData>(json));
	}

	private void	Update()
	{
		//if (gameOver)
		//	SceneManager.LoadScene("GameOver");
	}
}

