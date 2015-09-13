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
		GameLine.LineDirection dir;

		float line_angle = this.transform.eulerAngles.z;
		switch((int)line_angle) {
		case 0:
			dir = GameLine.LineDirection.Right;
			break;
		case 90:
			dir = GameLine.LineDirection.Up;
			break;
		case 180:
			dir = GameLine.LineDirection.Left;
			break;
		case 270:
			dir = GameLine.LineDirection.Down;
			break;
		default:
			throw new InvalidOperationException();
		}

		//Vertical lines
		if (((this.transform.position.x - 0.08) <= cx) && ((this.transform.position.x + 0.08) >= cx)) {
			if (cy > (this.transform.position.y - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);

				GridData.Current.FlipLine ((int)this.transform.position.x, (int)this.transform.position.y, dir); 
			}
		}
		//Horizontal lines
		else {
			if (cx > (this.transform.position.x - (GridData.NodeSpacing / 2))) {
				transform.Rotate (new Vector3 (0, 0, 180));
				transform.Translate (-Vector3.right);
				GridData.Current.FlipLine ((int)this.transform.position.x, (int)this.transform.position.y, dir); 
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