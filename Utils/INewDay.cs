using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public interface INewDay<TInput, TOutput>
	{
		int Day { get; }
		IData<TInput, TOutput> Data { get; }
		TOutput SolvePart1(TInput input);
		TOutput SolvePart2(TInput input);
	}
}
