using System;
using System.IO;

namespace Breakout.Core.Models.Data
{
	public abstract class GameData
	{
		public static readonly string Directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
	}
}
