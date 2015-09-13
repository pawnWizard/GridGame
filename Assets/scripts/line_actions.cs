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

		// Only rotate the line if it doesn't cause a break
	

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

		//snapping
		float angle_original;
		float angle_original_exact;
		float angle_current;
		float angle_current_exact;

		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;

		// previous angle
		Vector3 moving_edge_relative = moving_edge - station_edge;

		if (moving_edge_relative.x > 0) {
			angle_original = 180/Mathf.PI*Mathf.Atan (moving_edge_relative.y / moving_edge_relative.x);
		} else {
			angle_original = 180/Mathf.PI*Mathf.Atan (moving_edge_relative.y / moving_edge_relative.x) + 180;
		}
		Debug.Log ("angle_original " + angle_original);

		angle_original_exact = 90 * Mathf.Round (angle_original / 90);
		/*
		if(angle_original < 0){
			angle_original_exact = -90*Mathf.Floor(Mathf.Abs (angle_original/90));
		}else{
			angle_original_exact = 90*Mathf.Floor (angle_original/90);
		}
		Debug.Log ("angle_original_exact " + angle_original_exact);
		*/


		// current angle
		Vector3 mouse_relative = mouse - station_edge;
		Debug.Log ("mouse_relative.x " + mouse_relative.x);
		Debug.Log ("mouse_relative.y " + mouse_relative.y);

		if (mouse_relative.x > 0) {
			angle_current = 180/Mathf.PI*Mathf.Atan (mouse_relative.y / mouse_relative.x);
		} else {
			angle_current = 180/Mathf.PI*Mathf.Atan (mouse_relative.y / mouse_relative.x) + 180;
		}
		Debug.Log ("angle_current " + angle_current);

		Debug.Log ("angle_current % 90 " + angle_current % 90);
		
		if (Mathf.Min (angle_current % 90, 90 - (angle_current % 90)) < 10) {
			angle_current_exact = 90*Mathf.Round (angle_current/90);
			/*
			if (angle_current < 0) {
				angle_current_exact = -90 * Mathf.Floor (Mathf.Abs (angle_current / 90));
			} else {
				angle_current_exact = 90 * Mathf.Floor (angle_current / 90);
			}
			Debug.Log ("angle_current_exact" + angle_current_exact);
			*/
			transform.rotation = Quaternion.Euler (0, 0, angle_current_exact);
		}
		else{
				transform.rotation = Quaternion.Euler (0,0,angle_original_exact);
			}
		}



		/*
		Vector3 closest_node = new Vector3 (Mathf.Round (mouse.x), Mathf.Round (mouse.y), Mathf.Round (mouse.z));
		Vector3 offset = mouse - closest_node;

		if (offset.x < 0.3 || offset.y < 0.3) {
			transform.rotation = Quaternion.FromToRotation (moving_edge - station_edge, closest_node - station_edge) * stabilize;
		}
		else
			transform.rotation = Quaternion.FromToRotation (mouse - station_edge, moving_edge - station_edge) * stabilize;
	}
	*/
}