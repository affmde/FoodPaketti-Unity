using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;
	[SerializeField]
	private GameObject player;
	private InputAction	touchPositionAction;
	private InputAction	touchPressAction;
	private bool hold = false;
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		touchPositionAction = playerInput.actions["TouchPosition"];
		touchPressAction = playerInput.actions["TouchPress"];
	}
	
	private void	TouchPressed(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Debug.Log("Started!!");
		}
		if (context.performed)
		{
			Debug.Log("Performed");
			hold = true;
		}
		if (context.canceled)
		{
			Debug.Log("Canceled detected!!");
			hold = false;
		}
	}

	private void Move()
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
		Vector3	newPlayerPosition = player.transform.position;
		if ( pos.x > 0)
		{
			newPlayerPosition.x += 0.1f;
			if (newPlayerPosition.x > 9)
				newPlayerPosition.x = 9f;
		}
		else
		{
			newPlayerPosition.x -= 0.1f;
			if (newPlayerPosition.x < -9)
				newPlayerPosition.x = -9f;
		}
		player.transform.position = newPlayerPosition;
	}
	private void	OnEnable()
	{
		touchPressAction.performed += TouchPressed;
	}

	private void	OnDisable()
	{
		touchPressAction.performed -= TouchPressed;
	}

	private void	Update()
	{
		if (hold)
			Move();
	}
}
