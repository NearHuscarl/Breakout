using Breakout.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Maps
{
	public static class MapManager
	{
		private static readonly string mapDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maps");

		public static readonly Dictionary<char, BlockType> BlockMap = new Dictionary<char, BlockType>()
		{
			{ '0', BlockType.Black },
			{ '1', BlockType.Black },
			{ '2', BlockType.Gray },
			{ '3', BlockType.Gray },
			{ '4', BlockType.None },
			{ '5', BlockType.None },
			{ 'C', BlockType.Cyan },
			{ 'c', BlockType.Cyan },
			{ 'G', BlockType.Green },
			{ 'g', BlockType.Green },
			{ 'B', BlockType.Blue },
			{ 'b', BlockType.Blue },
			{ 'M', BlockType.Magenta },
			{ 'm', BlockType.Magenta },
			{ 'Y', BlockType.Yellow },
			{ 'y', BlockType.Yellow },
			{ 'O', BlockType.Orange },
			{ 'o', BlockType.Orange },
			{ 'R', BlockType.Red },
			{ 'r', BlockType.Red },
		};

		// 33 x 16
		public static Map CurrentMap { get; set; }

		public static void LoadMap(string mapName)
		{
			string mapPath = Path.Combine(mapDir, mapName + ".json");
			string jsonStr = File.ReadAllText(mapPath);

			CurrentMap = JsonConvert.DeserializeObject<Map>(jsonStr);
		}
	}
}
