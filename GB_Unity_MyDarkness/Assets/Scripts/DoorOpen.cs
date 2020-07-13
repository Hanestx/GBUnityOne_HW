using System;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
	[SerializeField] private Transform _tp;

	public bool _isOpen;

	public void Unlock()
	{
		_isOpen = true;
	}

	public void Teleport(GameObject player)
	{
		player.transform.position = _tp.transform.position;
	}
}
