using GridGame;
using UnityEngine;
using System;
using System.Collections;

public class node_actions : MonoBehaviour
{

	public event Action Clicked;
	private Vector3 screenPoint;
	private Vector3 offset;
	private float lockedYPosition;
	public static Vector3 scanPos;

	void BeginConnectScript(object sender)
	{
		Node node = sender as Node;
		node.ConnectScript(this);
	}

	void OnDestroy()
	{
		//Clear out the event to prevent issues
		Clicked = null;
	}

	void OnMouseDown() {
		//Causes centering. Delete, maybe?
		//screenPoint = Camera.main.WorldToScreenPoint (scanPos);
		lockedYPosition = screenPoint.y;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
			                                             Input.mousePosition.y, screenPoint.z));
		Cursor.visible = false;
	}
			                                
	void OnMouseDrag() {
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;				
	}

	void OnMouseUp() {
		Cursor.visible = true;
	}
}

