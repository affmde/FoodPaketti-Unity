using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public CanvasGroup canvasGroup;
	[SerializeField]
	private Slider progressBar;
	[SerializeField]
	TextMeshProUGUI progressText;
	private AsyncOperation operation;

    public void StartGame(string sceneToLoad)
    {
        StartCoroutine(StartLoad(sceneToLoad));
    }
    IEnumerator StartLoad(string sceneToLoad)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        operation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!operation.isDone)
        {
			progressBar.value = Mathf.Clamp01(operation.progress / 0.9f);
			progressText.text = Mathf.Round(progressBar.value * 100).ToString() + "%";
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }
    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}
