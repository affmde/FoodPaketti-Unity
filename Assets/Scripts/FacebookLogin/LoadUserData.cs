using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Linq;

public class LoadUserData : MonoBehaviour
{

	//private UserDataForSend[] userData;

	private IEnumerator GetUserData(string url)
		{
			yield return (SendData.FetchUserData("http://localhost:3001/users/login"));
			Debug.Log(SendData.userData.message);
		}

	private void	Start()
	{
		StartCoroutine(GetUserData("HEllo"));
	}

}
