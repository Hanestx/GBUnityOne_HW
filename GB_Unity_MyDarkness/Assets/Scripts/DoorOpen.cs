using System;
using UnityEngine;

// Максимов Дмитрий
public class DoorOpen : MonoBehaviour
{
	[SerializeField] Transform _tp; // Телепорт

	public bool _isOpen; // Открыта ли дверь?

	public void Unlock()
	{
		_isOpen = true;
	}

	public void Teleport(GameObject player)
	{
		player.transform.position = _tp.transform.position;
	}
}
