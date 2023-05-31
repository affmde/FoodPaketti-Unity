using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUsername : MonoBehaviour
{
	private string	username;
	[SerializeField] GameObject			menu;
	[SerializeField] GameObject			panel;

	public void	ReadInput(string s)
	{
		username = s;
	}

	public void	SaveUsername()
	{
		PlayerPrefs.SetString("username", username);
		UserData.username = username;
		panel.SetActive(false);
		menu.SetActive(true);
	}
}
