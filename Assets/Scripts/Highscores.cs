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

	private void	PopulateGrid(PlayerData [] data)
	{
		int	i = 0;
		foreach(var item in data)
		{
			cols[i].text = item.username;
			cols[i + 1].text = item.score.ToString();
			cols[i + 2].text = item.duration.ToString();
			i += 3;
		}
	}
	private IEnumerator LoadData()
	{
		yield return (data.FetchData());
		PopulateGrid(data.loadedData);
	}
	private void Start()
	{
		StartCoroutine(LoadData());
	}
}
