using System;
using Utils;

namespace Day3
{
    class Program
    {
		const string Input = "347991";
        static void Main(string[] args)
        {
			Part1(Input);
            Console.ReadLine();
        }

		private static void Part1(string input)
		{
			/*
			Each square on the grid is allocated in a spiral pattern starting at a location
			marked 1 and then counting up while spiraling outward. For example, the first
			few squares are allocated like this:

			17  16  15  14  13
			18   5   4   3  12
			19   6   1   2  11
			20   7   8   9  10
			21  22  23---> ...
			While this is very space-efficient (no squares are skipped), requested data
			must be carried back to square 1 (the location of the only access port for this
			memory system) by programs that can only move up, down, left, or right. They
			always take the shortest path: the Manhattan Distance between the location of
			the data and square 1.

			For example:

			Data from square 1 is carried 0 steps, since it's at the access port.
			Data from square 12 is carried 3 steps, such as: down, left, left.
			Data from square 23 is carried only 2 steps: up twice.
			Data from square 1024 must be carried 31 steps.

			How many steps are required to carry the data from the square identified in
			your puzzle input all the way to the access port?
 			*/
			Test.Verify<string, int>(Part1Calc, "1", 0);
			Test.Verify<string, int>(Part1Calc, "12", 3);
			Test.Verify<string, int>(Part1Calc, "23", 2);
			Test.Verify<string, int>(Part1Calc, "1024", 31);
			var answer = Part1Calc(Input);
			Console.WriteLine(answer);
		}

		static int Part1Calc(string input)
		{
			int start = int.Parse(input);

			// determine size (height and width are the same)
			int size = (int)Math.Ceiling(Math.Sqrt(start));
			if (IsEven(size))
			{
				// size is always odd
				size++;
			}

			int size0 = size - 1;
			int hPos = -1;
			int vPos = -1;
			
			// get box coordinates
			int bottomRight = size * size;
			int bottomLeft = size * size - size0;
			int topLeft = size * size - size0 * 2;
			int topRight = size * size - size0 * 3;

			if (InRangeInclusive(start, bottomLeft, bottomRight))
			{
				hPos = bottomRight - start;
				vPos = size0;
			}
			else if (InRangeInclusive(start, topLeft, bottomLeft))
			{
				hPos = 0;
				vPos = bottomLeft - start;
			}
			else if (InRangeInclusive(start, topRight, topLeft))
			{
				vPos = 0;
				hPos = topLeft - start;
			}
			else
			{
				// right side
				hPos = size0;
				vPos = topRight - start;
			}

			int hMov = Math.Abs((size0 / 2) - hPos);
			int vMov = Math.Abs((size0 / 2) - vPos);

			var result = hMov + vMov;
			Console.WriteLine(result);
			return result;

		}

		static bool IsEven(int i)
		{
			Math.DivRem(i, 2, out int rem);
			return rem == 0;
		}

		static bool InRangeInclusive(int val, int min, int max)
		{
			return (val >= min) && (val <= max);
		}
	}
}
