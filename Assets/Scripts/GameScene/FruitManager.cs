using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	private PlayerData playerData;
	public ParticleSystem explosion;
	[SerializeField]
	private AudioSource audioSource;
	private AudioSource backtrack;
	private void Awake()
	{
		playerData = FindAnyObjectByType<GameState>().playerData;
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		if (gameObject.name == "bombVertical(Clone)")
			audioSource = GameObject.Find("BombExplode").GetComponent<AudioSource>();
		else
			audioSource = GameObject.Find("FruitPickSound").GetComponent<AudioSource>();
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket" && playerData.gameOver == false)
		{
			if (gameObject.name == "banana(Clone)")
			{
				playerData.score += 25;
				playerData.bananas++;
			}
			else if (gameObject.name == "orange(Clone)")
			{
				playerData.score += 10;
				playerData.oranges++;
			}
			else if (gameObject.name == "apple(Clone)")
			{
				playerData.apples++;
				playerData.score += 5;
			}
			else if (gameObject.name == "bombVertical(Clone)")
			{
				playerData.gameOver = true;
				ParticleSystem ps = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
				
				ps.Play();
				StartCoroutine(FadeInOutSound.StartFade(backtrack, ps.main.duration, 0.25f));
				audioSource.Play();
				Destroy(gameObject);
				return ;
			}
			audioSource.Play();
			playerData.totalFruits++;
			Destroy(gameObject);
		}
	}
}
