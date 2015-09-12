using UnityEngine;
using System;
using System.Collections;

public class opening_function : MonoBehaviour {

	public LineRenderer renderer_obj;

	public GameObject node_obj;

	// Use this for initialization
	void Start () {
		if (renderer_obj == null || node_obj == null)
			throw new ArgumentNullException();

		Vector3 posA = new Vector3(2, 3);
		Vector3 posB = new Vector3(3, 3);
		Vector3 posC = new Vector3(2,2);
		Vector3 posD = new Vector3(3,2);
		Vector3 posE = new Vector3(2,1);
		Vector3 posF = new Vector3(3,1);

		/*CreateLine(new Vector3(2,3), new Vector3(3,3));
		CreateLine(new Vector3(2,3), new Vector3(2,2));
		CreateLine(new Vector3(2,2), new Vector3(3,2));
		CreateLine(new Vector3(2,2), new Vector3(2,1));
		CreateLine(new Vector3(3,2), new Vector3(3,1));*/

		CreateLine(posA, posB);
		CreateLine(posA, posC);
		CreateLine(posC, posD);
		CreateLine(posC, posE);
		CreateLine(posD, posF);

		CreateNode(posA);
		CreateNode(posB);
		CreateNode(posC);
		CreateNode(posD);
		CreateNode(posE);
		CreateNode(posF);
	}

	private void CreateLine(Vector3 start, Vector3 end)
	{
		LineRenderer r = Instantiate(renderer_obj);
		r.SetVertexCount(2);
		r.SetPosition(0, start);
		r.SetPosition(1, end);
		r.SetWidth (0.1f, 0.1f);
	}

	private void CreateNode(Vector3 position)
	{
		Instantiate(node_obj, position, Quaternion.identity);
	}
}
