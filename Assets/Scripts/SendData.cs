using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Linq;

public static class SendData
{
	public static DataForSend[] loadedData;
	public static UserDataForSend userData;
	public static IEnumerator FetchData(string url)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(url))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string jsonString = fixJson(request.downloadHandler.text);
				loadedData = JsonHelper.FromJson<DataForSend>(jsonString);
			}	
		}
	}

	public static IEnumerator FetchUserData(string url)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(url))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string jsonString = fixJson(request.downloadHandler.text);
				userData = JsonUtility.FromJson<UserDataForSend>(jsonString);
			}	
		}
	}

	public static IEnumerator Post()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", PlayerPrefs.GetString("username"));
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));
		form.AddField("totalFruits", PlayerPrefs.GetInt("totalFruits"));

		var download= UnityWebRequest.Post("https://foodpaketti.monster/save", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
            Debug.Log( "Error downloading: " + download.error );
        else
            Debug.Log(download.downloadHandler.text);
	}

	//Create User
	public static IEnumerator RegisterUSer()
	{
		Debug.Log("Start process o creating user");
		WWWForm form = new WWWForm();
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("name", UserData.name);
		form.AddField("email", UserData.email);

		var download= UnityWebRequest.Post("http://localhost:3001/users/addUser", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
		{
			Debug.Log( "Error downloading: " + download.error );
			string message = JsonUtility.FromJson<UserDataForSend>(download.downloadHandler.text).message;
			Debug.Log("message: " + message);	
		}
        else
        {
			Debug.Log("User registered successfully");
			Debug.Log("result: " + download.downloadHandler.text);
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		}
	}

	//User Login
	public static IEnumerator PostUserLogin()
	{
		WWWForm form = new WWWForm();
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("name", UserData.name);
		form.AddField("email", UserData.email);

		var download= UnityWebRequest.Post("http://localhost:3001/users/login", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
		{
			Debug.Log( "Error downloading: " + download.error );
			Debug.Log("Please register first with facebook");
			//RegisterUSer();
		}
        else
        {
			Debug.Log("User log in. ready to json");
			string jsonString = download.downloadHandler.text;
			UserData.jsonUserDataString =  jsonString;
			SceneManagement.ChangeScene("StartScene", Color.black, 1f);
		}
	}

	//Save Data after play Highscore game
	public static IEnumerator SaveHighscoreGame(int xp)
	{
		WWWForm form = new WWWForm();
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("username", UserData.name);
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("totalFruits", PlayerPrefs.GetInt("totalFruits"));
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));
		form.AddField("xp", xp);

		var download= UnityWebRequest.Post("http://localhost:3001/users/highscoregame", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
            Debug.Log( "Error downloading: " + download.error );
        else
            Debug.Log(download.downloadHandler.text);
	}




	static string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}
}
