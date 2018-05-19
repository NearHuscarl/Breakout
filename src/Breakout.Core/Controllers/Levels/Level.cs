using Breakout.Core.Models.Maps;

namespace Breakout.Core.Controllers.Levels
{
	public class Level
	{
		public int Number { get; private set; }
		public string Name { get; private set; }
		public BlockMap Map { get; set; }

		public Level(int number, string name)
		{
			Number = number;
			Name = name;
		}
	}
}
