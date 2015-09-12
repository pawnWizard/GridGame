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

		public GridData(int size, GameObject gameObject)
		{
			if (Current == null)
				Current = this;
			else
				throw new InvalidOperationException("Cannot have multiple main grids!");

			this.Size = size;
			nodeArray = new Node[Size,Size];
			this.gameObject = gameObject;
		}

		public int Size { get; private set; }

		public static Vector3 IndexToVector(int xindex, int yindex)
		{
			return new Vector3(xindex*NodeSpacing + XStart, yindex*NodeSpacing + YStart);
		}

		public void AddLine(int xindex, int yindex, GameLine.LineDirection direction)
		{
			//TODO: store these in an array
			new GameLine(xindex, yindex, direction, gameObject.transform);
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

