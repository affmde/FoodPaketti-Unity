using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombDefuser : MonoBehaviour
{
	private Image			image;
	private Button			button;
	private float			timeToFill = 45;
	private float			fillTimeRef;
	private float			currentTime;
	[SerializeField] private List<AudioSource>		audioSource;
	private bool			soundPlaying = false;
	[SerializeField] float	blinkSpeed = 2f;

	private void Awake()
	{
		image = GetComponent<Image>();
		button = GetComponent<Button>();
	}

	private void Start()
	{
		image.fillAmount = 0;
		button.interactable = false;
		PlayerData.bombDefused = false;
		foreach(var audioS in audioSource)
			SceneManagement.ToogleAudioSource(audioS);
	}

	IEnumerator resetDefuseBool()
	{
		yield return (new WaitForSeconds(25));
		fillTimeRef = PlayerPrefs.GetFloat("duration");
		PlayerData.bombDefused = false;
		soundPlaying = false;
	}

	public void	DefuseBomb()
	{
		PlayerData.bombDefused = true;
		audioSource[1].Play();
		image.fillAmount = 0;
		StartCoroutine(resetDefuseBool());
	}

	private void	BlinkSymbol()
	{
		image.color = Color.Lerp(Color.yellow, Color.black, Mathf.PingPong(Time.time * blinkSpeed, 1));
	}

	private void Update()
	{
		if (!PlayerData.bombDefused)
		{
			currentTime = PlayerPrefs.GetFloat("duration") - fillTimeRef;
			image.fillAmount = Mathf.Clamp01(currentTime / timeToFill);
		}
		if (!soundPlaying && !PlayerData.bombDefused && image.fillAmount == 1)
		{
			audioSource[0].Play();
			soundPlaying = true;
		}
		if (!PlayerData.bombDefused && image.fillAmount == 1)
			BlinkSymbol();
		if (image.fillAmount == 1 && !PlayerData.bombDefused)
		{
			button.interactable = true;
			currentTime = 0;
		}
		else
			button.interactable = false;
	}
}
