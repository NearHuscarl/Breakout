﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IBall
	{
		int Radius { get; set; }
		int Strength { get; set; }
		int Velocity { get; set; }
	}
}
