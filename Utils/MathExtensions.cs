using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class MathExtensions
    {
		static bool InRangeInclusive(this int val, int min, int max)
		{
			return (val >= min) && (val <= max);
		}
	}
}
