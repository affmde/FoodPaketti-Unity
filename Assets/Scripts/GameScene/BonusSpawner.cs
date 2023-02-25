using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject bonus;
	private Vector2 screenBounds;
	private float bonusWidth;
	private float bonusHeight;
	[SerializeField]
	private int	minTotalFruits;
	private int	refValue;
	private int	currentVal;
	private void	Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		bonusWidth = bonus.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		bonusHeight = bonus.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
		refValue = PlayerPrefs.GetInt("totalFruits");
	}

	private Vector3 GetRandomPosition()
	{
		float	x = Random.Range(screenBounds.x * -1 + bonusWidth, screenBounds.x - bonusWidth);
		float y = screenBounds.y + 1;
		Vector3 pos = new Vector3(x, y, 0);
		pos.x = Mathf.Clamp(x, screenBounds.x * -1 + bonusWidth, screenBounds.x - bonusWidth);
		pos.y = y;
		return (pos);
	}

	private void GenerateBonus()
	{
		Vector3 randPos = GetRandomPosition();
		GameObject newBonus = Instantiate(bonus, randPos, bonus.transform.rotation);
	}


	private void	Update()
	{
		currentVal = PlayerPrefs.GetInt("totalFruits") - refValue;
		if (currentVal > minTotalFruits)
		{
			refValue = PlayerPrefs.GetInt("totalFruits");
			GenerateBonus();
		}
	}
}
