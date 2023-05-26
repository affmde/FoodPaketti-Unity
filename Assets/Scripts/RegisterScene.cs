using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterScene : MonoBehaviour
{
	public void Play()
	{
		UserData.logedIn = false;
		SceneManagement.ChangeScene("SampleScene", Color.black, 1f);
	}
}
