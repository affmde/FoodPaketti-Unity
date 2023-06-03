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
		foreach(var audioS in audioSource)
			SceneManagement.ToogleAudioSource(audioS);
		SceneManagement.ToogleAudioSource(backtrack);
	}

	private void PostData()
	{
		if (GameSettings.gameType == "highscores")
		{
			StartCoroutine(SendData.Post());
			StartCoroutine(API.SaveGameData(GameSettings.xpGained));
		}
		else if (GameSettings.gameType == "levelGame")
			StartCoroutine(API.SaveLevelGame());
		PlayerData.ResetData();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.25f));
		if (GameSettings.gameType == "highscores")
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		else if (GameSettings.gameType == "levelGame")
			SceneManagement.ChangeScene("LevelsManagerScene", Color.black, 1f);
	}

	public void Continue()
	{
		audioSource[1].Play();
		PostData();
	}
}
