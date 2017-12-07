using System;
using Utils;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
			var day = new Day6.Day6();
			var output = new ConsoleOutput();
			output.BeginDay(6);

			day.Part1(output);
			day.Part2(output);

			output.EndDay();
		}
    }
}
