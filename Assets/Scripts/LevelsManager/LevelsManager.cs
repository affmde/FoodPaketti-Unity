using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class LevelsManager : MonoBehaviour
{
	[SerializeField] private bool	unlocked;
	[SerializeField] private int	level;
	[SerializeField] private bool	completed;
	public Image					unlockImage;
	public Image					completedImage;
	private GameObject				levelInfoPanel;


	private void	Awake()
	{
		levelInfoPanel = GameObject.FindWithTag("LevelInfoPanel");
	}

	private void	Start()
	{
		levelInfoPanel.SetActive(false);
		level = int.Parse(gameObject.name);
		Debug.Log("name: " + gameObject.name);
		if (UserData.completedLevels.Contains(int.Parse(gameObject.name)))
			completed = true;
		if (UserData.completedLevels.Contains(level) || (UserData.completedLevels.Length == 0 && level == 1))
		{
			Debug.Log("Detected First level here. SHould unlock");
			unlocked = true;
		}
		UpdateLevelImage();
	}

	private void	UpdateLevelImage()
	{
		if (!unlocked){
			unlockImage.gameObject.SetActive(true);
			completedImage.gameObject.SetActive(false);
			Debug.Log("Unlock false");
		}
		else if (unlocked && !completed)
		{
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(false);
		}
		else
		{
			Debug.Log("Unlock true");
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(true);
		}
	}

	public void	PressLevel()
	{
		if (unlocked && !completed)
		{
			levelInfoPanel.SetActive(true);
		}
	}

	public void	Return()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
