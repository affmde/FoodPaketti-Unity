using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneManagement
{
	public static void ChangeScene(string scene, Color color, float duration)
	{
		Initiate.Fade(scene, color, duration);
	}

	public static void	ToogleAudioSource(AudioSource audioS)
	{
		if (PlayerPrefs.GetInt("sound") == 1)
			audioS.enabled = false;
		else
			audioS.enabled = true;
	}
}
