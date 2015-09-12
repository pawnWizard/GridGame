using UnityEngine;
using System;

namespace GridGame
{
	public class GameLine
	{
		private static LineRenderer prefab;

		private LineRenderer lineRenderer;

		public GameLine(Vector3 start, Vector3 end)
		{
			this.lineRenderer = MonoBehaviour.Instantiate(prefab);
			lineRenderer.SetVertexCount(2);
			lineRenderer.SetPosition(0, start);
			lineRenderer.SetPosition(1, end);
			lineRenderer.SetWidth(0.1f, 0.1f);
		}

		public GameLine(int x1, int y1, int x2, int y2) 
			: this(new Vector3(x1, y1), new Vector3(x2, y2))
		{
		}

		public static void SetPrefab(LineRenderer renderer)
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

