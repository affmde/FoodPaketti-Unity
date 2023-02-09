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

	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		touchPositionAction = playerInput.actions["TouchPosition"];
		touchPressAction = playerInput.actions["TouchPress"];
	}
	
	private void	TouchPressed(InputAction.CallbackContext context)
	{
		float value = context.ReadValue<float>();
		if (value != 0)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
			Vector3	newPlayerPosition = player.transform.position;
			if ( pos.x > 0)
				newPlayerPosition.x += 0.1f;
			else
				newPlayerPosition.x -= 0.1f;
			player.transform.position = newPlayerPosition;
		}
	}

	private void	OnEnable()
	{
		touchPressAction.performed += TouchPressed;
	}

	private void	OnDisable()
	{
		touchPressAction.performed -= TouchPressed;
	}
}
