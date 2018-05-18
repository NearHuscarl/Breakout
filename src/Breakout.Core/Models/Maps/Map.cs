using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using System.Collections.Generic;

namespace Breakout.Models.Maps
{
	public class Map
	{
		public List<Block> Layer1 { get; set; }
		public List<GameObject> Layer0 { get; set; }
	}
}
