using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
	//private PlayerData playerData;
	[SerializeField]
	private TextMeshProUGUI pointsText;
	private void Awake()
	{
		//playerData = FindObjectOfType<PlayerData>();
	}

	public void ReadStringInput(string str)
	{
		PlayerData.username = str;
		Debug.Log(PlayerData.username);
	}

	private void Start()
	{
		pointsText.text = PlayerData.points.ToString();
	}

}
