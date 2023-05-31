using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Credits : MonoBehaviour
{
	private TextMeshProUGUI[]	texts;
	[SerializeField]			int		moveSpeed = 25;

	float	time;
	private void	Awake()
	{
		texts = GameObject.FindObjectsOfType<TextMeshProUGUI>();
	}

	private void	Update()
	{
		time += Time.deltaTime;
		if (time >= 3.5f)
			SceneManagement.ChangeScene("SettingsScene", Color.black, 0.3f);
		foreach(var text in texts)
		{
			text.GetComponent<RectTransform>().localPosition += new Vector3(0,moveSpeed,0) * Time.deltaTime;
		}
	}
}
