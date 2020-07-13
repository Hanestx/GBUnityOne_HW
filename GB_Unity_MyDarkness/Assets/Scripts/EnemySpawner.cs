using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] GameObject _enemy;

	[SerializeField] Transform[] _enemySpawnPos;

	[SerializeField] GameObject soundFX;

	void OnTriggerEnter(Collider collision) // Если коллайдер Player входит в триггер, появляются враги
	{
		if (collision.gameObject.tag == "Player")
		{
			soundFX.transform.GetChild(8).GetComponent<AudioSource>().Play();
			Destroy(base.gameObject);
			Instantiate<GameObject>(this._enemy, this._enemySpawnPos[0].position, this._enemySpawnPos[0].rotation);
			Instantiate<GameObject>(this._enemy, this._enemySpawnPos[1].position, this._enemySpawnPos[1].rotation);
			Instantiate<GameObject>(this._enemy, this._enemySpawnPos[2].position, this._enemySpawnPos[2].rotation);
			Instantiate<GameObject>(this._enemy, this._enemySpawnPos[3].position, this._enemySpawnPos[3].rotation);
		}
	}
}
