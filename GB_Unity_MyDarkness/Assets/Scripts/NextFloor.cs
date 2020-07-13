using System;
using UnityEngine;

public class NextFloor : MonoBehaviour
{
	[SerializeField] Transform _tp;

	public void Teleport(GameObject player)
	{
		player.transform.position = _tp.transform.position;
	}
}
