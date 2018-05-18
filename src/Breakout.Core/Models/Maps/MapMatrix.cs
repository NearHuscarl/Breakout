using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Maps
{
	public class MapMatrix
	{
		public List<List<string>> Layer1 { get; set; }
		public List<List<string>> Layer0 { get; set; }
	}
}
