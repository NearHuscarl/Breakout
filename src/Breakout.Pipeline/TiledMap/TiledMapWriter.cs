using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace Breakout.Pipeline.TiledMap
{
	[ContentTypeWriter]
	public class TiledMapWriter : ContentTypeWriter<TiledMapProcessorResult>
	{
		protected override void Write(ContentWriter output, TiledMapProcessorResult value)
		{
			output.Write(value.Map.Layer0.Count);

			foreach (var row in value.Map.Layer0)
			{
				output.Write(row.Count);

				foreach (var column in row)
				{
					output.Write(column);
				}
			}

			output.Write(value.Map.Layer1.Count);

			foreach (var row in value.Map.Layer1)
			{
				output.Write(row.Count);

				foreach (var column in row)
				{
					output.Write(column);
				}
			}
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return typeof(TiledMap).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return "Breakout.Core.Utilities.Map.TiledMapReader, Breakout";
		}
	}
}
