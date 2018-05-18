using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Enums
{
	public enum BlockType
	{
		Red = 1, // strongest, more chance to spawn PowerUp
		Orange,
		Yellow,
		Green,
		Blue,
		Cyan,
		Magenta, // weakest, least chance to spawn PowerUp
		Gray,
		Black,

		LightRed,
		LightOrange,
		LightYellow,
		LightGreen,
		LightBlue,
		LightCyan,
		LightMagenta,
		LightGray,
		Dark,

		FlashingRed,
		FlashingOrange,
		FlashingYellow,
		FlashingGreen,
		FlashingBlue,
		FlashingCyan,
		FlashingMagenta,
		FlashingGray,
		FlashingBlack,

		Skeleton,
		None,
	}
}
