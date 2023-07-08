using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NormalRegisterPanel : MonoBehaviour
{
	[SerializeField] GameObject panel;
	[SerializeField] GameObject loginPanel;
	[SerializeField] GameObject signupPanel;
	[SerializeField] List<TMP_InputField> inputList;
	[SerializeField] List<Image> errorArea;

	private void Start()
	{
		panel.SetActive(false);
		loginPanel.SetActive(false);
		signupPanel.SetActive(false);
	}
	public void OpenLoginPanel()
	{
		panel.SetActive(true);
		loginPanel.SetActive(true);
		signupPanel.SetActive(false);
	}

	public void ClosePanel()
	{
		panel.SetActive(false);
		loginPanel.SetActive(false);
		signupPanel.SetActive(false);
		foreach(TMP_InputField input in inputList)
			input.text = "";
		foreach(Image img in errorArea)
			img.gameObject.SetActive(false);

	}

	public void OpenSignupPanel()
	{
		panel.SetActive(true);
		loginPanel.SetActive(false);
		signupPanel.SetActive(true);
	}
}
