using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginUser : MonoBehaviour
{
	[SerializeField] Image errorArea;
	[SerializeField] TextMeshProUGUI errorMessage;
	[SerializeField] GameObject loading;

	private void Start()
	{
		errorArea.gameObject.SetActive(false);
	}
	public void HandleUserLogin()
	{
		StartCoroutine(Login());
	}

	private IEnumerator Login()
	{
		loading.gameObject.SetActive(true);
		yield return StartCoroutine(API.UserLogin());
		if (LoginDataManager.userLoggedSuccessfully == false)
		{
			errorArea.gameObject.SetActive(true);
			errorMessage.text = LoginDataManager.errorMessage;
			loading.gameObject.SetActive(false);
		}
		else
		{
			errorArea.gameObject.SetActive(false);
			PlayerPrefs.SetString("username", LoginDataManager.username);
			PlayerPrefs.SetInt("registerMode", 0);
			PlayerPrefs.SetInt("login", 1);
			loading.gameObject.SetActive(false);
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		}
	}
}
