using GridGame;
using UnityEngine;
using System;
using System.Collections;

public class line_actions : MonoBehaviour {


	private Camera myCam;
	private Vector3 moving_edge, station_edge;
	private Quaternion stabilize;
	private float angleOffset;
	
	void Start () {
		myCam=Camera.main;
	}

	void OnMouseDown() {

		float cx = Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
		cy = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;

		//Vertical lines
		if (((this.transform.position.x - 0.08) <= cx) && ((this.transform.position.x + 0.08) >= cx)) {
			if (cy > (this.transform.position.y - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);
				GridData.Current.FlipLine (this.transform.position.x, this.transform.position.y,
				                           this.transform.rotation.eulerAngles.z); 
			}
		}
		//Horizontal lines
		else {
			if (cx > (this.transform.position.x - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);
				GridData.Current.FlipLine (this.transform.position.x, this.transform.position.y,
				                           this.transform.rotation.eulerAngles.z); 
			}
		}
		stabilize = this.transform.rotation;
		station_edge = this.transform.position;
		moving_edge = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		moving_edge.z = 0;
	}
	
	void OnMouseDrag () {
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;
		transform.rotation = Quaternion.FromToRotation(moving_edge - station_edge, mouse - station_edge) * stabilize;

	}

	void OnMouseUp() {
	}
}