using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsData
{
	public static int		level;
	public static string	title;
	public static string	description;
	public static string	type;
	public static CollectorWinningCondition collector;
	public static int		survivor;
	public static int		scorer;
	public static int		bananaOdd;
	public static int		appleOdd;
	public static int		orangeOdd;
	public static int		difficulty;
	public static int		xp;

}

[System.Serializable]
public struct CollectorWinningCondition
{
	public int	bananas;
	public int	apples;
	public int	oranges;
	public int	watermelons;
	public int	parsimmons;
	public int	totalFruits;
}
