using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class ProfileStats : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI totalBananas;
	[SerializeField] TextMeshProUGUI totalApples;
	[SerializeField] TextMeshProUGUI totalOranges;
	[SerializeField] TextMeshProUGUI totalFruits;
	[SerializeField] TextMeshProUGUI totalDuration;
	[SerializeField] TextMeshProUGUI totalHighScoreGames;
	[SerializeField] TextMeshProUGUI totalLevelsCompleted;
	[SerializeField] TextMeshProUGUI level;
	[SerializeField] TextMeshProUGUI totalExperience;


	private void	Start()
	{
		totalBananas.text = UserData.bananas.ToString();
		totalApples.text = UserData.apples.ToString();
		totalOranges.text = UserData.oranges.ToString();
		totalFruits.text = UserData.totalFruits.ToString();
		totalHighScoreGames.text = UserData.totalHighscoreGames.ToString();
		totalExperience.text = UserData.experience.ToString();
		totalLevelsCompleted.text = UserData.completedLevels.Max().ToString();
		level.text = UserData.level.ToString();
		totalDuration.text = UserData.totalTimePlayed.ToString();
	}

	public void	ReturnToStart()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
