using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

namespace ApoProject
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Fields

        private Animator _animator;

        int _hpEnemy = 100;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
                transform.LookAt(other.transform);
                _animator.SetBool("walk", true);
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetBool("walk", false);
            }
        }

        #endregion



        //#region MyMethods



        //public void OnHit(int damage)
        //{
        //    _hpEnemy -= damage;
        //    _animator.SetBool("hit", true);

        //    if (_hpEnemy <= 0) Destroy(gameObject);
        //}

        //#endregion
    }
}
