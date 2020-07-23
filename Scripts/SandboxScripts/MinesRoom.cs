using UnityEngine;


namespace ApoProject
{
    public class MinesRoom : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameObject _enemyBombSuicide;
        [SerializeField] GameObject _smallCircle;
        [SerializeField] GameObject _showTask;
        [SerializeField] Transform _enemyBombPos;
        [SerializeField] Transform _smallCirclePos;

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
            Instantiate(_enemyBombSuicide, _enemyBombPos.position, _enemyBombPos.rotation);
            Instantiate(_smallCircle, _smallCirclePos.position, _smallCirclePos.rotation);
            Invoke("CreateEnemyBomber", 5f);
            _showTask.SetActive(true);
            Destroy(_showTask, 8f);

        }

        #endregion
    }
}
