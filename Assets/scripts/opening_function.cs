﻿using UnityEngine;
using System;
using System.Collections;
using GridGame;

public class opening_function : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 posA = new Vector3(2, 3);
		Vector3 posB = new Vector3(3, 3);
		Vector3 posC = new Vector3(2,2);
		Vector3 posD = new Vector3(3,2);
		Vector3 posE = new Vector3(2,1);
		Vector3 posF = new Vector3(3,1);

		GridData.Current.AddLine(2, 3, GameLine.LineDirection.Right);
		GridData.Current.AddLine(2, 3, GameLine.LineDirection.Down);
		GridData.Current.AddLine(2, 2, GameLine.LineDirection.Right);
		GridData.Current.AddLine(2, 2, GameLine.LineDirection.Down);
		GridData.Current.AddLine(3, 2, GameLine.LineDirection.Down);

	}

}
