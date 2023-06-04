using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CompletedLevel : MonoBehaviour
{
	[SerializeField] List<AudioSource>	audioList;
	[SerializeField] TextMeshProUGUI	title;
	private void Start()
	{
		foreach (AudioSource audioS in audioList)
			SceneManagement.ToogleAudioSource(audioS);
		title.text = LevelsData.title;
	}
	public void	Continue()
	{
		audioList[1].Play();
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
