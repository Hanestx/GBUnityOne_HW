using UnityEngine;

namespace ApoProject
{
    public class EnemySuicide : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameObject _enemySuicide;
        [SerializeField] Transform _enemyPos;

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                CreateEnemyBomber();
            }
        }

        #endregion


        #region MyMethods

        private void CreateEnemyBomber()
        {
            Instantiate(_enemySuicide, _enemyPos.position, _enemyPos.rotation);
            Invoke("CreateEnemyBomber", 5f);
        }

        #endregion
    }
}
