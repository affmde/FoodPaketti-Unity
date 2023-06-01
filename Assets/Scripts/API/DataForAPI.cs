using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersonalHighscoresDataAPI
{
	public string				message;
	public bool					success;
	public List<DataForSend>	data;
}

[System.Serializable]
public class TopUserDataAPI
{
	public List<DataForTopUsersAPI> topUsers;
}

[System.Serializable]
public struct DataForTopUsersAPI
{
	public int		level;
	public int		xp;
	public string	username;
}
