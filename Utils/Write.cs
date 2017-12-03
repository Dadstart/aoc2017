using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Write
    {
		public static void ColorLine(string output, ConsoleColor? foreground, ConsoleColor? background = null)
		{
			Color(output, foreground, background);
			Console.WriteLine();
		}

		public static void Color(string output, ConsoleColor? foreground, ConsoleColor? background = null)
		{
			// save current values
			var prevFore = Console.ForegroundColor;
			var prevBack = Console.BackgroundColor;

			// make changes
			if (foreground.HasValue)
			{
				Console.ForegroundColor = foreground.Value;
			}
			if (background.HasValue)
			{
				Console.BackgroundColor = background.Value;
			}

			// write output
			Console.Write(output);

			// restore
			Console.ForegroundColor = prevFore;
			Console.BackgroundColor = prevBack;
		}
	}
}
