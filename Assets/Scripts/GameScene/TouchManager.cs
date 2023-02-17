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
	private Vector2 screenBounds;

	void Awake()
	{
		basket = GameObject.FindGameObjectWithTag("Basket");
		touchAction = new TouchClass();
		rbody = basket.GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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
		Vector2 touchToWorld = Camera.main.ScreenToWorldPoint(pos);
		Vector2 newPos = basket.transform.position;
		if (touchAction.Touch.TouchPress.IsPressed())
		{
			if (touchToWorld.x < screenBounds.x / 2)
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