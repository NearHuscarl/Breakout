using Breakout.Core.Models.Maps;
using Breakout.Pipeline.TiledMap;
using Microsoft.Xna.Framework.Content;

namespace Breakout.Core.Utilities.Map
{
	internal static class MapLoader
	{
		private static BlockMapReader blockMapReader;
		private static readonly string mapPath = "Maps/";
		private static ContentManager content;

		public static void Initialize(ContentManager content)
		{
			MapLoader.content = content;
			MapLoader.blockMapReader = new BlockMapReader();
		}

		public static BlockMap Load(string mapName)
		{
			TiledMap tiledMap = content.Load<TiledMap>(mapPath + mapName);

			return blockMapReader.LoadGameObjects(tiledMap);
		}
	}
}
