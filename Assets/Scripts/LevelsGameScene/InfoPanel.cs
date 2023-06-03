using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InfoPanel : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI	points;
	private string						type;
	[SerializeField] GameObject			scorerSurviverPanel;
	[SerializeField] GameObject			collectorPanel;
	int	requiredPoints;

	private void	Start()
	{
		type = LevelsData.type;
		if (type == "scorer" || type == "survivor")
		{
			collectorPanel.SetActive(false);
			scorerSurviverPanel.SetActive(true);
			if (type == "scorer")
				requiredPoints = LevelsData.scorer;
			else
				requiredPoints = LevelsData.survivor;
		}
		else if (type == "collector")
		{
			collectorPanel.SetActive(true);
			scorerSurviverPanel.SetActive(false);
		}
	}

	private void	Update()
	{
		if (type == "scorer")
			points.text = PlayerPrefs.GetInt("score").ToString() + "/" + requiredPoints.ToString() + " Points";
		else if (type == "survivor")
		{
			points.text = Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")).ToString() + "/" + requiredPoints.ToString() + " seconds";
		}
	}
}
