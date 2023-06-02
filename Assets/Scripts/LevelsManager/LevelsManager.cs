using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class LevelsManager : MonoBehaviour
{
	[SerializeField] private bool		unlocked;
	[SerializeField] private int		level;
	[SerializeField] private bool		completed;
	public Image						unlockImage;
	public Image						completedImage;
	private GameObject					levelInfoPanel;
	[SerializeField] TextMeshProUGUI	levelText;

	private void	Awake()
	{
		levelInfoPanel = GameObject.FindWithTag("LevelInfoPanel");
	}

	private void	Start()
	{
		levelInfoPanel.SetActive(false);
		level = int.Parse(gameObject.name);
		levelText.text = gameObject.name;
		if (UserData.completedLevels.Contains(int.Parse(gameObject.name)))
			completed = true;
		if (UserData.completedLevels.Contains(level - 1))
			unlocked = true;
		if (UserData.completedLevels.Contains(level) || (UserData.completedLevels.Count == 0 && level == 1))
			unlocked = true;
		if (level == 1)
		{
			unlockImage.gameObject.SetActive(false);
			unlocked = true;
		}
		UpdateLevelImage();
	}

	private void	UpdateLevelImage()
	{
		if (!unlocked){
			unlockImage.gameObject.SetActive(true);
			completedImage.gameObject.SetActive(false);
		}
		else if (unlocked && !completed)
		{
			Debug.Log("HEre!!!");
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(false);
		}
		else
		{
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(true);
		}
	}

	public void	PressLevel()
	{
		if (unlocked && !completed)
		{
			levelInfoPanel.SetActive(true);
			LevelsData.level = level;
			LevelsData.scorer = API.levelsData.data[level -1].scorer;
			LevelsData.survivor = API.levelsData.data[level - 1].survivor;
			LevelsData.type = API.levelsData.data[level - 1].type;
			LevelsData.bananaOdd = API.levelsData.data[LevelsData.level - 1].bananaOdd;
			LevelsData.appleOdd = API.levelsData.data[LevelsData.level - 1].appleOdd;
			LevelsData.orangeOdd = API.levelsData.data[LevelsData.level - 1].orangeOdd;
			LevelsData.difficulty = API.levelsData.data[LevelsData.level - 1].difficulty;
			LevelsData.xp = API.levelsData.data[LevelsData.level - 1].xp;
			LevelsData.description = API.levelsData.data[LevelsData.level - 1].description;
			LevelsData.title = API.levelsData.data[LevelsData.level - 1].title;
			LevelsData.collector.apples = API.levelsData.data[level - 1].collector.apples;
			LevelsData.collector.oranges = API.levelsData.data[level - 1].collector.oranges;
			LevelsData.collector.bananas = API.levelsData.data[level - 1].collector.bananas;
			LevelsData.collector.totalFruits = API.levelsData.data[level - 1].collector.totalFruits;
			LevelsData.collector.parsimmons = API.levelsData.data[level - 1].collector.parsimmons;
			LevelsData.collector.watermelons = API.levelsData.data[level - 1].collector.watermelons;
		}
	}

	public void	Return()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
