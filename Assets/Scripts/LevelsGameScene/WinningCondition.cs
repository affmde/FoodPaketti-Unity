using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningCondition : MonoBehaviour
{
	private string type;
	[SerializeField] ParticleSystem	winningParticle;
	[SerializeField] AudioSource	winningSound;
	private bool					particlePlaying;
	private void	Start()
	{
		SceneManagement.ToogleAudioSource(winningSound);
		type = LevelsData.type;
		GameSettings.levelCompleted = false;
	}

	private void	Update()
	{
		PlayerPrefs.SetFloat("duration", PlayerPrefs.GetFloat("duration") + Time.deltaTime);
		if (type == "scorer")
		{
			if (PlayerPrefs.GetInt("score") >= LevelsData.scorer)
			{
				PlayParticle();
				GameSettings.levelCompleted = true;
			}
		}
		else if (type == "survivor")
		{
			if (PlayerPrefs.GetFloat("duration") >= LevelsData.survivor)
			{
				PlayParticle();
				GameSettings.levelCompleted = true;
			}
		}
		else if (type == "collector")
		{
			if (PlayerPrefs.GetInt("apples") >= LevelsData.collector.apples && 
				PlayerPrefs.GetInt("oranges") >= LevelsData.collector.oranges &&
				PlayerPrefs.GetInt("bananas") >= LevelsData.collector.bananas &&
				PlayerPrefs.GetInt("parsimmons") >= LevelsData.collector.parsimmons &&
				PlayerPrefs.GetInt("watermelon") >= LevelsData.collector.watermelons)
			{
				GameSettings.levelCompleted = true;
				PlayParticle();
			}

		}
		if (GameSettings.levelCompleted)
			ChangeScene();
	}


	private void	ChangeScene()
	{
		GameSettings.levelCompleted = false;
		PlayerData.gameOver = true;
		SceneManagement.ChangeScene("CompletedLevelScene", Color.black, 0.5f);
	}

	private void	PlayParticle()
	{
		if (!particlePlaying)
		{
			ParticleSystem ps = Instantiate(winningParticle, gameObject.transform.position, gameObject.transform.rotation);
			ps.Play();
			winningSound.Play();
		}
		particlePlaying = true;
	}
}
