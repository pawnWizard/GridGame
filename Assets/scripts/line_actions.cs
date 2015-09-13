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

		float line_angle = this.transform.eulerAngles.z;

		//Vertical lines
		if (((this.transform.position.x - 0.08) <= cx) && ((this.transform.position.x + 0.08) >= cx)) {
			if (cy > (this.transform.position.y - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);
			}
		}
		//Horizontal lines
		else {
			if (cx > (this.transform.position.x - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);
			}
		}
		stabilize = this.transform.rotation;
		station_edge = this.transform.position;
		moving_edge = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		moving_edge.z = 0;
	}
	
	void OnMouseDrag () {

		// Only rotate the line if it doesn't cause a break
	

		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;
		transform.rotation = Quaternion.FromToRotation(moving_edge - station_edge, mouse - station_edge) * stabilize;

	}

	void OnMouseUp() {
		Cursor.visible = true;
		//x = 0;

		//snapping
		float angle_original;
		float angle_original_exact;
		float angle_current;
		float angle_current_exact;

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouse.z = 0;

		// previous angle
		Vector3 moving_edge_relative = moving_edge - station_edge;

		if (moving_edge_relative.x > 0) {
			angle_original = 180 / Mathf.PI * Mathf.Atan (moving_edge_relative.y / moving_edge_relative.x);
		} else {
			angle_original = 180 / Mathf.PI * Mathf.Atan (moving_edge_relative.y / moving_edge_relative.x) + 180;
		}

		angle_original_exact = 90 * Mathf.Round (angle_original / 90);


		// current angle
		Vector3 mouse_relative = mouse - station_edge;

		if (mouse_relative.x > 0) {
			angle_current = 180 / Mathf.PI * Mathf.Atan (mouse_relative.y / mouse_relative.x);
		} else {
			angle_current = 180 / Mathf.PI * Mathf.Atan (mouse_relative.y / mouse_relative.x) + 180;
		}

		// Final snap!
		bool moved = false;
		if (Mathf.Min (angle_current % 90, 90 - (angle_current % 90)) < 40) {
			angle_current_exact = 90 * Mathf.Round (angle_current / 90);
			transform.rotation = Quaternion.Euler (0, 0, angle_current_exact);
			moved = true;
		} else {
			transform.rotation = Quaternion.Euler (0, 0, angle_original_exact);
		}
/*		if (moved) {
			int xindex, yindex;
			VectorToIndex (station_edge, xindex, yindex);
//
//			//	GridData.Current.RotateLine(xindex,yindex,GridGame.GameLine.LineDirection); 
		}*/
	}


}