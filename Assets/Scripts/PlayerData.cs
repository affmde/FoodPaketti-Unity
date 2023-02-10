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


	private void	Update()
	{
		if (gameOver)
			SceneManager.LoadScene("GameOver");
	}
}

