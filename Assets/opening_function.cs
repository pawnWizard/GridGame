using UnityEngine;
using System.Collections;

public class opening_function : MonoBehaviour {
	
	public Object line_object;
	// Use this for initialization
	void Start () {
		Instantiate (line_object, new Vector3 (0, 0, 0), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
