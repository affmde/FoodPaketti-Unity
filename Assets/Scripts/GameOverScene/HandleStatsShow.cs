using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HandleStatsShow : MonoBehaviour
{
	[SerializeField] List<GameObject> fruitsObj;
	[SerializeField] List<TextMeshProUGUI> fruitsTxt;
	[SerializeField] Image bestScoreCorrect;
	[SerializeField] Image bestScoreWrong;
	[SerializeField] Image bestTimeCorrect;
	[SerializeField] Image bestTimeWrong;
	[SerializeField] Image worldRecordCorrect;
	[SerializeField] Image worldRecordWrong;
	[SerializeField] Image worldTop10Correct;
	[SerializeField] Image worldTop10Wrong;
	[SerializeField] Image personalTop10Correct;
	[SerializeField] Image personalTop10Wrong;
	[SerializeField] public GameObject experienceBar;
	[SerializeField] public GameObject continueButton;
	private XpBarGameOver	fillBar;
	int	i = 3;
	int						xpAmountToAdd = 0;

	private void	Awake()
	{
		StartCoroutine(API.GetWorldRecord());
		fruitsTxt[0].text = PlayerPrefs.GetInt("bananas").ToString();
		fruitsTxt[1].text = PlayerPrefs.GetInt("apples").ToString();
		fruitsTxt[2].text = PlayerPrefs.GetInt("oranges").ToString();
		fruitsTxt[3].text = PlayerPrefs.GetInt("totalFruits").ToString();
		fillBar = GameObject.FindObjectOfType<XpBarGameOver>();
	}

	private void	Start()
	{
		StartCoroutine(LoadData());
	}

	private IEnumerator	DisplayStats()
	{
		yield return new WaitForSeconds(1f);
		for(int i = 0; i < fruitsObj.Count; i++)
		{
			fruitsObj[i].SetActive(true);
			yield return new WaitForSeconds(0.4f);
		}
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("bananas") * 0.4f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("oranges") * 0.3f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("apples") * 0.25f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("score") * 0.1f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetFloat("duration") * 0.20f);
		yield return new WaitForSeconds(0.5f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), UserData.maxPoints, bestScoreCorrect, bestScoreWrong);
		yield return new WaitForSeconds(0.4f);
		SymbolToDisplay(Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")), UserData.maxDuration, bestTimeCorrect, bestTimeWrong);
		yield return new WaitForSeconds(0.4f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), GameSettings.worldRecord, worldRecordCorrect, worldRecordWrong);
		yield return new WaitForSeconds(0.4f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), GetWorld10thBestScore(), worldTop10Correct, worldTop10Wrong);
		yield return new WaitForSeconds(0.4f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), GetPersonal10thBestScore(), personalTop10Correct, personalTop10Wrong);
		fillBar.UpdateFill(xpAmountToAdd);
		GameSettings.xpGained = xpAmountToAdd;
	}

	private void	SymbolToDisplay(int val, int cmpVal, Image yes, Image no)
	{
		if (val > cmpVal)
		{
			yes.gameObject.SetActive(true);
			if (i == 0)
				xpAmountToAdd += 200;
			else if (i == 1)
				xpAmountToAdd += 150;
			else if (i == 2)
				xpAmountToAdd += 1000;
			else if (i == 3)
				xpAmountToAdd += 600;
			else if (i == 4)
				xpAmountToAdd += 100;
		}
		else
			no.gameObject.SetActive(true);
		i++;
	}

	private int	GetWorld10thBestScore()
	{
		if (SendData.loadedData.Length < 10)
			return (-1);
		return (SendData.loadedData[9].score);
	}

	private int	GetPersonal10thBestScore()
	{
		if (API.personalHighscoreData.data.Count < 10)
			return (-1);
		return (API.personalHighscoreData.data[9].score);

	}

	private IEnumerator	LoadData()
	{
		yield return (StartCoroutine(API.GetWorldRecord()));
		yield return (StartCoroutine(API.GetUserHighscores()));
		yield return (StartCoroutine(SendData.FetchData()));
		continueButton.SetActive(false);
		StartCoroutine(DisplayStats());
	}
}
