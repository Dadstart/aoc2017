using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public interface IData<TInput, TOutput>
	{
		TInput Input { get; }
		IEnumerable<TestData<TInput, TOutput>> Part1Tests { get; }
		IEnumerable<TestData<TInput, TOutput>> Part2Tests { get; }
	}
}
