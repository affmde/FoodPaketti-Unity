using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Linq;

public static class SendData
{
	public static PlayerData[] loadedData;

	public static IEnumerator FetchData()
	{
		using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3001/save/getHighscores"))
		{
			yield return (request.SendWebRequest());

			if (request.result == UnityWebRequest.Result.ConnectionError)
				Debug.Log(request.error);
			else
			{
				string jsonString = fixJson(request.downloadHandler.text);
				loadedData = JsonHelper.FromJson<PlayerData>(jsonString);
			}	
		}
	}
	/*public static IEnumerator Post(string profile)
	{
		using UnityWebRequest request = new UnityWebRequest("http://localhost:3001/save","POST");
		var bodyRaw = Encoding.UTF8.GetBytes(profile);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader(name: "Content-Type", value: "application/json");
        yield return request.SendWebRequest();
        
		if (request.result == UnityWebRequest.Result.Success)
			Debug.Log(request.downloadHandler.text);
		else
			Debug.Log(request.error);
	}*/

	public static IEnumerator Post(PlayerData data)
	{
		Debug.Log("player data: " + data.username + data.score + data.duration + data.apples + data.bananas + data.oranges);
		WWWForm form = new WWWForm();
		form.AddField("username", data.username);
		form.AddField("score", data.score);
		form.AddField("apples", data.apples);
		form.AddField("bananas", data.bananas);
		form.AddField("oranges", data.oranges);
		form.AddField("duration", Mathf.FloorToInt(data.duration));
		Debug.Log(form.data);


		var download= UnityWebRequest.Post("http://localhost:3001/save", form);
		yield return download.SendWebRequest();
		if (download.result != UnityWebRequest.Result.Success)
            Debug.Log( "Error downloading: " + download.error );
        else
            Debug.Log(download.downloadHandler.text);

			
		/*using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3001/save", form))
		{
			yield return request.SendWebRequest();
			if (request.result != UnityWebRequest.Result.Success)
				Debug.Log("error: " + request.error);
			else
			{
				string results = request.downloadHandler.text;
				Debug.Log(results);
			}
		}*/
	}

	public static string Stringify(PlayerData playerInfo)
	{
		playerInfo.duration = Mathf.FloorToInt(playerInfo.duration);
		return JsonUtility.ToJson(playerInfo);
	}

	static string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}
}