using UnityEngine;

namespace ApoProject
{
    public class TurretRoom : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameObject _enemyTest;
        [SerializeField] GameObject _bigCircle;
        [SerializeField] GameObject _showTask;
        [SerializeField] Transform[] _enemyTestPos;
        [SerializeField] Transform _bigCirclePos;

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                CreateEnemyTest();
            }
        }

        #endregion


        #region MyMethods

        private void CreateEnemyTest()
        {
            Instantiate(_bigCircle, _bigCirclePos.position, _bigCirclePos.rotation);

            for (int i = 0; i < _enemyTestPos.Length; i++)
            {
                Instantiate(_enemyTest, _enemyTestPos[i].position, _enemyTestPos[i].rotation);

                _showTask.SetActive(true);
                Destroy(_showTask, 8f);
            }
        }

        #endregion
    }
}