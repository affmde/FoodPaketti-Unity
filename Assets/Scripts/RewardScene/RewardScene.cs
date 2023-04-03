using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardScene : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI totalBananas;
	[SerializeField] TextMeshProUGUI totalApples;
	[SerializeField] TextMeshProUGUI totalOranges;
	[SerializeField] TextMeshProUGUI totalTime;
	[SerializeField] TextMeshProUGUI totalScore;
	[SerializeField] TextMeshProUGUI level;
	bool beatWorldRecord = false;
	bool beatPersonalRecord = false;
	[SerializeField] Image fillBar;
	int	xpGained;
	int filler;
	float xpLimit;
	private void Start()
	{
		totalBananas.text = PlayerPrefs.GetInt("bananas").ToString();
		totalApples.text = PlayerPrefs.GetInt("apples").ToString();
		totalOranges.text = PlayerPrefs.GetInt("oranges").ToString();
		int	timeDisplay = Mathf.FloorToInt(PlayerPrefs.GetFloat("duration"));
		totalTime.text =  timeDisplay.ToString();
		totalScore.text = PlayerPrefs.GetInt("score").ToString();
		level.text = UserData.level.ToString();
		xpLimit = 2000 * (UserData.level + 1);
		float xpToShow = xpLimit - 2000 + UserData.experience;
		fillBar.fillAmount = Mathf.Clamp01(xpToShow / 2000);

		//Calculate xp Gained;
		xpGained = PlayerPrefs.GetInt("bananas") * 4 + PlayerPrefs.GetInt("oranges") * 2 + PlayerPrefs.GetInt("apples") * 1 + Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")/ 2);
		if (beatWorldRecord)
			xpGained += 500;
		if (beatPersonalRecord)
			xpGained += 200;
	}

	public void	Continue()
	{
		StartCoroutine(SaveData(xpGained));
	}

	private IEnumerator SaveData(int xp)
	{
		yield return StartCoroutine(SendData.SaveHighscoreGame(xp));
		PlayerData.ResetData();
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	private void	Update()
	{
		if (filler < xpGained)
		{
			filler++;
			float xpToShow = xpLimit - 2000 + UserData.experience + 1;
			fillBar.fillAmount = Mathf.Clamp01(xpToShow / 2000);
			fillBar.fillAmount += Time.deltaTime * 0.05f;
		}
	}

}
