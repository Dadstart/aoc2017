using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public static class StringExtensions
	{
		public static int ToDigitValue(this char c)
		{
			if ((c < '0') || (c > '9'))
			{
				throw new ArgumentOutOfRangeException();
			}

			return c - '0';
		}
		public static char CharAtCircular(this string str, int start, int distance)
		{
			var target = start + distance;
			if (target < str.Length)
			{
				return str[target];
			}
			else
			{
				target -= str.Length;
				return str[target];
			}
		}

	}
}
