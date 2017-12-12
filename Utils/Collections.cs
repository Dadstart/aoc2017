using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Collections
    {
		public static void Sort<T>(this IList<T> collection, Func<T, T, int> comparer)
		{
			if (collection == null)
			{
				return;
			}

			for (int i = 0; i < collection.Count; i++)
			{
				for (int j = i + 1; j < collection.Count; j++)
				{
					if (comparer(collection[i], collection[j]) > 0)
					{
						var temp = collection[j];
						collection[j] = collection[i];
						collection[i] = temp;
					}
				}
			}

		}
	}
}
