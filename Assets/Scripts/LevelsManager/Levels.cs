using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Levels : MonoBehaviour
{
	[SerializeField] GameObject			loadingPanel;
	[SerializeField] List<AudioSource>	audioList;

	private void	Awake()
	{
		StartCoroutine(LoadLevels());
	}

	private void	Start()
	{
		foreach (AudioSource audioS in audioList)
			SceneManagement.ToogleAudioSource(audioS);
	}

	private IEnumerator LoadLevels()
	{
		yield return (API.GetLevels());
		loadingPanel.SetActive(false);
		int index = UserData.completedLevels.Max();
		Debug.Log("size: " + UserData.completedLevels.Count + " max: " + UserData.completedLevels.Max());
		foreach(int level in UserData.completedLevels)
			Debug.Log("Level completed: " + level);
		if (UserData.completedLevels.Count <= 1)
			LevelsData.level = 0;
		else
			LevelsData.level = index;
		LevelsStruct currentLevel = FindCurrentLevel(index + 1);
		LevelsData.title = currentLevel.title;
		LevelsData.description = currentLevel.description;
		LevelsData.type = currentLevel.type;
		LevelsData.xp = currentLevel.xp;
		LevelsData.scorer = currentLevel.scorer;
		LevelsData.survivor = currentLevel.survivor;
		LevelsData.bananaOdd = currentLevel.bananaOdd;
		LevelsData.appleOdd = currentLevel.appleOdd;
		LevelsData.orangeOdd = currentLevel.orangeOdd;
		LevelsData.difficulty = currentLevel.difficulty;
		LevelsData.collector = currentLevel.collector;
		LevelsData.collector.bananas = currentLevel.collector.bananas;
		LevelsData.collector.apples = currentLevel.collector.apples;
		LevelsData.collector.oranges = currentLevel.collector.oranges;
		LevelsData.collector.totalFruits = currentLevel.collector.totalFruits;
		LevelsData.collector.parsimmons = currentLevel.collector.parsimmons;
		LevelsData.collector.watermelons = currentLevel.collector.watermelons;
	}

	public void	Return()
	{
		audioList[1].Play();
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	LevelsStruct	FindCurrentLevel(int currentLevel)
	{
		foreach (var l in API.levelsData.data)
		{
			if (l.level == currentLevel)
				return (l);
		}
		return (null);
	}
}
