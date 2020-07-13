using System;
using UnityEngine;

public class EnemySpawnGo : MonoBehaviour
{
	[SerializeField] private float _speed;
 

	#region UnityMethods

	void Start()
	{
		Destroy(gameObject, 12f);
	}

	void Update() // Передвижение врагов вперёд
	{
		transform.Translate(Vector3.forward * Time.deltaTime * _speed);
	}

	#endregion
}
