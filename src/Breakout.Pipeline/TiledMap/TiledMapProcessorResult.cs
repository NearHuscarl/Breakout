using Microsoft.Xna.Framework.Content.Pipeline;

namespace Breakout.Pipeline.TiledMap
{
	public class TiledMapProcessorResult
	{
		public TiledMap Map;
		public ContentBuildLogger Logger;

		public TiledMapProcessorResult(TiledMap map, ContentBuildLogger logger)
		{
			Map = map;
			Logger = logger;
		}
	}
}
