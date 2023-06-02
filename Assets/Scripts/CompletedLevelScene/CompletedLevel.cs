using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
	public void	Continue()
	{
		StartCoroutine(SaveLevel());
	}

	private IEnumerator SaveLevel()
	{
		yield return (API.SaveCompletedLevel());
		PlayerData.ResetData();
		UserData.completedLevels.Add(LevelsData.level);
		SceneManagement.ChangeScene("LevelsManagerScene", Color.black, 0.5f);
	}
}
