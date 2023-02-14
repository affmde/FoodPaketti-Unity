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
		Debug.Log(playerData.username);
	}

	private void Start()
	{
		pointsText.text = playerData.points.ToString();
	}

}
