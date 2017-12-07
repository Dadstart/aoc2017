using System;

namespace Utils
{
    public static class Test
    {
		static int testCount;

		public static void Verify<TInput, TOutput>(IOutput output, Func<TInput, TOutput> solver, TInput input, TOutput expected)
		{
			output.BeginTest(++testCount);
			TOutput val = solver(input);
			output.EndTest(expected.Equals(val), val, expected);
		}

		public static void Verify<TInput, TInputArgs, TOutput>(IOutput output, Func<TInput, TInputArgs, TOutput> solver, TInput input, TInputArgs inputArgs, TOutput expected)
		{
			output.BeginTest(++testCount);
			TOutput val = solver(input, inputArgs);
			output.EndTest(expected.Equals(val), val, expected);
		}
	}
}
