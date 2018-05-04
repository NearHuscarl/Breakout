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
			{ BlockType.Red, 10 }, // One hit, make ball faster
			{ BlockType.Orange, 50 }, // Hardest block, 5 hits
			{ BlockType.Yellow, 40 },
			{ BlockType.Green, 10 }, // One hit, blow up surrounding when hit
			{ BlockType.Blue, 30 },
			{ BlockType.Cyan, 20 },
			{ BlockType.Magenta, 10 }, // Weakest Block, 1 hit
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
