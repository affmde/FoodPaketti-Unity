using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HandleSignUp : MonoBehaviour
{
	[SerializeField] List<TMP_InputField> inputList;
	private bool[] isChecked = {false, false, false, false, false};
	[SerializeField] Image errorArea;
	[SerializeField] TextMeshProUGUI errorMessage;
	[SerializeField] GameObject panel;

	private void Start()
	{
		errorArea.gameObject.SetActive(false);
	}
	private bool isReadyToConfirm()
	{
		if (!CheckPasswords())
			return (false);
		for (int i = 0; i < isChecked.Length; i++)
		{
			if (isChecked[i] == false)
			{
				errorMessage.text = inputList[i].name + " is required";
				return (false);
			}
		}
		return (true);
	}

	private void checkInputs()
	{
		for(int i = 0; i < inputList.Count; i++)
		{
			if (inputList[i].text.Length > 0)
				isChecked[i] = true;
			else
				isChecked[i] = false;
		}
	}

	private bool CheckPasswords()
	{
		if (inputList[1].text == inputList[2].text)
			return (true);
		errorMessage.text = "Passwords do not match";
		return (false);
	}

	public void RegisterUser()
	{
		checkInputs();
		if (!isReadyToConfirm())
		{
			errorArea.gameObject.SetActive(true);
			return ;
		}
		errorArea.gameObject.SetActive(false);
		StartCoroutine(Register());
	}

	private IEnumerator Register()
	{
		yield return (StartCoroutine(API.RegisterUserToDatabase(inputList[0].text, inputList[1].text, inputList[3].text, inputList[4].text)));
		if (LoginDataManager.userCreatedSuccessfully)
		{
			panel.SetActive(false);
		}
		else
		{
			errorArea.gameObject.SetActive(true);
			errorMessage.text = LoginDataManager.errorMessage;
		}
	}
}
