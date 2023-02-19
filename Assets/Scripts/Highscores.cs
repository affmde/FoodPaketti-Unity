using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour
{
	//private SendData data;
	[SerializeField]
	private List<TextMeshProUGUI> cols;
	private AudioSource audioSource;
	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
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
		yield return (SendData.FetchData());
		PopulateGrid(SendData.loadedData);
	}

	public void ReturnScene()
	{
		audioSource.Play();
		SceneManagement.ChangeScene("StartScene");
	}

	private void Start()
	{
		StartCoroutine(LoadData());
	}
}
