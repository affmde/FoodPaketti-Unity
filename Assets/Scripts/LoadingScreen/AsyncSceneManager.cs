using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class AsyncSceneManager : MonoBehaviour
{
    private AsyncOperation loadingOperation;
	public string nextScene;
	private Slider progressBar;
	public TextMeshProUGUI progressText;
	private void Start()
	{
		loadingOperation = SceneManager.LoadSceneAsync(nextScene);
	}

	void Update()
	{
		progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
		progressText.text = Mathf.Round(progressBar.value * 100).ToString() + "%";
	}
}
