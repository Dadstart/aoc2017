using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public interface IOutput
    {
		void EndDay();
		void BeginDay(int day);
		void BeginPart(int part);
		void EndPart(bool success, string result);
		void BeginTest(int test);
		void EndTest(bool success, object result, object expected);
	}
}
