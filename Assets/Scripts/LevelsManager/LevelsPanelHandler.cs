using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LevelsPanelHandler : MonoBehaviour
{
	[SerializeField] List<GameObject>	panelList;
	private int							activePanel;
	[SerializeField] Image				beforeButton;
	[SerializeField] Image				nextButton;


	private void	Start()
	{
		activePanel = (UserData.completedLevels.Max()) / 13;
		int i = 0;
		foreach (GameObject panel in panelList)
		{
			if (i == activePanel)
				panel.SetActive(true);
			else
				panel.SetActive(false);
			i++;
		}
		if (activePanel == 0)
			beforeButton.gameObject.SetActive(false);
		else if (activePanel == panelList.Count - 1)
			nextButton.gameObject.SetActive(false);
	}


	public void	NextPanel()
	{
		panelList[activePanel].SetActive(false);
		activePanel++;
		panelList[activePanel].SetActive(true);
		if (activePanel >= panelList.Count - 1)
		{
			nextButton.gameObject.SetActive(false);
			activePanel = panelList.Count - 1;
		}
		if (beforeButton.gameObject.activeSelf == false)
			beforeButton.gameObject.SetActive(true);
	}


	public void	BeforePanel()
	{
		panelList[activePanel].SetActive(false);
		activePanel--;
		panelList[activePanel].SetActive(true);
		if (activePanel <= 0)
		{
			beforeButton.gameObject.SetActive(false);
			activePanel = 0;
		}
		if (nextButton.gameObject.activeInHierarchy == false)
			nextButton.gameObject.SetActive(true);
	}
}
