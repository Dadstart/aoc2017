using System;

namespace Utils
{
    public static class Test
    {
		static int testCount;

		public static void VerifyAnswer(Func<string, int> solver, string input, int expected)
		{
			int val = solver(input);
			Console.WriteLine($"Test {++testCount}:");
			if (expected == val)
			{
				Write.Color("Pass", ConsoleColor.Green);
			}
			else
			{
				Write.Color("Fail", ConsoleColor.Red);
			}

			Console.WriteLine($": Expected: {expected}; Actual: {val}");
		}

		public static void Verify<TInput, TOutput>(Func<TInput, TOutput> solver, TInput input, TOutput expected)
		{
			TOutput val = solver(input);
			Console.WriteLine($"Test {++testCount}:");
			if (expected.Equals(val))
			{
				Write.Color("Pass", ConsoleColor.Green);
			}
			else
			{
				Write.Color("Fail", ConsoleColor.Red);
			}

			Console.WriteLine($": Expected: {expected}; Actual: {val}");
		}

		public static void Verify<TInput, TInputArgs, TOutput>(Func<TInput, TInputArgs, TOutput> solver, TInput input, TInputArgs inputArgs, TOutput expected)
		{
			TOutput val = solver(input, inputArgs);
			Console.WriteLine($"Test {++testCount}:");
			if (expected.Equals(val))
			{
				Write.Color("Pass", ConsoleColor.Green);
			}
			else
			{
				Write.Color("Fail", ConsoleColor.Red);
			}

			Console.WriteLine($": Expected: {expected}; Actual: {val}");
		}
	}
}
