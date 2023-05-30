using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
	//private PlayerData playerData;
	[SerializeField] private TextMeshProUGUI pointsText;

	public void ReadStringInput(string str)
	{
		//playerData.username = str;
		PlayerPrefs.SetString("username", str);
	}

	private void Start()
	{
		pointsText.text = PlayerPrefs.GetInt("score").ToString();
	}

}
