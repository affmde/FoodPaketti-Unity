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

	public void	PlayAgain()
	{
		state.ResetData();
		SceneManagement.ChangeScene("SampleScene");
	}

	public void	GoToHome()
	{
		state.ResetData();
		SceneManagement.ChangeScene("StartScene");
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
