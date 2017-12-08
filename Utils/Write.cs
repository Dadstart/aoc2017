using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Write
    {
		public static void ColorLine(string output, ConsoleColor? foreground, ConsoleColor? background = null, bool fillLine = false)
		{
			Color(output, foreground, background, true /*fillLine*/);
			Console.WriteLine();
		}

		public static void Color(string output, ConsoleColor? foreground, ConsoleColor? background = null, bool fillLine = false)
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

			// pad right if fillLine is set
			if (fillLine)
			{
				output = output.PadRight(Console.WindowWidth - 1);
			}

			// write output
			Console.Write(output);

			// restore
			Console.ForegroundColor = prevFore;
			Console.BackgroundColor = prevBack;
		}
	}
}
