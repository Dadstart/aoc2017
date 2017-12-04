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
			Part2(Input);
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

		static void Part2(string input)
		{
			/*
			As a stress test on the system, the programs here clear the grid and then store 
			the value 1in square 1. Then, in the same allocation order as shown above, 
			they store the sum of the values in all adjacent squares, including diagonals.

			So, the first few squares' values are chosen as follows:

			Square 1 starts with the value 1.
			Square 2 has only one adjacent filled square (with value 1), so it also stores 1.
			Square 3 has both of the above squares as neighbors and stores the sum of their values, 2.
			Square 4 has all three of the aforementioned squares as neighbors and stores the sum of their values, 4.
			Square 5 only has the first and fourth squares as neighbors, so it gets the value 5.

			Once a square is written, its value does not change.
			Therefore, the first few squares would receive the following values:

			147  142  133  122   59
			304    5    4    2   57
			330   10    1    1   54
			351   11   23   25   26
			362  747  806--->   ...

			What is the first value written that is larger than your puzzle input?
			*/

			int answer = SolvePart2(input);
			Console.WriteLine($"Answer: {answer}");
		}

		private static int SolvePart2(string input)
		{
			Table table = new Table(15);
			int val = int.Parse(input);
			return table.FindNextValue(val);
		}
	}
}
