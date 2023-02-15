using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Linq;

public class SendData : MonoBehaviour
{
	public PlayerData[] loadedData;

	public IEnumerator FetchData()
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

	public IEnumerator Post(string profile, System.Action<bool> callback = null)
	{
		using (UnityWebRequest request = new UnityWebRequest("http://localhost:3001/save/", "POST"))
		{
			request.SetRequestHeader("Content-Type", "application/json");
			byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
			request.uploadHandler = new UploadHandlerRaw(bodyRaw);
			request.downloadHandler = new DownloadHandlerBuffer();
			yield return (request.SendWebRequest());

			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
				if (callback != null)
					callback.Invoke(false);
			}
			else
			{
				if (callback != null)
					callback.Invoke(request.downloadHandler.text != "{}");
			}
		}
	}

	public void PostData(PlayerData playerInfo)
	{
		string jsonString = Stringify(playerInfo);
		Debug.Log(jsonString);
		/*StartCoroutine(Post(jsonString, result => {
			Debug.Log(result);
		}));*/
	}

	public static string Stringify(PlayerData playerInfo)
	{
		return JsonUtility.ToJson(playerInfo);
	}

	string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}
}