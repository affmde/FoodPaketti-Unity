using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
/*public class SendData : MonoBehaviour
{
	private PlayerData	playerData;
	private bool		sendData;

	private void Awake()
	{
		playerData = FindAnyObjectByType<PlayerData>();
	}

	private void Start()
	{
		StartCoroutine(Download(playerData.username, result => {
			Debug.Log(result);
		}));
		sendData = false;
	}

    IEnumerator Download(string id, System.Action<PlayerData> callback = null)
	{
		using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/plummies/" + id))
		{
			yield return (request.SendWebRequest());

			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
				if (callback != null)
				{
					callback.Invoke(null);
				}
			}
			else
			{
				if (callback != null)
				{
					callback.Invoke(PlayerData.Parse(request.downloadHandler.text));
				}
			}	
		}
	}


	IEnumerator Post(string profile, System.Action<bool> callback = null)
	{
		using (UnityWebRequest request = new UnityWebRequest("http://localhost:3000/plummies", "POST"))
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

	public void PostData()
	{
		if (!sendData)
		{
			StartCoroutine(Post(playerData.Stringify(), result => {
				Debug.Log(result);
			}));
		}
		sendData = true;
	}

	public static string Stringify()
	{
		return JsonUtility.ToJson(this);
	}

	public static PlayerData Parse(string json)
	{
		return (JsonUtility.FromJson<PlayerData>(json));
	}
}
*/