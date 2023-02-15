using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;
	private PlayerData playerData;


	private void	Awake()
	{
		playerData = FindObjectOfType<GameState>().playerData;
	}

    // Start is called before the first frame update
    void Start()
    {
		text.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		int	points = playerData.score;
		text.text = points.ToString();
    }
}
