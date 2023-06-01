using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsData
{
	public static int	Level;
	public static string	title;
	public static string	description;
	public static string	type;
	public static List<CollectorWinningCondition> collector;
	public static int		surviver;
	public static int		scorer;

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
