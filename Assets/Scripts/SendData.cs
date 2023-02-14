using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Linq;

public class SendData : MonoBehaviour
{
	private string username;
	private PlayerData playerData;
	public PlayerData[] loadedData;
	private void Awake()
	{
		playerData = new PlayerData();
	}

	private void Start()
	{
		
	}

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

	public void GetData()
	{
		StartCoroutine(FetchData());
	}

	public static List<T> ReadFromJson<T> (string json)
	{
		if (string.IsNullOrEmpty(json) || json == "{}")
			return (new List<T>());
		
		List<T> res = JsonHelper.FromJson<T>(json).ToList();
		return (res);
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

	/*public void PostData()
	{
		if (!sendData)
		{
			StartCoroutine(Post(Stringify(), result => {
				Debug.Log(result);
			}));
		}
		sendData = true;
	}*/

	/*public static string Stringify()
	{
		return JsonUtility.ToJson(this);
	}*/

	public static PlayerData Parse(string json)
	{
		return (JsonUtility.FromJson<PlayerData>(json));
	}

	string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}
}