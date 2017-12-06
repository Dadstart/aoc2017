using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Day5
{
	class Program
	{
		static void Main(string[] args)
		{
			Write.ColorLine("Day 5: Part 1", ConsoleColor.Cyan);
			Console.WriteLine("-------", ConsoleColor.Cyan);
			Part1();
			Console.WriteLine();

			Write.ColorLine("Day 5: Part 1", ConsoleColor.Cyan);
			Console.WriteLine("-------", ConsoleColor.Cyan);
			Part2(Input.Value);
			Console.ReadLine();
		}

		private static void Part1()
		{
			/*
			The message includes a list of the offsets for each jump. Jumps are
			relative: -1 moves to the previous instruction, and 2 skips the next
			one. Start at the first instruction in the list. The goal is to
			follow the jumps until one leads outside the list.

			In addition, these instructions are a little strange; after each jump,
			the offset of that instruction increases by 1. So, if you come across
			an offset of 3, you would move three instructions forward, but change
			it to a 4 for the next time it is encountered.

			For example, consider the following list of jump offsets:
				0
				3
				0
				1
				-3

			Positive jumps ("forward") move downward; negative jumps move upward.
			For legibility in this example, these offset values will be written all
			on one line, with the current instruction marked in parentheses. The
			following steps would be taken before an exit is found:

				(0)  3   0   1   -3  - before we have taken any steps.

				(1)  3   0   1   -3  - jump with offset 0 (that is, don't jump at all).
				                       Fortunately, the instruction is then incremented
				                       to 1.

				2   (3)  0   1   -3  - step forward because of the instruction we just
				                       modified. The first instruction is incremented
									   again, now to 2.

				2    4   0   1  (-3) - jump all the way to the end; leave a 4 behind.

				2   (4)  0   1   -2  - go back to where we just were; increment -3 to -2.

				2    5   0   1   -2  - jump 4 steps forward, escaping the maze.

			In this example, the exit is reached in 5 steps.

			How many steps does it take to reach the exit?
			*/

			Test.Verify<string, int>(Traverse, Input.Part1Test1Input, Input.Part1Test1Answer);
			var result = Traverse(Input.Value);
			Write.ColorLine($"Result: {result}", ConsoleColor.Cyan);

		}

		private static int Traverse(string input)
		{
			using (var offsets = new DelayParsedStringArray(input))
			{
				int i = 0;
				int count = 0;
				while (true)
				{
					if (!offsets.GetItem(i, out int offset))
					{
						return count;
					}

					offsets.SetItem(i, offset + 1);
					i += offset;
					count++;
				}
			}
		}

		private static IList<int> ParseInput(string input)
		{
			List<int> list = new List<int>();
			using (var sr = new StringReader(input))
			{
				while (true)
				{
					var line = sr.ReadLine();
					if (line == null)
					{
						break;
					}

					list.Add(int.Parse(line));
				}
			}

			return list;
		}

		private static void Part2(string value)
		{
		}
	}
}
