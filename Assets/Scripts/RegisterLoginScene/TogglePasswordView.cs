using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TogglePasswordView : MonoBehaviour
{
	[SerializeField] Image showIcon, hideIcon;
	[SerializeField] TMP_InputField passwordField;
	private bool show = false;

	public void Start()
	{
		showIcon.gameObject.SetActive(false);
		hideIcon.gameObject.SetActive(true);
	}

	public void ToogleIconView()
	{
		show = !show;
		if (!show)
		{
			showIcon.gameObject.SetActive(false);
			hideIcon.gameObject.SetActive(true);
			passwordField.contentType = TMP_InputField.ContentType.Password;
		}
		else
		{
			showIcon.gameObject.SetActive(true);
			hideIcon.gameObject.SetActive(false);
			passwordField.contentType = TMP_InputField.ContentType.Standard;
		}
	}
}
