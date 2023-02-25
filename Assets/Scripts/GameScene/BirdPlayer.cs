using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
	private Transform birdTransform;
	[SerializeField] private float speed = 5f;
	private Vector2 screenBounds;
	private Rigidbody2D rb;
	private AudioSource birdSound;

	private void Awake()
	{
		birdTransform = GetComponent<Transform>();
		rb = GetComponentInChildren<Rigidbody2D>();
		birdSound = GetComponent<AudioSource>();
	}

	private void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		birdSound.Play();
	}
	

	private void Update()
	{
		birdTransform.position = new Vector3(birdTransform.position.x + speed * Time.deltaTime, birdTransform.position.y, birdTransform.position.z);
		if (birdTransform.position.x > screenBounds.x + 1)
		{
			Destroy(gameObject);
		}
	}
}
