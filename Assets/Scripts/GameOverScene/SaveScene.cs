using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
	public List<AudioSource> audioSource;
	private AudioSource backtrack;
	private SceneLoader loader;
	private void Awake()
	{
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		loader = FindAnyObjectByType<SceneLoader>();
	}

	public void	PlayAgain()
	{
		audioSource[0].Play();
		PlayerData.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("SampleScene", Color.black, 1f);
	}

	public void	GoToHome()
	{
		audioSource[0].Play();
		PlayerData.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	public void	GoBack()
	{
		audioSource[0].Play();
		PlayerData.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		SceneManagement.ChangeScene("RegisterLogin", Color.black, 1f);
	}

	private void PostData()
	{
		StartCoroutine(SendData.Post());
		PlayerData.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		if (UserData.logedIn)
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		else
			SceneManagement.ChangeScene("RegisterLogin", Color.black, 1f);
	}

	public void SaveScore()
	{
		PostData();
		audioSource[1].Play();
	}
}
