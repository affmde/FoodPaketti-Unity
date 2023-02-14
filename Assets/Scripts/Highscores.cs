using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Highscores : MonoBehaviour
{
	private SendData data;
	[SerializeField]
	private List<TextMeshProUGUI> cols;
	private void Awake()
	{
		data = GetComponent<SendData>();
	}

	private IEnumerator LoadData()
	{
		yield return (data.FetchData());
		Debug.Log(data.loadedData[0].apples);
		cols[0].text = data.loadedData[0].username;
		cols[1].text = data.loadedData[0].points.ToString();
		cols[2].text = data.loadedData[0].duration.ToString();
	}
	private void Start()
	{
		StartCoroutine(LoadData());
	}
}
