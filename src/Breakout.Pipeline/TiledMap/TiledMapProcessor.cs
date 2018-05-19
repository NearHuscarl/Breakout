﻿using Microsoft.Xna.Framework.Content.Pipeline;

namespace Breakout.Pipeline.TiledMap
{
	[ContentProcessor(DisplayName = "Tiled Map Processor")]
	public class TiledMapProcessor : ContentProcessor<TiledMap, TiledMapProcessorResult>
	{
		public override TiledMapProcessorResult Process(TiledMap map, ContentProcessorContext context)
		{
			return new TiledMapProcessorResult(map, context.Logger);
		}
	}
}
