using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInputField : MonoBehaviour
{
	string input;
	public void ReadInputString(string str)
	{
		input = str;
		Debug.Log("input: " + input);
	}
}
