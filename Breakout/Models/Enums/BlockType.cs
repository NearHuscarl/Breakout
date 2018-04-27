using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Enums
{
	public enum BlockType
	{
		Red, // strongest, more chance to spawn PowerUp
		Orange,
		Yellow,
		Green,
		Blue,
		Cyan,
		Magenta, // weakest, lease chance to spawn (bad) PowerUp
	}
}
