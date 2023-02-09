using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> fruits;
	private float timer;
	[SerializeField]
	private float respawnTime = 0.5f;


	private bool	ProbableGetFruit()
	{
		int	rand = Random.Range(0, 100);
		if (rand < 80)
			return (true);
		else
			return (false);
	}

	private int GetFruit()
	{
		int	rand = Random.Range(0, 100);
		if (rand < 20)
			return (1);
		else if (rand < 40)
			return (2);
		else if (rand < 60)
			return (3);
		else if (rand < 80)
			return (4);
		else
			return (5);
	}

	private Vector3 GetRandomPosition()
	{
		int	x = Random.Range(-10, 11);
		int y = 10;
		Vector3 pos = new Vector3(x, y, 0);
		return (pos);
	}

	private void	DeployFruit()
	{
		if (ProbableGetFruit())
		{

			int	fruit = GetFruit();
			if (fruit == 1)
				Instantiate(fruits[0], GetRandomPosition(), Quaternion.Euler(0,0,0));
			else if (fruit == 2)
				Instantiate(fruits[1], GetRandomPosition(), Quaternion.Euler(0,0,0));
			else if (fruit == 3)
				Instantiate(fruits[2], GetRandomPosition(), Quaternion.Euler(0,0,0));
			else if (fruit == 4)
				Instantiate(fruits[3], GetRandomPosition(), Quaternion.Euler(0,0,0));
			else if (fruit == 5)
				Instantiate(fruits[4], GetRandomPosition(), Quaternion.Euler(0,0,0));
		}
	}

    // Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= respawnTime)
		{
			DeployFruit();
			timer = 0;
		}
	}
}
