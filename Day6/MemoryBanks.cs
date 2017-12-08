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
		private List<string> storeHistory = new List<string>();

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
				DistributeIteration();
			} while (!previousStores.Contains(this.ToString()));
			return count;
		}

		private void DistributeIteration()
		{
			var current = this.ToString();
			storeHistory.Add(current);
			previousStores.Add(current);
			//			lastHit[current] = storeHistory.Count - 1;

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
		}

		private int LocateLoop()
		{
			int iSlow = -1, iFast = -1;
			do
			{
				DistributeIteration();
				DistributeIteration();
				iSlow += 1;
				iFast += 2;
			} while (!string.Equals(storeHistory[iSlow], storeHistory[iFast], StringComparison.Ordinal));

			return iSlow;
		}

		public int DetectLoop()
		{
			int loopPos = LocateLoop();
			int i = loopPos;
			int distance = 0;
			do
			{
				Distribute();
				i++;
				distance++;
			}
			while (!string.Equals(storeHistory[loopPos], storeHistory[i]));

			return distance;
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

		int GetNextIndex(int index, int offset = 1)
		{
			return (index + offset) % store.Count;
		}

		public override string ToString()
		{
			return string.Join(" ", store);
		}
	}
}
