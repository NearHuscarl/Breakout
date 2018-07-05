namespace Breakout.Core.Models
{
	public class SpriteData
	{
		public static int BlockWidth { get; private set; }
		public static int BlockHeight { get; private set; }

		public static int PaddleHeight { get; private set; }

		public static int PackageWidth { get; private set; }
		public static int PackageHeight { get; private set; }

		public SpriteData()
		{
			BlockWidth = 20;
			BlockHeight = 20;

			PaddleHeight = 17;

			PackageWidth = 25;
			PackageHeight = 25;
		}
	}
}
