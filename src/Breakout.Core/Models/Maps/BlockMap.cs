using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Blocks;
using System.Collections.Generic;

namespace Breakout.Core.Models.Maps
{
	public class BlockMap
	{
		public List<Block> Layer1 { get; set; }
		public List<GameObject> Layer0 { get; set; }
	}
}
