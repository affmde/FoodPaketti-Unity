using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RewardPlayer : MonoBehaviour
{

	private Vector2 screenBounds;
	private bool	RewardReleased;
	private float randomX;
	[SerializeField] private float speed;
	private AudioSource rewardDropSound;
	private bool		audioPlaying = false;

	private void Awake()
	{
		rewardDropSound = GetComponent<AudioSource>();
	}

	private void	Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		randomX = Random.Range(-screenBounds.x, screenBounds.x - screenBounds.x / 2);
		ActiveReward();
		SceneManagement.ToogleAudioSource(rewardDropSound);
	}

	private void	ActiveReward()
	{
		int	percent = Random.Range(0, 100);
		if (percent < 50)
			gameObject.SetActive(false);
	}

	public void	ReleaseReward()
	{
		Vector3 newPos = new Vector3(randomX, gameObject.transform.position.y - speed * Time.deltaTime, gameObject.transform.position.z);
		gameObject.transform.position = newPos;
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket" && PlayerData.gameOver == false)
		{
			PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + (100 * PlayerPrefs.GetInt("multiplier")));
			PlayerPrefs.SetInt("persimmons", PlayerPrefs.GetInt("persimmons") + 1);
			PlayerPrefs.SetInt("totalFruits", PlayerPrefs.GetInt("totalFruits") + 1);
			Destroy(gameObject);
		}
	}



	private void	Update()
	{
		if (transform.position.x >= randomX && !RewardReleased)
		{
			RewardReleased = true;
			if (!audioPlaying)
			{
				rewardDropSound.Play();
				audioPlaying = true;
			}
		}
		if (RewardReleased)
			ReleaseReward();
	}
}
