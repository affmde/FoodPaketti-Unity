using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> fruits;
	[SerializeField]
	private float	timer;
	private float	defusedTimer;
	private float refDefTime;
	[SerializeField]
	private float respawnTime = 0.1f;

	private Vector2 screenBounds;
	private float fruitWidth;
	private float fruitHeight;


	private void	Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		fruitWidth = fruits[0].transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		fruitHeight = fruits[0].transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	private Vector3 GetRandomPosition()
	{
		float	x = Random.Range(screenBounds.x * -1 + fruitWidth, screenBounds.x - fruitWidth);
		float y = screenBounds.y + 1;
		Vector3 pos = new Vector3(x, y, 0);
		pos.x = Mathf.Clamp(x, screenBounds.x * -1 + fruitWidth, screenBounds.x - fruitWidth);
		pos.y = y;
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
		if (PlayerPrefs.GetFloat("duration") < 7)
		{
			if (rand < 80)
				GenerateFruit();
			else
				GenerateBombs();
		}
		else if (PlayerPrefs.GetFloat("duration") < 15)
		{
			if (rand < 70)
				GenerateFruit();
			else
				GenerateBombs();
		}
		else if (PlayerPrefs.GetFloat("duration") < 30)
		{
			if (rand < 55)
				GenerateFruit();
			else 
				GenerateBombs();
		}
		else if (PlayerPrefs.GetFloat("duration") < 45)
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


	private void SpawnAfterDefusing()
	{
		Debug.Log("Spawn after defusing active");
		int rand = Random.Range(0, 100);
		if (rand < 25)
			GenerateApples();
		else if (rand < 50)
			GenerateOranges();
		else if (rand < 75)
			GenerateBananas();
		else
			GenerateBombs();
	}

    // Update is called once per frame
	void Update()
	{
		if (!PlayerData.gameOver)
		{
			if (!PlayerData.bombDefused)
			{
				timer += Time.deltaTime;
				if (timer >= respawnTime)
				{
					Difficulty();
					timer = 0;
				}
			}
			else
			{
				defusedTimer += Time.deltaTime;
				refDefTime += defusedTimer;
				if (defusedTimer >= respawnTime)
				{
					defusedTimer = 0;
					SpawnAfterDefusing();
				}
				if (refDefTime >= 25)
				{
					defusedTimer = 0;
					refDefTime = 0;
					//PlayerData.bombDefused = false;
				}
			}
		}
	}
}
