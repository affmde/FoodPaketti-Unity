using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Other dependencies
using UnityEngine.Networking;

public static class API
{
	public static IEnumerator AddUserToDatabase()
	{
		Debug.Log("STart the Unity POST");
		WWWForm form = new WWWForm();
		Debug.Log("userdata.username: " + UserData.username);
		string username = UserData.username;
		form.AddField("username", username);
		string	facebookId = UserData.facebookId;
		form.AddField("facebookId", facebookId);

		var download= UnityWebRequest.Post("https://foodpaketti.monster/users/addUser", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error downloading: " + download.error );
		else
		{
			Debug.Log("Logged in successfully. Ready to parse data");
			Debug.Log(download.downloadHandler.text);
			UserData.userDataJson = download.downloadHandler.text;
			DataParser.UserDataParser();
		}
	}


	public static IEnumerator SaveGameData(int xp)
	{
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));
		form.AddField("xp", xp);
		form.AddField("totalFruits", PlayerPrefs.GetInt("totalFruits"));
		var download= UnityWebRequest.Post("https://foodpaketti.monster/users/highscoregame", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error saving downloading: " + download.error );
		else
			Debug.Log(download.downloadHandler.text);
	}


	public static IEnumerator GetUserData()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("facebookId", UserData.facebookId);
		var download= UnityWebRequest.Post("https://foodpaketti.monster/users/getUserInfo", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
		{
			Debug.Log("GetUserDataSucess");
			Debug.Log( "Error downloading: " + download.error );
		}
		else
		{
			Debug.Log("Get user data results in: ");
			Debug.Log(download.downloadHandler.text);
			UserData.userDataJson = download.downloadHandler.text;
			DataParser.UserDataParser();
		}
	}
}
