using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public class TestData<TInput, TOutput>
	{
		public readonly TInput Input;
		public readonly TOutput Output;

		public TestData(TInput input, TOutput output)
		{
			Input = input;
			Output = output;
		}
	}
}
