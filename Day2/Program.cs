﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
	class Program
	{
		const string Input = @"5806	6444	1281	38	267	1835	223	4912	5995	230	4395	2986	6048	4719	216	1201
74	127	226	84	174	280	94	159	198	305	124	106	205	99	177	294
1332	52	54	655	56	170	843	707	1273	1163	89	23	43	1300	1383	1229
5653	236	1944	3807	5356	246	222	1999	4872	206	5265	5397	5220	5538	286	917
3512	3132	2826	3664	2814	549	3408	3384	142	120	160	114	1395	2074	1816	2357
100	2000	112	103	2122	113	92	522	1650	929	1281	2286	2259	1068	1089	651
646	490	297	60	424	234	48	491	245	523	229	189	174	627	441	598
2321	555	2413	2378	157	27	194	2512	117	140	2287	277	2635	1374	1496	1698
101	1177	104	89	542	2033	1724	1197	474	1041	1803	770	87	1869	1183	553
1393	92	105	1395	1000	85	391	1360	1529	1367	1063	688	642	102	999	638
4627	223	188	5529	2406	4980	2384	2024	4610	279	249	2331	4660	4350	3264	242
769	779	502	75	1105	53	55	931	1056	1195	65	292	1234	1164	678	1032
2554	75	4406	484	2285	226	5666	245	4972	3739	5185	1543	230	236	3621	5387
826	4028	4274	163	5303	4610	145	5779	157	4994	5053	186	5060	3082	2186	4882
588	345	67	286	743	54	802	776	29	44	107	63	303	372	41	810
128	2088	3422	111	3312	740	3024	1946	920	131	112	477	3386	2392	1108	2741";
		const string Part2TestInput = @"5 9 2 8
9 4 7 3
3 8 6 5";
		const int Part2TestAnswer = 9;
		static void Main(string[] args)
		{
			/*
			--- Day 2: Corruption Checksum ---
			http://adventofcode.com/2017/day/2

			The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

			For example, given the following spreadsheet:

			5 1 9 5
			7 5 3
			2 4 6 8
			- The first row's largest and smallest values are 9 and 1, and their difference is 8.
			- The second row's largest and smallest values are 7 and 3, and their difference is 4.
			- The third row's difference is 6.
			In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.
			*/
			var answer = CalculatChecksum(Input);
			Console.WriteLine($"Part 1 Solution: {answer}");
			Console.WriteLine();

			Console.WriteLine("Part 2 Test...");
			answer = Part2(Part2TestInput);
			Console.WriteLine(answer == Part2TestAnswer);

			answer = Part2(Input);
			Console.WriteLine($"Part 2 Solution: {answer}");
			Console.ReadLine();
		}

		static int CalculatChecksum(string input)
		{
			var total = 0;

			using (var sb = new StringReader(Input))
			{
				while (true)
				{
					var line = sb.ReadLine();
					if (line == null)
					{
						break;
					}

					var columnVals = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
					int min = int.MaxValue;
					int max = int.MinValue;

					foreach (string columnVal in columnVals)
					{
						var val = int.Parse(columnVal);
						if (val > max)
						{
							max = val;
						}
						if (val < min)
						{
							min = val;
						}
					}

					total += max - min;
				}
			}

			return total;
		}

		static int Part2(string input)
		{
			/*
			It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result.

			For example, given the following spreadsheet:

			5 9 2 8
			9 4 7 3
			3 8 6 5
			In the first row, the only two numbers that evenly divide are 8 and 2; the result of this division is 4.
			In the second row, the two numbers are 9 and 3; the result is 3.
			In the third row, the result is 2.
			In this example, the sum of the results would be 4 + 3 + 2 = 9.

			What is the sum of each row's result in your puzzle input?
			*/

			var total = 0;

			using (var sb = new StringReader(input))
			{
				while (true)
				{
					var line = sb.ReadLine();
					if (line == null)
					{
						break;
					}

					var vals = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
					int rem = 1;

					var rowResult = 0;

					for (int cur = 0; cur < vals.Length; cur++)
					{
						var val1 = int.Parse(vals[cur]);

						for (int next = cur + 1; next < vals.Length; next++)
						{
							var val2 = int.Parse(vals[next]);
							var div = Math.DivRem(val1, val2, out rem);
							if (rem == 0)
							{
								rowResult = div;
								break;
							}

							div = Math.DivRem(val2, val1, out rem);
							if (rem == 0)
							{
								rowResult = div;
								break;
							}

						}

						if (rowResult != 0)
						{
							total += rowResult;
							break;
						}
					}
				}
			}

			return total;
		}
	}
}
