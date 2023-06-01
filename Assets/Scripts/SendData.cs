using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class SendData
{
	public static DataForSend[] loadedData;
	public static IEnumerator FetchData()
	{
		using (UnityWebRequest request = UnityWebRequest.Get("https://foodpaketti.monster/save/getHighscores"))
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

	public static IEnumerator Post()
	{
		Debug.Log("Posting highscore");
		WWWForm form = new WWWForm();
		form.AddField("username", UserData.username);
		form.AddField("score", PlayerPrefs.GetInt("score"));
		form.AddField("apples", PlayerPrefs.GetInt("apples"));
		form.AddField("bananas", PlayerPrefs.GetInt("bananas"));
		form.AddField("oranges", PlayerPrefs.GetInt("oranges"));
		form.AddField("duration", Mathf.FloorToInt(PlayerPrefs.GetFloat("duration")));

		var download= UnityWebRequest.Post("https://foodpaketti.monster/save", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
			Debug.Log( "Error downloading: " + download.error );
		else
			Debug.Log(download.downloadHandler.text);
		Debug.Log("HighScore posted finished");
	}


	public static string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}
}