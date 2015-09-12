using GridGame;
using UnityEngine;
using System;
using System.Collections;

public class node_actions : MonoBehaviour
{
	public event Action Clicked;

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
	
}

