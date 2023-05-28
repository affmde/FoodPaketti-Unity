using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
public class Settings : MonoBehaviour
{
	[SerializeField] GameObject	logout;
	[SerializeField] GameObject	sound;

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

	public void	Return()
	{
		SceneManagement.ChangeScene("StartScene", Color.black, 0.4f);
	}
}
