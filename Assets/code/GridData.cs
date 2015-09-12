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

		private Node[,] nodeArray;

		public GridData(int size)
		{
			Size = size;

			nodeArray = new Node[size,size];
		}

		public int Size { get; private set; }

		public void Instantiate()
		{
			InitNodeArray();
		}

		public void AddLine(int x1, int y1, int x2, int y2)
		{
			throw new NotImplementedException();
		}

		private void InitNodeArray()
		{
			for (int i=0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					nodeArray[i,j] = new Node(i, j);
				}
			}
		}

	}
}

