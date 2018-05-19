namespace Breakout.Core.Models
{
	public class SpriteInfo
	{
		public static int BlockWidth { get; private set; }
		public static int BlockHeight { get; private set; }

		public static int PaddleHeight { get; private set; }

		public static int BallRadius { get; private set; }

		public static int PackageWidth { get; private set; }
		public static int PackageHeight { get; private set; }

		public SpriteInfo()
		{
			BlockWidth = 20;
			BlockHeight = 20;

			PaddleHeight = 17;

			BallRadius = 8;

			PackageWidth = 20;
			PackageHeight = 20;
		}
	}
}
