using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour
{
	[SerializeField]
	private List<TextMeshProUGUI> cols;
	private AudioSource audioSource;
	private AudioSource backtrack;
	private SceneLoader loader;
	[SerializeField] private GameObject	scoresPanel;
	[SerializeField] private GameObject	rankingPanel;
	
	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		loader = FindObjectOfType<SceneLoader>();
		SceneManagement.ToogleAudioSource(audioSource);
		SceneManagement.ToogleAudioSource(backtrack);
	}

	private void	PopulateGrid(DataForSend[] data)
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
		yield return (API.GetTopUsers());
	}

	public void ReturnScene()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0.3f));
		SceneManagement.ChangeScene("StartScene", Color.black, 1f);
	}

	private void Start()
	{
		StartCoroutine(LoadData());
		StartCoroutine(API.GetUserHighscores());
		scoresPanel.SetActive(true);
		rankingPanel.SetActive(false);
	}

	public void	ShowPersonalHighScores()
	{
		int i = 0;
		for (int j = 0; j < 10; j++)
		{
			if (j < API.personalHighscoreData.data.Count)
			{
				cols[i].text = (API.personalHighscoreData.data[j] != null) ? API.personalHighscoreData.data[j].username : " ";
				cols[i + 1].text = (API.personalHighscoreData.data[j] != null ? API.personalHighscoreData.data[j].score.ToString() : " ");
				cols[i + 2].text = (API.personalHighscoreData.data[j] != null) ?  API.personalHighscoreData.data[j].duration.ToString() : " ";
			}
			else
			{
				cols[i].text = " ";
				cols[i + 1].text = " ";
				cols[i + 2].text = " ";
			}
			i += 3;
		}
		rankingPanel.SetActive(false);
		scoresPanel.SetActive(true);
	}

	public void	ShowWorldHighScores()
	{
		PopulateGrid(SendData.loadedData);
		rankingPanel.SetActive(false);
		scoresPanel.SetActive(true);
	}

	public void	ShowRanking()
	{
		rankingPanel.SetActive(true);
		scoresPanel.SetActive(false);
	}

}
