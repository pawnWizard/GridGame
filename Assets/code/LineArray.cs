using UnityEngine;
using System;
using System.Collections;

namespace GridGame
{
	public class LineArray
	{
		private GameLine[,] lines;
		private int height, width;

		public LineArray(int height, int width)
		{
			lines = new GameLine[width, height];
		}

		public bool ExistsLine(int xindex, int yindex)
		{
			return lines[xindex, yindex] != null;
		}

		public void SetLine(int xindex, int yindex, GameLine line)
		{
			if (lines[xindex,yindex] != null)
				throw new InvalidOperationException("Cannot add a line: A line already exists in that location.");
			lines[xindex,yindex] = line;
		}

		public GameLine RemoveLine(int xindex, int yindex)
		{
			GameLine line = lines[xindex, yindex];
			lines[xindex, yindex] = null;
			return line;
		}

		/// <summary>
		/// 
		/// </summary>
		public static void RotateLine(LineArray horiz, LineArray vertical, int nodeX, int nodeY, 
		                              GameLine.LineDirection dirFrom, GameLine.LineDirection dirTo)
		{
			if (dirFrom == dirTo)
				return;

			GameLine line;
			if (dirFrom == GameLine.LineDirection.Down)
				line = vertical.RemoveLine(nodeX, nodeY);
			else if (dirFrom == GameLine.LineDirection.Left)
				line = horiz.RemoveLine(nodeX - 1, nodeY);
			else if (dirFrom == GameLine.LineDirection.Right)
				line = horiz.RemoveLine(nodeX, nodeY);
			else
				line = vertical.RemoveLine(nodeX, nodeY - 1);

			if (dirTo == GameLine.LineDirection.Down)
				vertical.SetLine(nodeX, nodeY, line);
			else if (dirTo == GameLine.LineDirection.Up)
				vertical.SetLine(nodeX, nodeY - 1, line);
			else if (dirTo == GameLine.LineDirection.Right)
				horiz.SetLine(nodeX, nodeY, line);
			else
				horiz.SetLine(nodeX - 1, nodeY, line);
		}
	}
}