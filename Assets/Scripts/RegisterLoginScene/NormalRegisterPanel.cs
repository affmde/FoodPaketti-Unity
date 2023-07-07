using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRegisterPanel : MonoBehaviour
{
	[SerializeField] GameObject panel;

	private void Start()
	{
		panel.SetActive(false);
	}
	public void OpenPanel()
	{
		panel.SetActive(true);
	}

	public void ClosePanel()
	{
		panel.SetActive(false);
	}
}
