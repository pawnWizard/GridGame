using UnityEngine;
using System;
using System.Collections;

public class opening_function : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 posA = new Vector3(2, 3);
		Vector3 posB = new Vector3(3, 3);
		Vector3 posC = new Vector3(2,2);
		Vector3 posD = new Vector3(3,2);
		Vector3 posE = new Vector3(2,1);
		Vector3 posF = new Vector3(3,1);

		new GridGame.GameLine(posA, posB);
		new GridGame.GameLine(posA, posC);
		new GridGame.GameLine(posC, posD);
		new GridGame.GameLine(posC, posE);
		new GridGame.GameLine(posD, posF);

		new GridGame.Node(posA);
		new GridGame.Node(posB);
		new GridGame.Node(posC);
		new GridGame.Node(posD);
		new GridGame.Node(posE);
		new GridGame.Node(posF);
	}

}
