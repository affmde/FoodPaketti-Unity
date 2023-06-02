using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PanelManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI	description;
	[SerializeField] private TextMeshProUGUI	title;
	[SerializeField] private GameObject			descriptionPanel;
	[SerializeField] private GameObject			collectorDescriptionPanel;
	[SerializeField] private GameObject[]		fruitsToDescription;
	[SerializeField] private GameObject			loadingPanel;
	private void	Start()
	{
		loadingPanel.SetActive(false);
		if (LevelsData.type == "scorer" || LevelsData.type == "survivor")
		{
			descriptionPanel.SetActive(true);
			collectorDescriptionPanel.SetActive(false);
			description.text = API.levelsData.data[LevelsData.level - 1].description;
		}
		else if (LevelsData.type == "collector")
		{
			HandleCollectorPanel();
		}
		title.text = API.levelsData.data[LevelsData.level - 1].title;
	}
	public void	ClosePanel()
	{
		gameObject.SetActive(false);
	}

	public void	Play()
	{
		loadingPanel.SetActive(true);
		PlayerData.ResetData();
		SceneManagement.ChangeScene("LevelsGameScene", Color.black, 0.5f);
	}

	private void	HandleCollectorPanel()
	{
		descriptionPanel.SetActive(false);
		collectorDescriptionPanel.SetActive(true);
	}
}
