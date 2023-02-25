using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneManagement
{
	public static void ChangeScene(string scene, Color color, float duration)
	{
		Initiate.Fade(scene, color, duration);
	}
}
