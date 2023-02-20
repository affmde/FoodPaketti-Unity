using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleParticles : MonoBehaviour
{
	private SceneLoader loader;

	private void Awake()
	{
		loader = FindObjectOfType<SceneLoader>();
	}

	private void Start()
	{
		var main = GetComponent<ParticleSystem>().main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}


	public void OnParticleSystemStopped()
	{
		//SceneManagement.ChangeScene("GameOver", Color.black, 2.5f);
		loader.StartGame("GameOver");
	}

}
