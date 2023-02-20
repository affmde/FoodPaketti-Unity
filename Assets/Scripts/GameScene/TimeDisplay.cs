using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;
	private void Awake()
	{
	
	}

	private void	Start()
	{
		text.text = 0.ToString();
	}

	private void	Update()
	{
		PlayerPrefs.SetFloat("duration", PlayerPrefs.GetFloat("duration") + Time.deltaTime);
		int	timeDisplay = Mathf.FloorToInt(PlayerPrefs.GetFloat("duration"));
		text.text = timeDisplay.ToString();
	}
	
}
