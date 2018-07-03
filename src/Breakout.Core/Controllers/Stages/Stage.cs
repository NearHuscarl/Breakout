using Breakout.Core.Models.Maps;
using Breakout.Pipeline.TiledMap;
using Breakout.Core.Views.Loaders;
using System.Collections.Generic;

namespace Breakout.Core.Controllers.Levels
{
	public class Stage
	{
		private int number = 0;

		public readonly Dictionary<int, string> Levels = new Dictionary<int, string>()
		{
			{ 0, "Menu" },
			{ 1, "Quick" },
			{ 2, "Quick2" },
			{ 3, "Mario" },
			// { 4, "Mario" },
			// { 5, "Mario" },
			// { 6, "Mario" },
			// { 7, "Mario" },
			// { 8, "Mario" },
			// { 9, "Mario" },
			// { 10, "Mario" },
			// { 11, "Mario" },
			// { 12, "Mario" },
			// { 13, "Mario" },
			// { 14, "Mario" },
			// { 15, "Mario" },
			// { 16, "Mario" },
			// { 17, "Mario" },
			// { 18, "Mario" },
			// { 19, "Mario" },
			// { 20, "Mario" },
		};

		public int Number
		{
			get { return number; }

			set
			{
				if (value != 0)
					CurrentLevel = value;

				number = value;
			}
		}

		public int CurrentLevel { get; set; }
		public string Name
		{
			get
			{
				return Levels[Number];
			}
		}

		public void SetLevel(int number=-1)
		{
			if (number == -1)
				Number = CurrentLevel;
			else
				Number = number;
		}

		public void NextLevel()
		{
			if (CanNextLevel())
			{
				Number++;
			}
		}

		public bool CanNextLevel()
		{
			if (Number > Levels.Count - 1)
			{
				return false;
			}

			return true;
		}
	}
}
