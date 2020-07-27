using UnityEngine;


namespace ApoProject
{
    public class TriggerFinalBattle : MonoBehaviour
    {
        [SerializeField] Transform[] _enemyPos;
        [SerializeField] GameObject _enemy;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                for (byte i = 0; i < _enemyPos.Length; i++)
                Instantiate(_enemy, _enemyPos[i].position, _enemyPos[i].rotation);
                Destroy(gameObject);
            }
        }


    }
}
