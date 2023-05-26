using System.Collections.Generic;
using UnityEngine;

// Other needed dependencies
using Facebook.Unity;

public class FacebookLogin : MonoBehaviour{

	public string Token;
	public string Error;

	// Awake function from Unity's MonoBehavior
	void Awake()
	{
		if (!FB.IsInitialized)
		{
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		}
		else
		{
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	void InitCallback()
	{
		if (FB.IsInitialized)
		{
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
		}
		else
		{
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		}
		else
		{
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	public void Login()
	{
		// Define the permissions
		var perms = new List<string>() { "public_profile", "email" };

		FB.LogInWithReadPermissions(perms, result =>
		{
			if (FB.IsLoggedIn)
			{
				FB.API("me?fields=name", Facebook.Unity.HttpMethod.GET, GetFacebookData);
			}
			else
			{
				Error = "User cancelled login";
				Debug.Log("[Facebook Login] User cancelled login");
			}
		});
	}

	void GetFacebookData(Facebook.Unity.IGraphResult result)
	{
		string fbName = result.ResultDictionary["name"].ToString();
		UserData.username = fbName;
		UserData.logedIn = true;
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}
}
