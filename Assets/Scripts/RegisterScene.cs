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
		audioSource.Play();
	}
}
