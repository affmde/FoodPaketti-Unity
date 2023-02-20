using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
		text.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
		int	points = PlayerPrefs.GetInt("score");
		text.text = points.ToString();
    }
}
