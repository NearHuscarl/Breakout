using Microsoft.Xna.Framework.Content.Pipeline;
using Newtonsoft.Json;
using System.IO;

namespace Breakout.Pipeline.TiledMap
{
	[ContentImporter(".json", DefaultProcessor = "TiledMapProcessor", DisplayName = "Tiled Map Importer")]
	public class TiledMapImporter : ContentImporter<TiledMap>
	{
		public override TiledMap Import(string filename, ContentImporterContext context)
		{
			context.Logger.LogMessage("Importing JSON map: {0}", filename);

			using (var file = File.OpenText(filename))
			{
				var serializer = new JsonSerializer();
				var serializedMap = (TiledMap)serializer.Deserialize(file, typeof(TiledMap));

				return serializedMap;
			}
		}
	}
}
