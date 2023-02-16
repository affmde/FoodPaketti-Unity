using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
	//private SendData api;
	private PlayerData data;

	private void Awake()
	{
		//api = GetComponent<SendData>();
		data = FindAnyObjectByType<GameState>().playerData;
	}


	private void Start()
	{

	}

	public void PostData(PlayerData data)
	{
		//string jsonString = SendData.Stringify(data);
		//Debug.Log("json string: " + jsonString);
		StartCoroutine(SendData.Post(data));
		//StartCoroutine(SendData.Post(jsonString));
	}

	public void SaveScore()
	{
		PostData(data);
	}
}
