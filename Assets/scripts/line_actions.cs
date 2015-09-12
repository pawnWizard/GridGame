using GridGame;
using UnityEngine;
using System;
using System.Collections;

public class line_actions : MonoBehaviour {


	private Camera myCam;
	private Vector3 screenPos;
	private float   angleOffset;
	private int x = 0;
	private Vector3 = 
	
	void Start () {
		myCam=Camera.main;
	}

	void OnMouseDown() {
		Cursor.visible = false;
	}
	
	void OnMouseDrag () {
		Vector3 mouse = Input.mousePosition;

		transform.Rotate (new Vector3 (0, 0, Input.GetAxis ("Mouse Y" )));
	}

	void OnMouseUp() {
		Cursor.visible = true;
		x = 0;
	}
}