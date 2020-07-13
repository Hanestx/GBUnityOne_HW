using System;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject _enemy;

	[SerializeField] private Transform[] _enemySpawnPos;

	[SerializeField] private GameObject soundFX;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("Player"))
		{
			soundFX.transform.GetChild(8).GetComponent<AudioSource>().Play();
			Destroy(gameObject);
			Instantiate<GameObject>(_enemy, _enemySpawnPos[0].position, _enemySpawnPos[0].rotation);
			Instantiate<GameObject>(_enemy, _enemySpawnPos[1].position, _enemySpawnPos[1].rotation);
			Instantiate<GameObject>(_enemy, _enemySpawnPos[2].position, _enemySpawnPos[2].rotation);
			Instantiate<GameObject>(_enemy, _enemySpawnPos[3].position, _enemySpawnPos[3].rotation);
		}
	}
}
