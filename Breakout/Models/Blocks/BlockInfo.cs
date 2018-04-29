using Breakout.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Blocks
{
	public static class BlockInfo
	{
		public static Dictionary<BlockType, int> Health = new Dictionary<BlockType, int>()
		{
			{ BlockType.Red, 100 },
			{ BlockType.Orange, 90 },
			{ BlockType.Yellow, 80 },
			{ BlockType.Green, 70 },
			{ BlockType.Blue, 60 },
			{ BlockType.Cyan, 50 },
			{ BlockType.Magenta, 40 },
		};

		public static Dictionary<BlockType, int> PowerUpSpawnChance = new Dictionary<BlockType, int>()
		{
			{ BlockType.Red, 30 },
			{ BlockType.Orange, 20 },
			{ BlockType.Yellow, 15 },
			{ BlockType.Green, 10 },
			{ BlockType.Blue, 8 },
			{ BlockType.Cyan, 5 },
			{ BlockType.Magenta, 2 },
		};
	}
}
