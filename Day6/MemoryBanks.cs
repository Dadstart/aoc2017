using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Day6
{
	class MemoryBanks
	{
		private IList<int> store;
		private int largestBank;
		private int largestBankVal = int.MinValue;

		public MemoryBanks(string banks)
		{
			var values = banks.Split('\t', StringSplitOptions.RemoveEmptyEntries);
			store = new List<int>(values.Length);

			for (int i = 0; i < values.Length; i++)
			{
				var bankVal = int.Parse(values[i]);
				store.Add(bankVal);
				UpdateLargest(i);
			}
		}

		public void Distribute()
		{
			/*
			In each cycle, it finds the
			memory bank with the most blocks (ties won by the lowest-numbered memory
			bank) and redistributes those blocks among the banks. To do this, it
			removes all of the blocks from the selected bank, then moves to the next
			(by index) memory bank and inserts one of the blocks. It continues doing
			this until it runs out of blocks; if it reaches the last memory bank, it
			wraps around to the first one.
 			 */
			Debug.Assert(largestBankVal == store.Max());
			int blocks = largestBankVal;
			store[largestBank] = 0;
			var currentBank = largestBank;
			while (blocks > 0)
			{
				currentBank = GetNextIndex(currentBank);
				store[currentBank] += 1;
				UpdateLargest(currentBank);
			}
		}

		void UpdateLargest(int bank)
		{
			var val = store[bank];
			if (val > largestBankVal)
			{
				largestBank = bank;
				largestBankVal = val;
			}
		}

		int GetNextIndex(int index)
		{
			if (++index > store.Count)
			{
				index = 0;
			}
			return index;
		}

		public bool Equals(string banks)
		{
			var currentBanks = string.Join("\t", banks);
			return string.Equals(banks, currentBanks, StringComparison.Ordinal);
		}
	}
}
