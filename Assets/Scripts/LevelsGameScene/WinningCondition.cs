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
		Debug.Log("Game Started!");
		Debug.Log("gameOver?: " + PlayerData.gameOver);
		type = LevelsData.type;
		GameSettings.levelCompleted = false;
	}

	private void	Update()
	{
		Debug.Log("Entered the Updated of Winning condition script");
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
			Debug.Log("duration: " + PlayerPrefs.GetFloat("duration") + " required: " + LevelsData.survivor);
			if (PlayerPrefs.GetFloat("duration") >= LevelsData.survivor)
			{
				PlayParticle();
				GameSettings.levelCompleted = true;
			}
		}
		else if (type == "collector")
		{
			Debug.Log("apples oclected: " + PlayerPrefs.GetInt("apples") + " required: " + LevelsData.collector.apples);
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
