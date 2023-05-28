using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
	[SerializeField] GameObject	logout;
	[SerializeField] Image		On;
	[SerializeField] Image		Off;

	private AudioSource[] allAudioSources;
	private void	Awake()
	{
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
	}
	public void	Logout()
	{
		if (FB.IsLoggedIn)
		{
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
		SceneManagement.ChangeScene("StartScene", Color.black, 0.4f);
	}
}
