using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
	private GameState	state;
	public List<AudioSource> audioSource;
	private void Awake()
	{
		state = FindAnyObjectByType<GameState>();
	}


	private void Start()
	{

	}

	public void	PlayAgain()
	{
		audioSource[0].Play();
		state.ResetData();
		SceneManagement.ChangeScene("SampleScene");
	}

	public void	GoToHome()
	{
		audioSource[0].Play();
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
		audioSource[1].Play();
	}
}
