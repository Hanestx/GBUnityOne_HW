using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	#region Fields

	[SerializeField] private GameObject enemy;
	[SerializeField] private GameObject soundFX;
	[SerializeField] private Transform[] enemySpawnPos;

	#endregion


	#region OnTrigger

	void OnTriggerEnter(Collider collision) // Если коллайдер Player входит в триггер, появляются враги
	{
		if (collision.CompareTag("Player"))
		{
			soundFX.transform.GetChild(8).GetComponent<AudioSource>().Play();
			Destroy(gameObject);
			Instantiate<GameObject>(enemy, enemySpawnPos[0].position, enemySpawnPos[0].rotation);
			Instantiate<GameObject>(enemy, enemySpawnPos[1].position, enemySpawnPos[1].rotation);
			Instantiate<GameObject>(enemy, enemySpawnPos[2].position, enemySpawnPos[2].rotation);
			Instantiate<GameObject>(enemy, enemySpawnPos[3].position, enemySpawnPos[3].rotation);
		}
	}

	#endregion
}
