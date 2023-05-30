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
		continueButton.SetActive(false);
		StartCoroutine(DisplayStats());
	}

	private IEnumerator	DisplayStats()
	{
		yield return new WaitForSeconds(1f);
		for(int i = 0; i < fruitsObj.Count; i++)
		{
			fruitsObj[i].SetActive(true);
			yield return new WaitForSeconds(0.5f);
		}
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("bananas") * 0.3f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("oranges") * 0.2f);
		xpAmountToAdd += Mathf.FloorToInt(PlayerPrefs.GetInt("apples") * 0.1f);
		yield return new WaitForSeconds(0.5f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), UserData.maxPoints, bestScoreCorrect, bestScoreWrong);
		yield return new WaitForSeconds(0.5f);
		SymbolToDisplay(Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")), UserData.maxDuration, bestTimeCorrect, bestTimeWrong);
		yield return new WaitForSeconds(0.5f);
		SymbolToDisplay(PlayerPrefs.GetInt("score"), GameSettings.worldRecord, worldRecordCorrect, worldRecordWrong);
		fillBar.UpdateFill(xpAmountToAdd);
		GameSettings.xpGained = xpAmountToAdd;
	}

	private void	SymbolToDisplay(int val, int cmpVal, Image yes, Image no)
	{
		if (val > cmpVal)
		{
			yes.gameObject.SetActive(true);
			if (i == 0)
				xpAmountToAdd += 400;
			else if (i == 1)
				xpAmountToAdd += 250;
			else if (i == 2)
				xpAmountToAdd += 1000;
		}
		else
			no.gameObject.SetActive(true);
		i++;
	}
}
