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

		Debug.Log("Filling the button");
		for (int i = 0; i < LevelsData.xp; i++)
		{
			UserData.xp++;
			next = GameSettings.baseLevel * Mathf.Pow(UserData.level, 1.5f);
			before = GameSettings.baseLevel * Mathf.Pow(UserData.level - 1, 1.5f);
			currXP = UserData.xp - before;
			targetXP = next - before;
			UserData.playerLevelProgress = currXP / targetXP;
			fillBar.fillAmount = UserData.playerLevelProgress;
			if (UserData.playerLevelProgress >= 1)
			{
				UserData.level++;
				yield return StartCoroutine(API.LevelUp());
			}
			yield return (0.02f);
		}
		continueButton.SetActive(true);
	}
}
