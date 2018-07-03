using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities;
using System;
using System.IO;

namespace Breakout.Core.Models.Data
{
	public class Settings : GameData
	{
		public static readonly string Path = System.IO.Path.Combine(Directory, "settings.xml");

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
