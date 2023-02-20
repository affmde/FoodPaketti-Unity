using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLoadingScreen : MonoBehaviour
{
    public CanvasGroup loadingScreen;


	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        StartCoroutine(FadeLoadScreen(2));
    }

	IEnumerator FadeLoadScreen(float duration)
	{
		float startValue = loadingScreen.alpha;
		float time = 0;
		while (time < duration)
		{
			loadingScreen.alpha = Mathf.Lerp(startValue, 1, time / duration);
			time += Time.deltaTime;
			yield return (null);
		}
		loadingScreen.alpha = 1;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
