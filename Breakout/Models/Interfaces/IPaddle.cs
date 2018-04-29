using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IPaddle
	{
		int Length { get; set; }
		float Velocity { get; set; }
	}
}
