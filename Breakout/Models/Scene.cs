using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class Scene
	{
		public static Paddle paddle;
		public static List<Ball> balls;
		public static List<Block> blocks;

		public static void InitializeScense()
		{
			paddle = new Paddle();
			balls = new List<Ball>()
			{
				new Ball(),
			};
			InitializeBlocks();
		}

		public static void InitializeBlocks()
		{

		}
	}
}
