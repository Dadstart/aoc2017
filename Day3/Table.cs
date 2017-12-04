using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
	class Table
	{
		readonly int size;
		readonly Point midpoint;
		readonly int[,] data;



		public Table(int size)
		{
			this.size = size;
			midpoint = new Point((this.size - 1) / 2, (this.size - 1) / 2);
			data = new int[this.size, this.size];

			// initialize table
			SetValue(midpoint, 1);
		}

		public int FindNextValue(int searchValue)
		{
			var cur = midpoint.Add(0, 0);

			// start to the right of midpoint
			cur.X++;

			for (var boxWidth = 3; boxWidth <= size; boxWidth = boxWidth + 2)
			{
				// get bounding coordinates
				int halfWidth0 = (boxWidth - 1) / 2;
				var xMax = midpoint.X + halfWidth0;
				var xMin = midpoint.X - halfWidth0;
				var yMax = midpoint.Y + halfWidth0;
				var yMin = midpoint.Y - halfWidth0;

				// go in counter-clockwise order

				// first one is always above bottom right
				int val = ValueForBottomRightUpOne(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// up right side until top right corner
				while (cur.Y > yMin + 1)
				{
					cur.Y--;
					val = ValueForRightEdge(cur);
					SetValue(cur, val);
					if (val > searchValue)
						return val;
				}

				// now top right corner
				cur.Y--;
				val = ValueForTopRight(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// left along top edge until top left corner
				while (cur.X > xMin + 1)
				{
					cur.X--;
					val = ValueForTopEdge(cur);
					SetValue(cur, val);
					if (val > searchValue)
						return val;
				}

				// top left corner
				cur.X--;
				val = ValueForTopLeft(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// down along left edge until bottom left
				while (cur.Y < yMax - 1)
				{
					cur.Y++;
					val = ValueForLeftEdge(cur);
					SetValue(cur, val);
					if (val > searchValue)
						return val;
				}

				// bottom left corner
				cur.Y++;
				val = ValueForBottomLeft(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// bottom left right one
				cur.X++;
				val = ValueForBottomLeftRightOne(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// right along bottom edge until bottom right corner
				while (cur.X < xMax - 1)
				{
					cur.X++;
					val = ValueForBottomEdge(cur);
					SetValue(cur, val);
					if (val > searchValue)
						return val;
				}

				// bottom right corner
				cur.X++;
				val = ValueForBottomRight(cur);
				SetValue(cur, val);
				if (val > searchValue)
					return val;

				// move right to start next box
				cur.X++;
			}

			return -1;
		}

		private Point GetTopRight(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(halfWidth0, -halfWidth0);
		}

		private int ValueForTopRight(Point p)
		{
			// (-1, 1) + (0, 1)
			int sum =
				GetValue(p, -1, 1)
				+ GetValue(p, 0, 1);

			return sum;
		}

		private Point GetBottomRightUpOne(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(halfWidth0, halfWidth0 - 1);
		}


		private int ValueForBottomRightUpOne(Point p)
		{
			// (-1,-1) + (-1,0)
			int sum =
				GetValue(p, -1, -1)
				+ GetValue(p, -1, 0);

			return sum;
		}

		private Point GetTopRightDownOne(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(halfWidth0, -halfWidth0 + 1);
		}

		private int ValueForTopRightDownOne(Point p)
		{
			// (-1,0) + (-1,-1) + (0,-1)
			int sum =
				GetValue(p, -1, 0)
				+ GetValue(p, -1, -1)
				+ GetValue(p, 0, -1);

			return sum;
		}

		private Point GetTopEdge(int boxWidth, int x)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(x, -halfWidth0);
		}

		private int ValueForTopEdge(Point p)
		{
			// (-1,1) + (0,1) + (1,1) + (1,0)						
			var sum =
				GetValue(p, -1, 1)
				+ GetValue(p, 0, 1)
				+ GetValue(p, 1, 1)
				+ GetValue(p, 1, 0);

			return sum;
		}

		private Point GetTopLeft(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(-halfWidth0, -halfWidth0);
		}

		private int ValueForTopLeft(Point p)
		{
			// (1,0) + (0,1) + (1,1)
			var sum =
				GetValue(p, 1, 0)
				+ GetValue(p, 0, 1)
				+ GetValue(p, 1, 1);

			return sum;
		}

		private Point GetLeftEdge(int boxWidth, int y)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(-halfWidth0, y);
		}

		private int ValueForLeftEdge(Point p)
		{
			// (0,-1) + (1,-1) + (1,0) + (1,1)
			var sum =
				GetValue(p, 0, -1)
				+ GetValue(p, 1, -1)
				+ GetValue(p, 1, 0)
				+ GetValue(p, 1, 1);

			return sum;
		}

		private Point GetBottomLeft(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(-halfWidth0, halfWidth0);
		}

		private int ValueForBottomLeft(Point p)
		{
			// (0,-1) + (1,-1)
			var sum =
				GetValue(p, 0, -1)
				+ GetValue(p, 1, -1);

			return sum;
		}

		private Point GetBottomLeftRightOne(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(-halfWidth0 + 1, halfWidth0);
		}

		private int ValueForBottomLeftRightOne(Point p)
		{
			// (-1,-1) + (0,-1) + (1,-1) + (-1,0)
			var sum =
				GetValue(p, -1, -1)
				+ GetValue(p, 0, -1)
				+ GetValue(p, 1, -1)
				+ GetValue(p, -1, 0);

			return sum;
		}

		private Point GetBottomEdge(int boxWidth, int x)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(x, halfWidth0);
		}

		private int ValueForBottomEdge(Point p)
		{
			// (-1,-1) + (0,-1) + (1,-1) + (-1,0)					
			var sum =
				GetValue(p, -1, -1)
				+ GetValue(p, 0, -1)
				+ GetValue(p, 1, -1)
				+ GetValue(p, -1, 0);

			return sum;
		}

		private Point GetBottomRight(int boxWidth)
		{
			int halfWidth0 = (boxWidth - 1) / 2;
			return midpoint.Add(halfWidth0, halfWidth0);
		}

		private int ValueForBottomRight(Point p)
		{
			// (-1,-1) + (0,-1) + (-1,0)
			var sum =
				GetValue(p, -1, -1)
				+ GetValue(p, 0, -1)
				+ GetValue(p, -1, 0);

			return sum;
		}

		private int ValueForRightEdge(Point p)
		{
			// (-1,1) + (-1,0) + (-1,-1) + (0,1)
			var sum =
				GetValue(p, -1, 1)
				+ GetValue(p, -1, 0)
				+ GetValue(p, -1, -1)
				+ GetValue(p, 0, 1);

			return sum;
		}

		public int GetValue(Point origin, int dx, int dy)
		{
			return data[origin.X + dx, origin.Y + dy];
		}


/*		public int GetValue(int x, int y)
		{
			return data[x, y];
		}*/

		public void SetValue(int x, int y, int val)
		{
			data[x, y] = val;
		}

		public void SetValue(Point p, int val)
		{
			data[p.X, p.Y] = val;
		}

	}

	struct Point
	{
		public int X;
		public int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point Add(int x, int y)
		{
			return new Point(X + x, Y + y);
		}

		public override string ToString()
		{
			return $"{X}, {Y}";
		}
	}
}
