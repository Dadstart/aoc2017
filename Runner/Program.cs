using System;
using Utils;

namespace Runner
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		static void Solve<TInput, TOutput> (INewDay<TInput, TOutput> day)
		{
			var output = new ConsoleOutput();
			var data = day.Data;
			output.BeginDay(day.Day);

			output.BeginPart(1);

			// part 1

			// test cases
			foreach (var testCase in data.Part1Tests)
			{
				Test.Verify<TInput, TOutput>(output, day.SolvePart1, testCase.Input, testCase.Output);
			}

			// actual problem
			var result1 = day.SolvePart1(data.Input);
			output.EndPart(result1);


			// part 2

			// test cases
			foreach (var testCase in data.Part2Tests)
			{
				Test.Verify<TInput, TOutput>(output, day.SolvePart2, testCase.Input, testCase.Output);
			}

			// actual problem
			var result2 = day.SolvePart1(data.Input);
			output.EndPart(result2);

			output.EndDay();
		}
	}
}
