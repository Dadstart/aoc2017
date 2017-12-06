using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day5
{
	/// <summary>
	/// On-demand array read from a string of numbers that are CRLF delimited
	/// Why? Because I can!
	/// </summary>
	class DelayParsedStringArray : IDisposable
	{
		StringReader reader;
		List<int> memoryValues;
		private bool isDispoed = false;

		public DelayParsedStringArray(string values)
		{
			reader = new StringReader(values);
			memoryValues = new List<int>();
		}

		public bool GetItem(int index, out int item)
		{
			if (memoryValues.Count <= index)
			{
				// read to index
				var line = ReadToLine(index + 1);

				// if that line doesn't exist, bail out
				if (line <= index)
				{
					item = int.MinValue;
					return false;
				}
			}

			item = memoryValues[index];
			return true;
		}

		public void SetItem(int index, int val)
		{
			if (memoryValues.Count <= index)
			{
				ReadToLine(index);
			}

			memoryValues[index] = val;
		}

		/// <summary>
		/// Read to the specified line number
		/// </summary>
		/// <returns>Last line number read</returns>
		int ReadToLine(int lineNumber)
		{
			int currentLine = memoryValues.Count;
			while (currentLine < lineNumber)
			{
				string line = reader.ReadLine();
				if (line == null)
				{
					break;
				}

				int val = int.Parse(line);
				memoryValues.Add(val);
				currentLine++;
			}

			return currentLine;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDispoed)
			{
				if (disposing)
				{
					// dispose managed state
					reader?.Dispose();
					reader = null;
				}

				isDispoed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
	}
}
