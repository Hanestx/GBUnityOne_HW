using System;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
	#region Fields

	public bool _isOpen; // Открыта ли дверь?
	[SerializeField] private Transform _tp; // Телепорт

	#endregion


	#region UnityMethods

	public void Unlock()
	{
		_isOpen = true;
	}

	public void Teleport(GameObject player)
	{
		player.transform.position = _tp.transform.position;
	}

	#endregion
}
