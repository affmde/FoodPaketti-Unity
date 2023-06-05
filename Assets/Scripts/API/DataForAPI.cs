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
	public int[]	completedLevels;
}


[SerializeField]
public class LevelsDataForAPI
{
	public bool					success;
	public string				message;
	public List<LevelsStruct>	data;
}

[System.Serializable]
public class LevelsStruct
{
	public int		level;
	public string	title;
	public string	description;
	public string	type;
	public CollectorWinningCondition collector;
	public int		survivor;
	public int		scorer;
	public int		bananaOdd;
	public int		appleOdd;
	public int		orangeOdd;
	public int		difficulty;
	public int		xp;
}
