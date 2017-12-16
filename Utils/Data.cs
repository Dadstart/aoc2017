using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public abstract class Data<TInput, TOutput> : IData<TInput, TOutput>
	{
		private List<TestData<TInput, TOutput>> part1Tests = new List<TestData<TInput, TOutput>>();
		private List<TestData<TInput, TOutput>> part2Tests = new List<TestData<TInput, TOutput>>();

		public abstract TInput Input { get; }

		public IEnumerable<TestData<TInput, TOutput>> Part1Tests => part1Tests;

		public IEnumerable<TestData<TInput, TOutput>> Part2Tests => part2Tests;

		protected void AddPart1TestCase(TInput input, TOutput output)
		{
			part1Tests.Add(new TestData<TInput, TOutput>(input, output));
		}

		protected void AddPart2TestCase(TInput input, TOutput output)
		{
			part2Tests.Add(new TestData<TInput, TOutput>(input, output));
		}
	}
}
