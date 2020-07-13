using System;
using UnityEngine;

// Максимов Дмитрий
public class RotateObj : MonoBehaviour
{
	[SerializeField] float x, y, z;

	void Update()
	{
		transform.Rotate(new Vector3(x, y, z)); // Поворот объекта вокруг своей оси
	}
}
