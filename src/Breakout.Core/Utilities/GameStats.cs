using Breakout.Core.Models;
using Breakout.Core.Utilities.Map;
using System.Diagnostics;

namespace Breakout.Core.Utilities
{
	internal static class GameStats
	{
		[ConditionalAttribute("DEBUG")]
		public static void PrintMapsInfo()
		{
			foreach (var mapInfo in MapManager.Maps)
			{
				var map = MapManager.Load(mapInfo.Level);
				var totalHealth = 0;
				var totalScore = 0;

				foreach (var block in map.Layer1)
				{
					totalHealth += block.Health;
					totalScore += block.Health * 7;
				}

				Debug.WriteLine($"{mapInfo.Name}:");
				Debug.WriteLine($"Total block health: {totalHealth}");
				Debug.WriteLine($"Total potential score: {totalScore}");
				Debug.WriteLine("");
			}
		}
	}
}
