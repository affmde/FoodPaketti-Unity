using System.Collections.Generic;
using UnityEngine;

// Other needed dependencies
using Facebook.Unity;

public class FacebookLogin : MonoBehaviour{

	[SerializeField] GameObject registerScreen;
	[SerializeField] GameObject loadingScreen;
	private void Awake()
	{
		registerScreen.SetActive(false);
		loadingScreen.SetActive(true);
		if (!FB.IsInitialized) {
        	// Initialize the Facebook SDK
       		FB.Init(SetInit, onHidenUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
			if (FB.IsLoggedIn)
			{
				Debug.Log("Facebook is Login!");
			}
			else
			{
				Debug.Log("Facebook is not Logged in!");
				loadingScreen.SetActive(false);
				registerScreen.SetActive(true);
			}
			DealWithFbMenus(FB.IsLoggedIn);
			}
	}
	void SetInit()
	{
		if (FB.IsLoggedIn)
		{
			Debug.Log("Facebook is Login!");
		}
		else
		{
			Debug.Log("Facebook is not Logged in!");
		}
		DealWithFbMenus(FB.IsLoggedIn);
	}

	void onHidenUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
	public void FBLogin()
	{
		List<string> permissions = new List<string>();
		permissions.Add("public_profile");
		FB.LogInWithReadPermissions(permissions, AuthCallBack);
	}
	// Start is called before the first frame update
	void AuthCallBack(IResult result)
	{
		if (result.Error != null)
		{
			Debug.Log(result.Error);
		}
		else
		{
			if (FB.IsLoggedIn)
			{
				Debug.Log("Facebook is Login!");
				// Panel_Add.SetActive(true);
			}
			else
			{
				Debug.Log("Facebook is not Logged in!");
			}
			DealWithFbMenus(FB.IsLoggedIn);
		}
	}

	void DealWithFbMenus(bool isLoggedIn)
	{
		if (isLoggedIn)
		{
			FB.API("/me?fields=first_name",HttpMethod.GET,DisplayUsername);
			FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		}
		else
		{
			loadingScreen.SetActive(false);
			registerScreen.SetActive(true);
		}
	}
	void DisplayUsername(IResult result)
	{
		if (result.Error == null)
		{
			string name = ""+result.ResultDictionary["first_name"];
			UserData.username = name;
		
			Debug.Log(""+name);
		}
		else
		{
			Debug.Log(result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result)
	{
		if (result.Texture != null)
		{
			Debug.Log("Profile Pic");
			// FB_useerDp.sprite = Sprite.Create(result.Texture,new Rect(0,0,128,128),new Vector2());
		}
		else
		{
			Debug.Log(result.Error);
		}
	}
}
