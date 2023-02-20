using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
	//private PlayerData playerData;
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
	}


	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "BorderDown")
			Destroy(gameObject);
		if (col.collider.name == "Basket" && PlayerData.gameOver == false)
		{
			if (gameObject.name == "banana(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 25);
				PlayerPrefs.SetInt("bananas", PlayerPrefs.GetInt("bananase") + 1);
			}
			else if (gameObject.name == "orange(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10);
				PlayerPrefs.SetInt("oranges", PlayerPrefs.GetInt("oranges") + 25);
			}
			else if (gameObject.name == "apple(Clone)")
			{
				PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 5);
				PlayerPrefs.SetInt("apples", PlayerPrefs.GetInt("apples") + 1);
			}
			else if (gameObject.name == "bombVertical(Clone)")
			{
				PlayerData.gameOver = true;
				Debug.Log(PlayerData.gameOver);
				ParticleSystem ps = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(gameObject);
				ps.Play();
				audioSource.Play();
				return ;
			}
			audioSource.Play();
			PlayerPrefs.SetInt("totalFruits", PlayerPrefs.GetInt("totalFruits") + 1);
			Destroy(gameObject);
		}
	}
}
