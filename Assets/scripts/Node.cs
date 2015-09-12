using UnityEngine;
using System;

namespace GridGame
{
	public class Node
	{
		private static GameObject prefab;
		
		private GameObject nodeObject;

		public Node(int xindex, int yindex)
		{
			float xpos = xindex * GridData.NodeSpacing + GridData.XStart;
			float ypos = yindex * GridData.NodeSpacing + GridData.YStart;

			Vector3 position = new Vector3(xpos, ypos);
			this.nodeObject = MonoBehaviour.Instantiate(prefab, position, Quaternion.identity) as GameObject;
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

