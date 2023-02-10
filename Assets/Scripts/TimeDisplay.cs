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
		playerData = FindObjectOfType<PlayerData>();
	}

	private void	Start()
	{
		text.text = playerData.time.ToString();
	}

	private void	Update()
	{
		playerData.time += Time.deltaTime;
		int	timeDisplay = Mathf.FloorToInt(playerData.time);
		text.text = timeDisplay.ToString();
	}
	
}
