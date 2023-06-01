using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitInfo : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI	total;

	private void	Start()
	{
		if (gameObject.name == "Parsimmons")
			total.text = PlayerPrefs.GetInt("parsimmons").ToString();
		else if (gameObject.name == "watermelons")
			total.text = PlayerPrefs.GetInt("watermelons").ToString();
	}
}
