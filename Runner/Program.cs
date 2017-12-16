using System;
using Utils;
using NextDays;

namespace Runner
{
	class Program
	{
		static void Main(string[] args)
		{
			Solve(new NextDays.Day13.Day13());
		}

		static void Solve<TInput, TOutput> (INewDay<TInput, TOutput> day)
		{
			var output = new ConsoleOutput();
			var data = day.Data;
			output.BeginDay(day.Day);


			// part 1
			output.BeginPart(1);

			// test cases
			foreach (var testCase in data.Part1Tests)
			{
				Test.Verify<TInput, TOutput>(output, day.SolvePart1, testCase.Input, testCase.Output);
			}

			// actual problem
			var result1 = day.SolvePart1(data.Input);
			output.EndPart(result1);


			// part 2
			output.BeginPart(2);

			// test cases
			foreach (var testCase in data.Part2Tests)
			{
				Test.Verify<TInput, TOutput>(output, day.SolvePart2, testCase.Input, testCase.Output);
			}

			// actual problem
			var result2 = day.SolvePart2(data.Input);
			output.EndPart(result2);

			output.EndDay();
		}
	}
}
