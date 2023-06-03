using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
	[SerializeField] AudioSource	audioSource;

	private void Start()
	{
		SceneManagement.ToogleAudioSource(audioSource);
	}
	public void	Continue()
	{
		StartCoroutine(SaveLevel());
	}

	private IEnumerator SaveLevel()
	{
		yield return (API.SaveCompletedLevel());
		PlayerData.ResetData();
		UserData.completedLevels.Add(LevelsData.level + 1);
		SceneManagement.ChangeScene("LevelsManagerScene", Color.black, 0.5f);
	}
}
