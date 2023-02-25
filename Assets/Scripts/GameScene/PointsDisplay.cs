using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

	void Start()
	{
		text.text = 0.ToString();
	}

	void Update()
	{
		int	points = PlayerPrefs.GetInt("score");
		text.text = points.ToString();
	}
}
