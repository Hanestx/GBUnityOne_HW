using System;
using UnityEngine;

// Максимов Дмитрий
public class EnemySpawnGo : MonoBehaviour
{
	[SerializeField] float _speed;

	void Start()
	{
		Destroy(gameObject, 12f);
	}

	void Update() // Передвижение врагов вперёд
	{
		transform.Translate(Vector3.forward * Time.deltaTime * this._speed);
	}
}
