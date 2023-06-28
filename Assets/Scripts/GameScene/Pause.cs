using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField] private GameObject	pausePanel;

	private void	Start()
	{
		pausePanel.SetActive(false);
	}
	public void	PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		gameObject.SetActive(false);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		gameObject.SetActive(true);
	}
}
