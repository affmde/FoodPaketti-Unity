using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
	private PlayerData playerData;
	[SerializeField]
	private TextMeshProUGUI text;
	private void Awake()
	{
		playerData = FindObjectOfType<GameState>().playerData;
	}

	private void	Start()
	{
		text.text = playerData.duration.ToString();
	}

	private void	Update()
	{
		playerData.duration += Time.deltaTime;
		int	timeDisplay = Mathf.FloorToInt(playerData.duration);
		text.text = timeDisplay.ToString();
	}
	
}
