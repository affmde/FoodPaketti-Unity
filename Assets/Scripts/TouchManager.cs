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
		Debug.Log("Touch position: " + pos);
		Vector2 newPos = basket.transform.position;
		if (touchAction.Touch.TouchPress.IsPressed())
		{
			if (pos.x < Screen.width / 2)
			{
				newPos.x -= 0.3f;
				if (newPos.x < -9)
					newPos.x = -9;
				basket.transform.position =newPos;
			}
			else
			{
				newPos.x += 0.3f;
				if (newPos.x > Screen.width)
					newPos.x = Screen.width;
				basket.transform.position = newPos;
			}
			Debug.Log(basket.transform.position);
			Debug.Log(Camera.main.ViewportToScreenPoint(basket.transform.position));
		}
	}
}
