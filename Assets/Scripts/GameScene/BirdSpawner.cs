using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
	[SerializeField] private List<GameObject>	bird;
	private Animator					birdAnimation;
	[SerializeField] private int		birdSpawnTime;
	private float						refTime;
	private float						currentTime;


	private int	RandomBird()
	{
		int	rand = Random.Range(0, bird.Count);
		return	(rand);
	}

	private void	BirdGenerator()
	{
		int rand = RandomBird();
		Vector3 spawnPos = new Vector3(bird[rand].transform.position.x, bird[rand].transform.position.y + Random.Range(-1f, 1f), bird[rand].transform.position.z);
		GameObject newBird = Instantiate(bird[rand], spawnPos, bird[rand].transform.rotation);
	}

	private void	Update()
	{
		currentTime = PlayerPrefs.GetFloat("duration") - refTime;
		if (currentTime >= birdSpawnTime)
		{
			BirdGenerator();
			refTime = PlayerPrefs.GetFloat("duration");
		}
	}
}
