using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GridGame
{
	public class GridData
	{
		public const float NodeSpacing = 1;
		public const float XStart = 0;
		public const float YStart = 0;

		public static GridData Current;

		private GameObject gameObject;
		private Node[,] nodeArray;

		private LineArray horLines, vertLines;

		public GridData(int size, GameObject gameObject)
		{
			if (Current == null)
				Current = this;
			else
				throw new InvalidOperationException("Cannot have multiple main grids!");

			this.Size = size;
			nodeArray = new Node[Size,Size];
			this.gameObject = gameObject;

			horLines = new LineArray(size, size-1);
			vertLines = new LineArray(size-1, size);
		}

		public int Size { get; private set; }

		public static Vector3 IndexToVector(int xindex, int yindex)
		{
			return new Vector3(xindex*NodeSpacing + XStart, yindex*NodeSpacing + YStart);
		}

		public void AddLine(int xindex, int yindex, GameLine.LineDirection direction)
		{
			GameLine line = new GameLine(xindex, yindex, direction, gameObject.transform);

			if (direction == GameLine.LineDirection.Down)
				vertLines.SetLine(xindex, yindex, line);
			else if (direction == GameLine.LineDirection.Up)
				vertLines.SetLine(xindex, yindex - 1, line);
			else if (direction == GameLine.LineDirection.Left)
				vertLines.SetLine(xindex - 1, yindex, line);
			else
				vertLines.SetLine(xindex, yindex, line);
		}

		public void RotateLine(int xindex, int yindex, GameLine.LineDirection dirFrom, GameLine.LineDirection dirTo)
		{
			LineArray.RotateLine(horLines, vertLines, xindex, yindex, dirFrom, dirTo);
		}

		public void InitNodeArray()
		{
			for (int i=0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					nodeArray[i,j] = new Node(i, j, this.gameObject.transform);
				}
			}
		}
	}
}

