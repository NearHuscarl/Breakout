using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Enums
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
		Black,
		Gray,
		Silver,

		LightRed,
		LightOrange,
		LightYellow,
		LightGreen,
		LightBlue,
		LightCyan,
		LightMagenta,
		Dark,
		LightGray,
		White,

		FlashingRed,
		FlashingOrange,
		FlashingYellow,
		FlashingGreen,
		FlashingBlue,
		FlashingCyan,
		FlashingMagenta,
		FlashingBlack,
		FlashingGray,
		FlashingWhite,

		Skeleton,
		None,
	}
}
