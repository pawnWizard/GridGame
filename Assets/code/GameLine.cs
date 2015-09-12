using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GridGame
{
	public class GameLine
	{
		public enum LineDirection { Left, Right, Up, Down };

		private static GameObject prefab;

		private static Dictionary<LineDirection, int> dirToDegrees = 
			new Dictionary<LineDirection, int>
		{
			{ LineDirection.Left, 180 },
			{ LineDirection.Right, 0 },
			{ LineDirection.Up, 90 },
			{ LineDirection.Down, 270 },
		};

		private GameObject lineObject;

		public GameLine(int xindex, int yindex, LineDirection direction, Transform parent)
		{
			Vector3 actualStart = GridData.IndexToVector(xindex, yindex);// + new Vector3(GridData.NodeSpacing / 2.0f, 0);
			int deg = dirToDegrees[direction];
			Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, deg));

			this.lineObject = MonoBehaviour.Instantiate(prefab, actualStart, rotation) as GameObject;
			this.lineObject.transform.SetParent(parent);
		}

		public static void SetPrefab(GameObject renderer)
		{
			if (renderer == null)
				throw new ArgumentNullException();

			//Not allowed to set it twice
			if (prefab != null)
				throw new InvalidOperationException();

			prefab = renderer;
		}
	}
}

