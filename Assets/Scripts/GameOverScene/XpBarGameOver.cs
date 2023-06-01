using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBarGameOver : MonoBehaviour
{
	[SerializeField] Image fillBar;
	private HandleStatsShow handleBar;
	[SerializeField] private List<AudioSource> audioList;
	
	private void	Awake()
	{
		handleBar = GameObject.FindAnyObjectByType<HandleStatsShow>();
		foreach(AudioSource audioS in audioList)
			SceneManagement.ToogleAudioSource(audioS);
	}


	public IEnumerator AddExperience(int amount)
	{
		float	currXP;
		float	targetXP;
		float	next;
		float	before;

		for (int i = 0; i < amount; i++)
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
				audioList[0].Play();
				UserData.level++;
				StartCoroutine(API.LevelUp());
			}
			if (amount > 75)
				yield return new WaitForSeconds(2f / amount);
			else
				yield return (0.02f);
		}
		handleBar.continueButton.SetActive(true);
		handleBar.experienceBar.SetActive(false);
	}

	public void	UpdateFill(int xp)
	{
		StartCoroutine(AddExperience(xp));
	}
}
