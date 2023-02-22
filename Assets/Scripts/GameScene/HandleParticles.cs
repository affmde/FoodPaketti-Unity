using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleParticles : MonoBehaviour
{
	private void Start()
	{
		var main = GetComponent<ParticleSystem>().main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}


	public void OnParticleSystemStopped()
	{
		Debug.Log("Systm is stopped");
		//SceneManagement.ChangeScene("GameOver", Color.black, 2.5f);
	}

}
