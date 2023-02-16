using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
	private GameState	state;
	private void Awake()
	{
		state = FindAnyObjectByType<GameState>();
	}


	private void Start()
	{

	}

	private void PostData(PlayerData data)
	{
		StartCoroutine(SendData.Post(data));
		state.ResetData();
		SceneManagement.ChangeScene("StartScene");
	}

	public void SaveScore()
	{
		PostData(state.playerData);
	}
}
