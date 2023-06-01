using UnityEngine;

public class StartScene : MonoBehaviour
{
	private AudioSource audioSource;
	private AudioSource backtrack;
	private SceneLoader loadingScreen;

	
	private void Awake()
	{
		audioSource = GameObject.Find("BtnClickSound").GetComponent<AudioSource>();
		backtrack = GameObject.Find("BackgroundSound").GetComponent<AudioSource>();
		loadingScreen = FindAnyObjectByType<SceneLoader>();
	}

	private void Start()
	{
		API.GetUserData();
		SceneManagement.ToogleAudioSource(backtrack);
		SceneManagement.ToogleAudioSource(audioSource);
		PlayerData.ResetData();
	}
	public void	StartGame()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("SampleScene");
	}

	public void	GoTOHeighScores()
	{
		audioSource.Play();
		StartCoroutine(FadeInOutSound.StartFade(backtrack, 1f, 0));
		loadingScreen.StartGame("Highscores");
	}

	public void	GoToSettings()
	{
		audioSource.Play();
		SceneManagement.ChangeScene("SettingsScene", Color.black, 0.5f);
	}

	public void	GoToStats()
	{
		audioSource.Play();
		SceneManagement.ChangeScene("StatsScene", Color.black, 0.5f);
	}

	public void	QuitApp()
	{
		Application.Quit();
	}
}
