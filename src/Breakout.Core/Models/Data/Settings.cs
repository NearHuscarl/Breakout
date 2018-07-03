using Breakout.Core.Models.Enums;
using System.IO;

namespace Breakout.Core.Models.Data
{
	public class Settings : GameData
	{
		public static readonly string FullPath = Path.Combine(Directory, "settings.xml");

		public Difficulty Difficulty { get; set; }
		public bool IsMute { get; set; }

		public static Settings Default
		{
			get
			{
				return new Settings()
				{
					Difficulty = Difficulty.Normal,
					IsMute = false,
				};
			}
		}
	}
}
