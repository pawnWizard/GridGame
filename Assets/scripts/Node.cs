using UnityEngine;
using System;

namespace GridGame
{
	public class Node
	{
		private static GameObject prefab;
		
		private GameObject nodeObject;

		public Node(Vector3 position)
		{
			this.nodeObject = MonoBehaviour.Instantiate(prefab, position, Quaternion.identity) as GameObject;
		}

		public Node(float x, float y)
			: this(new Vector3(x,y))
		{
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

