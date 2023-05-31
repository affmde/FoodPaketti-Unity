using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	public ParticleSystem explosion;
	[SerializeField]
	private AudioSource audioSource;
	private AudioSource backtrack;
	private void Awake()
	{
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		if (gameObject.name == "bombVertical(Clone)")
			audioSource = GameObject.Find("BombExplode").GetComponent<AudioSource>();
		else
			audioSource = GameObject.Find("FruitPickSound").GetComponent<AudioSource>();
		SceneManagement.ToogleAudioSource(audioSource);
		SceneManagement.ToogleAudioSource(backtrack);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket" && PlayerData.gameOver == false)
		{
			if (gameObject.name == "banana(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 25 * PlayerPrefs.GetInt("multiplier"));
				PlayerPrefs.SetInt("bananas", PlayerPrefs.GetInt("bananas") + 1);
				PlayerPrefs.SetInt("totalFruits", PlayerPrefs.GetInt("totalFruits") + 1);
			}
			else if (gameObject.name == "orange(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10 * PlayerPrefs.GetInt("multiplier"));
				PlayerPrefs.SetInt("oranges", PlayerPrefs.GetInt("oranges") + 1);
				PlayerPrefs.SetInt("totalFruits", PlayerPrefs.GetInt("totalFruits") + 1);
			}
			else if (gameObject.name == "apple(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 5 * PlayerPrefs.GetInt("multiplier"));
				PlayerPrefs.SetInt("apples", PlayerPrefs.GetInt("apples") + 1);
				PlayerPrefs.SetInt("totalFruits", PlayerPrefs.GetInt("totalFruits") + 1);
			}
			else if (gameObject.name == "bombVertical(Clone)")
			{
				PlayerData.gameOver = true;
				ParticleSystem ps = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(gameObject);
				ps.Play();
				audioSource.Play();
				SceneManagement.ChangeScene("GameOver", Color.black, 0.5f);
			}
			audioSource.Play();
			Destroy(gameObject);
		}
	}
}
