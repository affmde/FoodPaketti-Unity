using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
	[SerializeField]
	private float speed;
	private TouchClass touchAction;
	private Rigidbody2D rbody;
	private Vector2 moveInput;
	[SerializeField]
	private GameObject basket;

	
	void Awake()
	{
		basket = GameObject.FindGameObjectWithTag("Basket");
		touchAction = new TouchClass();
		rbody = basket.GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		touchAction.Touch.Enable();
	}

	private void	OnDisable()
	{
		touchAction.Touch.Disable();
	}

	private void FixedUpdate()
	{
		Vector2 pos = touchAction.Touch.TouchPosition.ReadValue<Vector2>();
		Vector2 newPos = basket.transform.position;
		if (touchAction.Touch.TouchPress.IsPressed())
		{
			if (pos.x < Screen.width / 2)
			{
				newPos.x -= 0.1f;
				basket.transform.position =newPos;
			}
			else
			{
				newPos.x += 0.1f;
				basket.transform.position = newPos;
			}
		}
	}
}