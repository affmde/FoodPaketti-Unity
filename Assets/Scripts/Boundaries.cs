using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
	private Vector2 screenBounds;
	private float basketWidth;
	private float basketHeight;


	private void	Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		basketWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		basketHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	private void LateUpdate()
	{
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + basketWidth, screenBounds.x - basketWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + basketHeight, screenBounds.y - basketHeight);
		transform.position = viewPos;
	}
}
