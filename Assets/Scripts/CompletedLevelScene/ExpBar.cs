using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
	[SerializeField] GameObject	continueButton;
	[SerializeField] Image		fillBar;

	int							xpToAdd;

	private void	Start()
	{
		continueButton.SetActive(false);
		xpToAdd = LevelsData.xp;
		StartCoroutine(FillXP());
	}

	private IEnumerator FillXP()
	{
		float	next;
		float	before;
		float	currXP;
		float	targetXP;
		float	i = 0;
		float	current = UserData.xp;
		float	timeToWait = 2 / 0.02f;
		float	valToIncrease = LevelsData.xp / timeToWait;

		Debug.Log("i: " + i + " xp given: " + LevelsData.xp);
		while (i < LevelsData.xp)
		{
			Debug.Log("i: " + i);
			current += valToIncrease;
			next = GameSettings.baseLevel * Mathf.Pow(UserData.level, 1.5f);
			before = GameSettings.baseLevel * Mathf.Pow(UserData.level - 1, 1.5f);
			currXP = current - before;
			targetXP = next - before;
			UserData.playerLevelProgress = currXP / targetXP;
			fillBar.fillAmount = UserData.playerLevelProgress;
			if (UserData.playerLevelProgress >= 1)
			{
				UserData.level++;
				yield return StartCoroutine(API.LevelUp());
			}
			i += valToIncrease;
			yield return (timeToWait);
		}
		UserData.xp += LevelsData.xp;
		gameObject.SetActive(false);
		continueButton.SetActive(true);
	}
}
