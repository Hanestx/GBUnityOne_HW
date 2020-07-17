using UnityEngine;


namespace MyDark
{
    public class EnemySpawner : MonoBehaviour
    {
	    #region Fields

	    [SerializeField] private GameObject enemy;
	    [SerializeField] private GameObject _soundFX;
	    [SerializeField] private Transform[] enemySpawnPos;

	    #endregion


	    #region OnTrigger

	    private void OnTriggerEnter(Collider collision)
	    {
		    if (collision.CompareTag("Player"))
		    {
				Play(8);
			    Destroy(gameObject);
			    Instantiate<GameObject>(enemy, enemySpawnPos[0].position, enemySpawnPos[0].rotation);
			    Instantiate<GameObject>(enemy, enemySpawnPos[1].position, enemySpawnPos[1].rotation);
			    Instantiate<GameObject>(enemy, enemySpawnPos[2].position, enemySpawnPos[2].rotation);
			    Instantiate<GameObject>(enemy, enemySpawnPos[3].position, enemySpawnPos[3].rotation);
	    	}
	    }

	    #endregion

		private void Play (int numSound)
        {
            _soundFX.transform.GetChild(numSound).GetComponent<AudioSource>().Play();
        }
    }
}
