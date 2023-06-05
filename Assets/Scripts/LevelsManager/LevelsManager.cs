using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class LevelsManager : MonoBehaviour
{
	[SerializeField] private bool		unlocked;
	[SerializeField] private int		level;
	[SerializeField] private bool		completed;
	public Image						unlockImage;
	public Image						completedImage;
	private GameObject					levelInfoPanel;
	[SerializeField] TextMeshProUGUI	levelText;
	[SerializeField] AudioSource		buttonClick;
	private void	Awake()
	{
		levelInfoPanel = GameObject.FindWithTag("LevelInfoPanel");
	}

	private void	Start()
	{
		SceneManagement.ToogleAudioSource(buttonClick);
		levelInfoPanel.SetActive(false);
		level = int.Parse(gameObject.name);
		levelText.text = gameObject.name;
		if (UserData.completedLevels.Contains(int.Parse(gameObject.name)))
			completed = true;
		if (UserData.completedLevels.Contains(level - 1))
			unlocked = true;
		if (UserData.completedLevels.Contains(level) || (UserData.completedLevels.Count == 0 && level == 1))
			unlocked = true;
		if (level == 1)
		{
			unlockImage.gameObject.SetActive(false);
			unlocked = true;
		}
		UpdateLevelImage();
	}

	private void	UpdateLevelImage()
	{
		if (!unlocked){
			unlockImage.gameObject.SetActive(true);
			completedImage.gameObject.SetActive(false);
		}
		else if (unlocked && !completed)
		{
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(false);
		}
		else
		{
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(true);
		}
	}

	public void	PressLevel()
	{
		if (unlocked && !completed)
		{
			buttonClick.Play();
			levelInfoPanel.SetActive(true);
		}
	}
}
