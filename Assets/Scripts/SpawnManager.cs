using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> fruits;
	private float timer;
	[SerializeField]
	private float respawnTime = 0.1f;
	private PlayerData playerData;


	private void	Awake()
	{
		playerData = FindObjectOfType<PlayerData>();
	}

	private Vector3 GetRandomPosition()
	{
		int	x = Random.Range(-10, 11);
		int y = 10;
		Vector3 pos = new Vector3(x, y, 0);
		return (pos);
	}

	private void GenerateApples()
	{
		Instantiate(fruits[0], GetRandomPosition(), Quaternion.Euler(0,0,0));
	}

	private void	GenerateOranges()
	{
		Instantiate(fruits[1], GetRandomPosition(), Quaternion.Euler(0,0,0));
	}

	private void	GenerateBananas()
	{
		Instantiate(fruits[2], GetRandomPosition(), Quaternion.Euler(0,0,0));
	}

	private void	GenerateBombs()
	{
		Instantiate(fruits[3], GetRandomPosition(), Quaternion.Euler(0,0,0));
	}

	private void GenerateFruit()
	{
		int	rand = Random.Range(0, 100);
		if (rand < 50)
			GenerateApples();
		else if (rand < 75)
			GenerateOranges();
		else
			GenerateBananas();
	}

	private void	Difficulty()
	{
		int	rand = Random.Range(0, 100);
		if (playerData.time < 7)
		{
			if (rand < 80)
				GenerateFruit();
			else
				GenerateBombs();
		}
		else if (playerData.time < 15)
		{
			if (rand < 70)
				GenerateFruit();
			else
				GenerateBombs();
		}
		else if (playerData.time < 30)
		{
			if (rand < 55)
				GenerateFruit();
			else GenerateBombs();
		}
		else if (playerData.time < 45)
		{
			if (rand < 30)
				GenerateFruit();
			else
				GenerateBombs();
		}
		else
		{
			if (rand < 10)
				GenerateFruit();
			else
				GenerateBombs();
		}
	}

    // Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= respawnTime)
		{
			Difficulty();
			timer = 0;
		}
	}
}
