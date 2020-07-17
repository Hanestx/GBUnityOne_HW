using System;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
	[SerializeField] private float x, y, z;

	void Update()
	{
		transform.Rotate(new Vector3(x, y, z));
	}
}
