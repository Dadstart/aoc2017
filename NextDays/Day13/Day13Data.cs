﻿using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace NextDays.Day13
{
	class Day13Data : Data<string, int>
	{
		public override string Input =>
@"0: 4
1: 2
2: 3
4: 5
6: 8
8: 4
10: 6
12: 6
14: 6
16: 10
18: 6
20: 12
22: 8
24: 9
26: 8
28: 8
30: 8
32: 12
34: 12
36: 12
38: 8
40: 10
42: 14
44: 12
46: 14
48: 12
50: 12
52: 12
54: 14
56: 14
58: 14
60: 12
62: 14
64: 14
68: 12
70: 14
74: 14
76: 14
78: 14
80: 17
82: 28
84: 18
86: 14";

		public Day13Data()
		{
			AddPart1TestCase(@"0: 3
1: 2
4: 4
6: 4", 24);
		}
	}
}