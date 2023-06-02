using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FruitDescriptionHandler : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI	text;

	private void	Start()
	{
		Debug.Log("LevelsData.level: " + LevelsData.level);
		CollectorWinningCondition data = API.levelsData.data[LevelsData.level].collector;
		if (gameObject.name == "Apple")
		{
			if (data.apples < 1)
				gameObject.SetActive(false);
			else
				text.text = data.apples.ToString();
		}
		else if (gameObject.name == "Orange")
		{
			if (data.oranges < 1)
				gameObject.SetActive(false);
			else
				text.text = data.oranges.ToString();
		}
		else if (gameObject.name == "Banana")
		{
			if (data.bananas < 1)
				gameObject.SetActive(false);
			else
				text.text = data.bananas.ToString();
		}
		else if (gameObject.name == "Parsimmon")
		{
			if (data.parsimmons < 1)
				gameObject.SetActive(false);
			else
				text.text = data.parsimmons.ToString();
		}
		else if (gameObject.name == "Watermelon")
		{
			if (data.watermelons < 1)
				gameObject.SetActive(false);
			else
				text.text = data.watermelons.ToString();
		}
	}
}
