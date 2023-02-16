using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
	private PlayerData playerData;
	[SerializeField]
	private TextMeshProUGUI pointsText;
	
	private void Awake()
	{
		playerData = FindObjectOfType<GameState>().playerData;
	}

	public void ReadStringInput(string str)
	{
		playerData.username = str;
	}

	private void Start()
	{
		pointsText.text = playerData.score.ToString();
	}

}
