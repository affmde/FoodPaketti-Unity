using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
	[SerializeField] private List<GameObject>	fruits;
	[SerializeField] private float				timer;
	private float								defusedTimer;
	private float 								refDefTime;
	[SerializeField] private float				respawnTime = 0.1f;

	private Vector2								screenBounds;
	private float								fruitWidth;
	private float								fruitHeight;
	[SerializeField] List<int>					fruitsOdds;
	[SerializeField] int						difficlutyLevel;
	private Vector3								resize;
	private Vector3								gravity;

	private void	Start()
	{
		fruitsOdds[0] = LevelsData.appleOdd;
		fruitsOdds[1] = LevelsData.orangeOdd;
		fruitsOdds[2] = LevelsData.bananaOdd;
		difficlutyLevel = LevelsData.difficulty;
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		fruitWidth = fruits[0].transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		fruitHeight = fruits[0].transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
		resize = new Vector3(3,3,3);
		gravity = new Vector3(0, -10f, 0);
		Physics.gravity = gravity;
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
		GameObject apple = Instantiate(fruits[0], GetRandomPosition(), Quaternion.Euler(0,0,0));
		apple.transform.localScale = resize;
	}

	private void	GenerateOranges()
	{
		GameObject orange = Instantiate(fruits[1], GetRandomPosition(), Quaternion.Euler(0,0,0));
		orange.transform.localScale = resize;
	}

	private void	GenerateBananas()
	{
		GameObject banana = Instantiate(fruits[2], GetRandomPosition(), Quaternion.Euler(0,0,0));
		banana.transform.localScale = resize;
	}

	private void	GenerateBombs()
	{
		GameObject bomb = Instantiate(fruits[3], GetRandomPosition(), Quaternion.Euler(0,0,0));
		bomb.transform.localScale = resize;
	}

	private void GenerateFruit()
	{
		int	rand = Random.Range(0, 100);
		if (rand < fruitsOdds[0])
			GenerateApples();
		else if (rand < fruitsOdds[1])
			GenerateOranges();
		else
			GenerateBananas();
	}

	private void	Difficulty()
	{
		int	rand = Random.Range(0, 100);
		if (rand < difficlutyLevel)
			GenerateFruit();
		else
			GenerateBombs();
	}



	void Update()
	{
		
		if (!PlayerData.gameOver)
		{
			if (timer >= respawnTime)
			{
				Difficulty();
				timer = 0;
			}
			else
				timer += Time.deltaTime;
		}
	}
}
