using Breakout.Pipeline.TiledMap;

namespace Breakout.Core.Views.Loaders
{
	public static class MapLoader
	{
		private static readonly string mapPath = "Maps/";

		public static TiledMap Load(string mapName)
		{
			return EntryPoint.Game.Content.Load<TiledMap>(mapPath + mapName);
		}
	}
}
