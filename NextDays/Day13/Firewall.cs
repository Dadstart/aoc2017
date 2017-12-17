using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NextDays.Day13
{
	class Firewall
	{
		SortedDictionary<int, Layer> layers = new SortedDictionary<int, Layer>();
		public int MaxDepth { get; private set; }

		private Firewall()
		{
		}

		private void AddLayer(int depth, int range)
		{
			layers.Add(depth, new Layer(range));
			MaxDepth = Math.Max(MaxDepth, depth);
		}

		public Layer this[int i]
		{
			get
			{
				if (layers.ContainsKey(i))
				{
					return layers[i];
				}
				else
				{
					return null;
				}
			}
		}

		public static Firewall Parse(string input)
		{
			var firewall = new Firewall();
			using (var sr = new StringReader(input))
			{
				char[] seps = { ' ', ':' };
				while (true)
				{
					var line = sr.ReadLine();
					if (line == null)
					{
						break;
					}

					var split = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);
					var depth = int.Parse(split[0]);
					var range = int.Parse(split[1]);
					firewall.AddLayer(depth, range);

				}
			}
			return firewall;
		}

		public void IterateBack(int count = -1)
		{
			while (count++ < 0)
			{
				foreach (var layer in layers)
				{
					layer.Value.Move(-1);
				}
			}
		}

		public void Iterate(int count = 1)
		{
			while (count-- > 0)
			{
				foreach (var layer in layers)
				{
					layer.Value.Move();
				}
			}
		}
	}
}
