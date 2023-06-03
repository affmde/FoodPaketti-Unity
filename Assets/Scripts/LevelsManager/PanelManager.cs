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
	[SerializeField] private AudioSource		buttonClick;
	private void	Start()
	{
		SceneManagement.ToogleAudioSource(buttonClick);
		loadingPanel.SetActive(false);
		if (LevelsData.type == "scorer" || LevelsData.type == "survivor")
		{
			descriptionPanel.SetActive(true);
			collectorDescriptionPanel.SetActive(false);
			description.text = LevelsData.description;
		}
		else if (LevelsData.type == "collector")
		{
			HandleCollectorPanel();
		}
		title.text = LevelsData.title;
	}
	public void	ClosePanel()
	{
		buttonClick.Play();
		gameObject.SetActive(false);
	}

	public void	Play()
	{
		buttonClick.Play();
		GameSettings.gameType = "levelGame";
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
