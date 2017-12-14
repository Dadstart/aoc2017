using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
	public class NullOutput : IOutput
	{
		public void BeginDay(int day)
		{
		}

		public void BeginPart(int part)
		{
		}

		public void BeginTest(int test)
		{
		}

		public void EndDay()
		{
		}

		public void EndPart(object result)
		{
		}

		public void EndTest(bool success, object result, object expected)
		{
		}
	}
}
