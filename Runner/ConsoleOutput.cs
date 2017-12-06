﻿using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Runner
{
	public class ConsoleOutput : IOutput
	{
		public void BeginDay(int day)
		{
			Write.ColorLine($"Day {day}", ConsoleColor.Blue, ConsoleColor.Gray);
			Console.WriteLine();
		}

		public void BeginPart(int part)
		{
			Write.Color($"Part {part}", ConsoleColor.Cyan);
		}

		public void BeginTest(int test)
		{
			Console.WriteLine($"Test {test}: ");
		}

		public void EndDay()
		{
			Console.WriteLine();
			Console.WriteLine("Press any key to exit");
			Console.ReadKey(true /*intercept*/);
		}

		public void EndPart(bool success, string result)
		{
			if (success)
			{
				Write.ColorLine("Success", ConsoleColor.Green);
			}
			else
			{
				Write.ColorLine("Failed", ConsoleColor.Red);
			}

			Console.WriteLine($"Result: {result}");
		}

		public void EndTest(bool success, string result, string expected)
		{
			if (success)
			{
				Write.ColorLine("Success", ConsoleColor.Green);
			}
			else
			{
				Write.ColorLine("Failed", ConsoleColor.Red);
			}

			Console.WriteLine($"Result: {result}; Expected: {expected}");
		}
	}
}
