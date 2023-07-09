using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInputField : MonoBehaviour
{
	[SerializeField] private string idName;
	public void ReadInputString(string str)
	{
		if (idName == "Username")
			LoginDataManager.username = str;
		else if (idName == "Password")
			LoginDataManager.password = str;
	}
}
