using Breakout.Core.Models.Maps;
using Breakout.Pipeline.TiledMap;
using Breakout.Core.Views.Loaders;
using System.Collections.Generic;

namespace Breakout.Core.Controllers.Levels
{
	public static class LevelPicker
	{
		public static int CurrentLevelNumber = 1;

		public readonly static Dictionary<int, string> Levels = new Dictionary<int, string>()
		{
			{ 1, "Quick" },
			{ 2, "Mario" },
			{ 3, "Mario" },
			{ 4, "Mario" },
			{ 5, "Mario" },
			{ 6, "Mario" },
			{ 7, "Mario" },
			{ 8, "Mario" },
			{ 9, "Mario" },
			{ 10, "Mario" },
			{ 11, "Mario" },
			{ 12, "Mario" },
			{ 13, "Mario" },
			{ 14, "Mario" },
			{ 15, "Mario" },
			{ 16, "Mario" },
			{ 17, "Mario" },
			{ 18, "Mario" },
			{ 19, "Mario" },
			{ 20, "Mario" },
		};

		public static TiledMap CurrentLevel { get; private set; } = MapLoader.Load(Levels[CurrentLevelNumber]);
		public static readonly TiledMap Logo = MapLoader.Load("Logo");

		public static void NextLevel()
		{
			if (CanNextLevel())
			{
				string levelName = Levels[++CurrentLevelNumber];

				CurrentLevel = MapLoader.Load(levelName);
			}
		}

		public static bool CanNextLevel()
		{
			if (CurrentLevelNumber > Levels.Count - 1)
			{
				return false;
			}

			return true;
		}
	}
}
