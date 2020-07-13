using System;
using UnityEngine;


public class EnemySpawnGo : MonoBehaviour
{
	[SerializeField] private float _speed;

	void Start()
	{
		Destroy(gameObject, 12f);
	}

	void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * _speed);
	}
}
