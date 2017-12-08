using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Runner
{
	public class ConsoleOutput : IOutput
	{
		public void BeginDay(int day)
		{
			Write.ColorLine(string.Empty, ConsoleColor.Blue, ConsoleColor.Gray, true /*fillLine*/);
			Write.ColorLine($"Day {day}", ConsoleColor.Blue, ConsoleColor.Gray, true /*fillLine*/);
			Write.ColorLine(string.Empty, ConsoleColor.Blue, ConsoleColor.Gray, true /*fillLine*/);
			Console.WriteLine();
		}

		public void BeginPart(int part)
		{
			Write.ColorLine($"Part {part}", ConsoleColor.Cyan);
		}

		public void BeginTest(int test)
		{
			Console.WriteLine($"Test {test}: ");
		}

		public void EndDay()
		{
			Console.WriteLine();
			Write.ColorLine(string.Empty, ConsoleColor.DarkGreen, ConsoleColor.Gray, true /*fillLine*/);
			Write.ColorLine("Press any key to exit", ConsoleColor.DarkGreen, ConsoleColor.Gray, true /*fillLine*/);
			Write.ColorLine(string.Empty, ConsoleColor.DarkGreen, ConsoleColor.Gray, true /*fillLine*/);
			Console.ReadKey(true /*intercept*/);
		}

		public void EndPart(object result)
		{
			Console.WriteLine($"Result: {result}");
		}

		public void EndTest(bool success, object result, object expected)
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
