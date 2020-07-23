using UnityEngine;
using UnityEngine.AI;

namespace ApoProject
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Transform _target;


        private void Update()
        {
            GetComponent<NavMeshAgent>().SetDestination(_target.position);
        }
    }
}