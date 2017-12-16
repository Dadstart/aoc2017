using System;
using System.Collections.Generic;
using System.Text;

namespace NextDays.Day13
{
	class Layer
	{
		// default to stepping forward
		private int stepDirection = 1;
		public int Range { get; }
		public int ScannerPosition { get; private set; }

		public Layer(int range)
		{
			Range = range;
		}

		public void Move()
		{
			var step = ScannerPosition + stepDirection;
			if (step < 0)
			{
				stepDirection = 1;
				ScannerPosition += stepDirection;
			}
			else if (step == Range)
			{
				stepDirection = -1;
				ScannerPosition += stepDirection;
			}
			else
			{
				ScannerPosition = step;
			}
		}

		public override string ToString()
		{
			return $"Pos {ScannerPosition}; Range {Range}";
		}
	}
}
