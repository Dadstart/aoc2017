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
		private HashSet<string> previousStores = new HashSet<string>();

		public MemoryBanks(string banks)
		{
			var values = banks.Split('\t', StringSplitOptions.RemoveEmptyEntries);
			store = new List<int>(values.Length);

			for (int i = 0; i < values.Length; i++)
			{
				var bankVal = int.Parse(values[i]);
				store.Add(bankVal);
			}
			UpdateLargest();
		}

		public int Distribute()
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
			int count = 0;
			do
			{
				count++;
				previousStores.Add(this.ToString());
				int blocks = store[largestBank];
				Debug.Assert(blocks == store.Max());
				store[largestBank] = 0;
				var currentBank = largestBank;
				while (blocks-- > 0)
				{
					currentBank = GetNextIndex(currentBank);
					store[currentBank] += 1;
				}

				UpdateLargest();
			} while (!previousStores.Contains(this.ToString()));
			return count;
		}

		void UpdateLargest()
		{
			largestBank = 0;
			var largestVal = int.MinValue;
			for (var i = 0; i < store.Count; i++)
			{
				var val = store[i];
				if (val > largestVal)
				{
					largestBank = i;
					largestVal = val;
				}
			}
		}

		int GetNextIndex(int index)
		{
			if (++index >= store.Count)
			{
				index = 0;
			}
			return index;
		}

		public override string ToString()
		{
			return string.Join(" ", store);
		}
	}
}
