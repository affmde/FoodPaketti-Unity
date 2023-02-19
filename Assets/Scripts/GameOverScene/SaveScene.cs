using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
	private GameState	state;
	public List<AudioSource> audioSource;
	private AudioSource backtrack;
	private void Awake()
	{
		state = FindAnyObjectByType<GameState>();
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
	}


	private void Start()
	{

	}

	public void	PlayAgain()
	{
		audioSource[0].Play();
		state.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("SampleScene", Color.black, 1f);
	}

	public void	GoToHome()
	{
		audioSource[0].Play();
		state.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	private void PostData(PlayerData data)
	{
		StartCoroutine(SendData.Post(data));
		state.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	public void SaveScore()
	{
		PostData(state.playerData);
		audioSource[1].Play();
	}
}
