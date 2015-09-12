using GridGame;
using UnityEngine;
using System;
using System.Collections;

public class line_actions : MonoBehaviour {


	private Camera myCam;
	private Vector3 moving_edge, station_edge;
	private Quaternion stabilize;
	private float angleOffset;
	private int x = 0;
	
	void Start () {
		myCam=Camera.main;
	}

	void OnMouseDown() {
		stabilize = this.transform.rotation;
		moving_edge = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		moving_edge.z = 0;
		station_edge = this.transform.position;

	
	}
	
	void OnMouseDrag () {
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;
		transform.rotation = Quaternion.FromToRotation(moving_edge - station_edge, mouse - station_edge) * stabilize;

		Debug.Log ("Origiinal z-rotation:" + stabilize.eulerAngles.z);
		Debug.Log ("\tCurrent mouse: " + mouse.x + ", " + mouse.y + ", " + mouse.z);
		Debug.Log ("\tOriginal mouse: " + moving_edge.x + ", " + moving_edge.y);
		Debug.Log ("\tPivot point: " + station_edge.x + ", " + station_edge.y);

		//transform.Rotate (new Vector3 (0, 0, Input.GetAxis ("Mouse Y" )));
	}

	void OnMouseUp() {
		Cursor.visible = true;
		x = 0;
	}
}