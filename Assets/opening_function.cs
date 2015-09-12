using UnityEngine;
using System.Collections;

public class opening_function : MonoBehaviour {
	
	//public Object line_object;
	public LineRenderer renderer;

	// Use this for initialization
	void Start () {
		/*
		Instantiate (line_object, new Vector3 (2, 0, 3), Quaternion.identity);
		Instantiate (line_object, new Vector3 (2, 0, 2), Quaternion.Euler(0,90,0));
		Instantiate (line_object, new Vector3 (2, 0, 2), Quaternion.identity);
		Instantiate (line_object, new Vector3 (2, 0, 1), Quaternion.Euler(0,90,0));
		Instantiate (line_object, new Vector3 (3, 0, 1), Quaternion.Euler(0,90,0));
		*/

		LineRenderer r = Instantiate(renderer) as LineRenderer;
		r.SetVertexCount(2);
		r.SetPosition(0, new Vector3 (2, 3, 0));
		r.SetPosition(1, new Vector3 (3, 3, 0));
		r.SetWidth (0.1f, 0.1f);

		r = Instantiate(renderer);
		r.SetVertexCount(2);
		r.SetPosition(0, new Vector3 (2, 3, 0));
		r.SetPosition(1, new Vector3 (2, 2, 0));
		r.SetWidth (0.1f, 0.1f);

		r = Instantiate(renderer);
		r.SetVertexCount(2);
		r.SetPosition(0, new Vector3 (2, 2, 0));
		r.SetPosition(1, new Vector3 (3, 2, 0));
		r.SetWidth (0.1f, 0.1f);

		r = Instantiate(renderer);
		r.SetVertexCount(2);
		r.SetPosition(0, new Vector3 (2, 2, 0));
		r.SetPosition(1, new Vector3 (2, 1, 0));
		r.SetWidth (0.1f, 0.1f);

		r = Instantiate(renderer);
		r.SetVertexCount(2);
		r.SetPosition(0, new Vector3 (3, 2, 0));
		r.SetPosition(1, new Vector3 (3, 1, 0));
		r.SetWidth (0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
