using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserRanking : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI	username;
	[SerializeField] TextMeshProUGUI	level;

	private void	Start()
	{
		if (int.Parse(gameObject.name) >= API.topUsersData.topUsers.Count)
			gameObject.SetActive(false);
		else
		{
			DataForTopUsersAPI user = API.topUsersData.topUsers[int.Parse(gameObject.name)];
			username.text = user.username;
			level.text = user.level.ToString();
		}
	}
}
