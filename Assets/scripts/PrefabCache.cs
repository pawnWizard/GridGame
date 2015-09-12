using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// This acts as a single spot to put all of the prefab references so they can be created easier.
/// </summary>
public class PrefabCache : MonoBehaviour
{
	public LineRenderer lineObject;
	public GameObject nodeObject;

	void Awake()
	{
		if (lineObject == null || nodeObject == null)
			throw new ArgumentNullException();

		GridGame.GameLine.SetPrefab(lineObject);
		GridGame.Node.SetPrefab(nodeObject);
	}
}

