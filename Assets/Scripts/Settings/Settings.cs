using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
	[SerializeField] GameObject		logout;
	[SerializeField] Image			On;
	[SerializeField] Image			Off;
	[SerializeField] List<AudioSource>	audioList;
	private void	Awake()
	{
		foreach(AudioSource audioS in audioList)
			SceneManagement.ToogleAudioSource(audioS);
		if (PlayerPrefs.GetInt("sound") == 0)
		{
			On.gameObject.SetActive(true);
			Off.gameObject.SetActive(false);
		}
		else
		{
			On.gameObject.SetActive(false);
			Off.gameObject.SetActive(true);
		}
	}

	private void	Start()
	{
		audioList[0].Play();
	}

	public void	Logout()
	{
		if (FB.IsLoggedIn)
		{
			audioList[1].Play();
			FB.LogOut();
			StartCoroutine("CheckFacebookLogout");
		}
		
	}

	IEnumerator CheckFacebookLogout ()
	{
		if (FB.IsLoggedIn)
		{
			yield return new WaitForSeconds(0.1f);
			StartCoroutine("CheckFacebookLogout");
		}
		else
		{
			SceneManagement.ChangeScene("RegisterLogin", Color.black, 1f);
		}
	}

	public void	ToogleSound()
	{
		audioList[1].Play();
		if (PlayerPrefs.GetInt("sound") == 0)
		{
			On.gameObject.SetActive(false);
			Off.gameObject.SetActive(true);
			PlayerPrefs.SetInt("sound", 1);
		}
		else
		{
			On.gameObject.SetActive(true);
			Off.gameObject.SetActive(false);
			PlayerPrefs.SetInt("sound", 0);
		}
	}

	public void	Return()
	{
		audioList[1].Play();
		SceneManagement.ChangeScene("StartScene", Color.black, 0.4f);
	}
}
