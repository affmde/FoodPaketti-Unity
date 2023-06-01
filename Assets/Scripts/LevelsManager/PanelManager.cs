using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PanelManager : MonoBehaviour
{
	private TextMeshProUGUI	description;
	private TextMeshProUGUI	title;

	public void	ClosePanel()
	{
		gameObject.SetActive(false);
	}
}
