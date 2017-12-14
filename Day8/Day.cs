using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Day8
{
	public class Day8 : IDay
	{
		public bool Part1(IOutput output)
		{
			/*
			Each instruction consists of several parts: the register to modify, whether
			to increase or decrease that register's value, the amount by which to
			increase or decrease it, and a condition. If the condition fails, skip the
			instruction without modifying the register. The registers all start at 0.
			The instructions look like this:

			b inc 5 if a > 1
			a inc 1 if b < 5
			c dec -10 if a >= 1
			c inc -20 if c == 10
			
			These instructions would be processed as follows:

			Because a starts at 0, it is not greater than 1, and so b is not modified.
			- a is increased by 1 (to 1) because b is less than 5 (it is 0).
			- c is decreased by -10 (to 10) because a is now greater than or equal to 1
			  (it is 1).
			- c is increased by -20 (to -10) because c is equal to 10.

			After this process, the largest value in any register is 1.

			You might also encounter <= (less than or equal to) or != (not equal to).
			However, the CPU doesn't have the bandwidth to tell you what all the
			registers are named, and leaves that to you to determine.

			What is the largest value in any register after completing the
			instructions in your puzzle input?
			 */

			output.BeginPart(1);
			//			Test.Verify<string, string>(output, SolvePart1, Input.Part1TestInput, Input.Part1TestAnswer);
			//			var bottom = SolvePart1(Input.Value);
			//			output.EndPart(bottom);
			return false;
		}

		int SolvePart1(string input)
		{
			return -1;
		}

		public bool Part2(IOutput output)
		{
			output.BeginPart(2);
			//			Test.Verify<string, int>(output, SolvePart2, Input.Part2TestInput, Input.Part2TestAnswer);
			//			var bottom = SolvePart2(Input.Value);
			//			output.EndPart(bottom);

			return false;
		}

		int SolvePart2(string input)
		{
			return 0;
		}
	}
}
