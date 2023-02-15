using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneManagement
{
	public static void ChangeScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
