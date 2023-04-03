using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHighscoreMode : MonoBehaviour
{
	public void	Play()
	{
		PlayerPrefs.SetInt("isLoggedIn", 0);
		SceneManagement.ChangeScene("SampleScene", Color.black, 1f);
	}
}
