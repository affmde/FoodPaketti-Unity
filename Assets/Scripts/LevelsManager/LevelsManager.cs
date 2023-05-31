using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class LevelsManager : MonoBehaviour
{
	[SerializeField] private bool	unlocked;
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
		Debug.Log("name: " + gameObject.name);
		if (UserData.completedLevels.Contains(int.Parse(gameObject.name)))
		{
			Debug.Log("Parsing -> unlock true");
			unlocked = true;
		}
		else
		{
			Debug.Log("Parsing -> unlock false");
			unlocked = false;
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
		else
		{
			Debug.Log("Unlock true");
			unlockImage.gameObject.SetActive(false);
			completedImage.gameObject.SetActive(true);
		}
	}

	public void	PressLevel()
	{
		if (!unlocked)
		{
			levelInfoPanel.SetActive(true);
		}
	}

	public void	Return()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
