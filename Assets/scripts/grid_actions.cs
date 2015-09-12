using GridGame;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class grid_actions : MonoBehaviour
{
	public int Size;

	private GridData data;

	void Awake()
	{
		data = new GridData(Size, this.gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		data.InitNodeArray();
	}
	

}

