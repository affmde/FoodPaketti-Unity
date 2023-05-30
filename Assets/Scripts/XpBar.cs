using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpBar : MonoBehaviour
{
	[SerializeField] Image				fillBar;
	[SerializeField] TextMeshProUGUI	level;
	private void	Start()
	{
		float	next = GameSettings.baseLevel * Mathf.Pow(UserData.level, 1.5f);
		float	before = (GameSettings.baseLevel) * Mathf.Pow(UserData.level - 1, 1.5f);
		float	currXP = (UserData.xp - before);
		float	targetXP = next - before;
		UserData.playerLevelProgress = currXP / targetXP;
		fillBar.fillAmount = UserData.playerLevelProgress;
		level.text = UserData.level.ToString();

		Debug.Log("before: " + before);
		Debug.Log("next: " + next);
		Debug.Log("Current: " + currXP);
		Debug.Log("Target: " + targetXP);
	}
}
