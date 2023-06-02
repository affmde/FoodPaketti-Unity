using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
	[SerializeField] GameObject		loadingPanel;

	private void	Awake()
	{
		StartCoroutine(LoadLevels());
	}
	private IEnumerator LoadLevels()
	{
		yield return (API.GetLevels());
		loadingPanel.SetActive(false);
	}
}
