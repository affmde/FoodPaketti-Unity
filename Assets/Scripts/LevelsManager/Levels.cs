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
			LevelsData.level = UserData.completedLevels[index];
		LevelsData.title = API.levelsData.data[LevelsData.level].title;
		LevelsData.description = API.levelsData.data[LevelsData.level].description;
		LevelsData.type = API.levelsData.data[LevelsData.level].type;
		LevelsData.xp = API.levelsData.data[LevelsData.level].xp;
		LevelsData.scorer = API.levelsData.data[LevelsData.level].scorer;
		LevelsData.survivor = API.levelsData.data[LevelsData.level].survivor;
		LevelsData.bananaOdd = API.levelsData.data[LevelsData.level].bananaOdd;
		LevelsData.appleOdd = API.levelsData.data[LevelsData.level].appleOdd;
		LevelsData.orangeOdd = API.levelsData.data[LevelsData.level].orangeOdd;
		LevelsData.difficulty = API.levelsData.data[LevelsData.level].difficulty;
		LevelsData.collector = API.levelsData.data[LevelsData.level].collector;
		LevelsData.collector.bananas = API.levelsData.data[LevelsData.level].collector.bananas;
		LevelsData.collector.apples = API.levelsData.data[LevelsData.level].collector.apples;
		LevelsData.collector.oranges = API.levelsData.data[LevelsData.level].collector.oranges;
		LevelsData.collector.totalFruits = API.levelsData.data[LevelsData.level].collector.totalFruits;
		LevelsData.collector.parsimmons = API.levelsData.data[LevelsData.level].collector.parsimmons;
		LevelsData.collector.watermelons = API.levelsData.data[LevelsData.level].collector.watermelons;
	}

	public void	Return()
	{
		audioList[1].Play();
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
