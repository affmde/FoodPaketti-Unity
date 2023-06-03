using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CollectorTopPanel : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI	text;
	[SerializeField] Image				completedImage;
	private int							requiredFruit;
	private int							currentFruit;

	private void	Start()
	{
		completedImage.gameObject.SetActive(false);
	}
	private void	Update()
	{
		CollectorWinningCondition data = LevelsData.collector;
		if (gameObject.name == "Apple")
		{
			if (data.apples < 1)
				gameObject.SetActive(false);
			else
			{
				requiredFruit = data.apples;
				currentFruit = PlayerPrefs.GetInt("apples");
				text.text = currentFruit + "/" + requiredFruit;
			}
		}
		else if (gameObject.name == "Orange")
		{
			if (data.oranges < 1)
				gameObject.SetActive(false);
			else
			{
				requiredFruit = data.oranges;
				currentFruit = PlayerPrefs.GetInt("oranges");
				text.text = currentFruit + "/" + requiredFruit;
			}
		}
		else if (gameObject.name == "Banana")
		{
			if (data.bananas < 1)
				gameObject.SetActive(false);
			else
			{
				requiredFruit = data.bananas;
				currentFruit = PlayerPrefs.GetInt("bananas");
				text.text = currentFruit + "/" + requiredFruit;
			}
		}
		else if (gameObject.name == "Parsimmon")
		{
			if (data.parsimmons < 1)
				gameObject.SetActive(false);
			else
			{
				requiredFruit = data.parsimmons;
				currentFruit = PlayerPrefs.GetInt("parsimmons");
				text.text = currentFruit + "/" + requiredFruit;
			}
		}
		else if (gameObject.name == "Watermelon")
		{
			if (data.watermelons < 1)
				gameObject.SetActive(false);
			else
			{
				requiredFruit = data.watermelons;
				currentFruit = PlayerPrefs.GetInt("watermelons");
				text.text = currentFruit + "/" + requiredFruit;
			}
		}
		if (gameObject.activeInHierarchy && currentFruit >= requiredFruit)
		{
			completedImage.gameObject.SetActive(true);
			text.gameObject.SetActive(false);
		}
	}
}
