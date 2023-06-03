using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Other dependencies
using UnityEngine.Networking;

public static class API
{
	public static PersonalHighscoresDataAPI	personalHighscoreData;
	public static TopUserDataAPI			topUsersData;
	public static LevelsDataForAPI			levelsData;
	public static IEnumerator AddUserToDatabase()
	{
		WWWForm form = new WWWForm();
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
			Debug.Log(download.downloadHandler.text);
			UserData.userDataJson = download.downloadHandler.text;
			DataParser.UserDataParser();
		}
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
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
		form.AddField("parsimmons", PlayerPrefs.GetInt("parsimmons"));
		form.AddField("watermelons", PlayerPrefs.GetInt("watermelons"));
		form.AddField("level", UserData.level);
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


	public static IEnumerator GetWorldRecord()
	{
		using (UnityWebRequest request = UnityWebRequest.Get("https://foodpaketti.monster/save/getWorldRecord"))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string json = request.downloadHandler.text;
				DataForSend loadedData = JsonUtility.FromJson<DataForSend>(json);
				Debug.Log("loaded data: " + loadedData);
				GameSettings.worldRecord = loadedData.score;
				Debug.Log("record: " + GameSettings.worldRecord);
			}
		}
	}


	public static IEnumerator LevelUp()
	{
		Debug.Log("Start the Level Up request on Unity");
		WWWForm form = new WWWForm();
		string username = UserData.username;
		form.AddField("username", username);
		string	facebookId = UserData.facebookId;
		form.AddField("facebookId", facebookId);

		var download= UnityWebRequest.Post("https://foodpaketti.monster/users/levelUp", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error downloading: " + download.error );
		else
		{
			Debug.Log("Level up saved Successfuly");
			Debug.Log(download.downloadHandler.text);
		}
	}


	public static IEnumerator GetUserHighscores()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("facebookId", UserData.facebookId);
		var download= UnityWebRequest.Post("https://foodpaketti.monster/users/getUserHeighScores", form);
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
			string json = download.downloadHandler.text;
			personalHighscoreData = JsonUtility.FromJson<PersonalHighscoresDataAPI>(json);
		}
	}


	public static IEnumerator GetTopUsers()
	{
		using (UnityWebRequest request = UnityWebRequest.Get("https://foodpaketti.monster/users/topUsers"))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string json = request.downloadHandler.text;
				topUsersData = JsonUtility.FromJson<TopUserDataAPI>(json);
			}
		}
	}

	public static IEnumerator GetLevels()
	{
		using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3001/levels/getLevels"))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string json = request.downloadHandler.text;
				Debug.Log(json);
				levelsData= JsonUtility.FromJson<LevelsDataForAPI>(json);
			}
		}
	}

	public static IEnumerator SaveCompletedLevel()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("parsimmons", PlayerPrefs.GetInt("parsimmons"));
		form.AddField("watermelons", PlayerPrefs.GetInt("watermelons"));
		form.AddField("level", UserData.level);
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));
		form.AddField("xp", LevelsData.xp);
		form.AddField("levelCompleted", LevelsData.level + 1);
		form.AddField("totalFruits", PlayerPrefs.GetInt("totalFruits"));
		var download= UnityWebRequest.Post("http://localhost:3001/users/levelCompleted", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error saving downloading: " + download.error );
		else
			Debug.Log(download.downloadHandler.text);
	}

	public static IEnumerator SaveLevelGame()
	{
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("facebookId", UserData.facebookId);
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("parsimmons", PlayerPrefs.GetInt("parsimmons"));
		form.AddField("watermelons", PlayerPrefs.GetInt("watermelons"));
		form.AddField("level", UserData.level);
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));
		form.AddField("xp", 0);
		form.AddField("totalFruits", PlayerPrefs.GetInt("totalFruits"));
		var download= UnityWebRequest.Post("http://localhost:3001/users/saveLevelGame", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error saving downloading: " + download.error );
		else
			Debug.Log(download.downloadHandler.text);
	}
}
