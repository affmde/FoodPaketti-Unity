using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterScene : MonoBehaviour
{

	[SerializeField] AudioSource	audioSource;

	private void	Awake()
	{
		SceneManagement.ToogleAudioSource(audioSource);
	}

	private void	Start()
	{
		if (PlayerPrefs.GetInt("login") == 1)
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		audioSource.Play();
	}
}
