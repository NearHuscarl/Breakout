using Breakout.Pipeline.TiledMap;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Breakout.Core.Utilities.Map
{
	internal class TiledMapReader : ContentTypeReader<TiledMap>
	{
		protected override TiledMap Read(ContentReader input, TiledMap existingInstance)
		{
			var tiledMap = new TiledMap
			{
				Layer0 = new List<List<string>>(),
				Layer1 = new List<List<string>>()
			};

			var layer0RowCount = input.ReadInt32();

			for (int i = 0; i < layer0RowCount; i++)
			{
				var layer0ColumnCount = input.ReadInt32();
				List<string> row = new List<string>();

				for (int j = 0; j < layer0ColumnCount; j++)
				{
					var column = input.ReadString();

					row.Add(column);
				}

				tiledMap.Layer0.Add(row);
			}

			var layer1RowCount = input.ReadInt32();

			for (int i = 0; i < layer1RowCount; i++)
			{
				var layer1ColumnCount = input.ReadInt32();
				List<string> row = new List<string>();

				for (int j = 0; j < layer1ColumnCount; j++)
				{
					var column = input.ReadString();

					row.Add(column);
				}

				tiledMap.Layer1.Add(row);
			}

			return tiledMap;
		}
	}
}
