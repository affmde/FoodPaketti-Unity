using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class AnimatedFruits : MonoBehaviour
{

	[SerializeField]
	private List<GameObject> animatedFruit;
	[SerializeField]
	Transform target;
	[SerializeField]
	List <Transform> startPosition;
	[Space]
	[Header ("Animation settings")]
	[SerializeField]
	[Range(0.5f, 0.9f)] float minDuration;
	[SerializeField]
	[Range(0.9f, 2f)] float maxDuration;
	[SerializeField]
	private TextMeshProUGUI rewardText;


	private Vector3 targetPosition;
	Queue<GameObject> appleQueue = new Queue<GameObject>();
	Queue<GameObject> orangeQueue = new Queue<GameObject>();
	Queue<GameObject> bananaQueue = new Queue<GameObject>();
	[SerializeField]
	private Ease easeType = Ease.InOutBack;


	private void Awake()
	{
		targetPosition = target.position;
		PrepareFruits();
	}

	private int	GetCorrectFruit(string fruitName)
	{
		if (fruitName == "ApplePowerup")
			return (0);
		if (fruitName == "OrangePowerup")
			return (1);
		if (fruitName == "BananaPowerup")
			return (2);
		else
			return (-1);
	}

	private void	PrepareFruits()
	{
		for (int i = 0; i < 7; i++)
		{
			GameObject fruit;
			fruit = Instantiate(animatedFruit[0]);
			fruit.transform.parent = transform;
			fruit.SetActive(false);
			appleQueue.Enqueue(fruit);
		}
		for (int i = 0; i < 7; i++)
		{
			GameObject fruit;
			fruit = Instantiate(animatedFruit[1]);
			fruit.transform.parent = transform;
			fruit.SetActive(false);
			orangeQueue.Enqueue(fruit);
		}
		for (int i = 0; i < 7; i++)
		{
			GameObject fruit;
			fruit = Instantiate(animatedFruit[2]);
			fruit.transform.parent = transform;
			fruit.SetActive(false);
			bananaQueue.Enqueue(fruit);
		}
	}

	private Queue<GameObject> GetCorrectQueue(int val)
	{
		if (val == 0)
			return (appleQueue);
		else if (val == 1)
			return (orangeQueue);
		else if (val == 2)
			return (bananaQueue);
		else
			return (null);
	}
	public void AnimateFruits(string fruitType)
	{
		int queueNumber = GetCorrectFruit(fruitType);
		int	bonus = PowerupReward(fruitType);
		for (int i = 0; i < 7; i++)
		{
			if (GetCorrectQueue(queueNumber).Count > 0)
			{
				GameObject newFruit = GetCorrectQueue(queueNumber).Dequeue();
				newFruit.SetActive(true);
				newFruit.transform.position = startPosition[queueNumber].position;
				newFruit.transform.position = new Vector3(newFruit.transform.position.x + Random.Range(-0.1f, 0.1f), newFruit.transform.position.y + Random.Range(-0.1f, 0.1f), 0);
				float duration = Random.Range(minDuration, maxDuration);
				rewardText.transform.position = new Vector3(newFruit.transform.position.x, newFruit.transform.position.y - 0.1f, newFruit.transform.position.z);
				rewardText.alpha = 1;
				rewardText.text = ("+" + bonus).ToString();
				newFruit.transform.DOMove(targetPosition, duration).SetEase(easeType).OnComplete(()=>{
					rewardText.alpha = 0;
					newFruit.SetActive(false);
					GetCorrectQueue(queueNumber).Enqueue(newFruit);
				});
			}
		}
		PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + bonus);
	}


	private int	PowerupReward(string name)
	{
		if (name == "ApplePowerup")
			return (40);
		else if (name == "OrangePowerup")
			return (70);
		else if (name == "BananaPowerup")
			return (150);
		else
			return (0);
	}
}
