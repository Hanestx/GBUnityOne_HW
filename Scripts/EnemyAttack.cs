using System.Security;
using UnityEngine;
using UnityEngine.AI;

namespace ApoProject
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawn;
        [SerializeField] private Transform _rayPos;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float _distToPlayer = 7;
        [SerializeField] private float _distToHit;
        private bool _isReload;



        private void FixedUpdate()
        {
            Ray ray = new Ray(_rayPos.position, transform.forward);


            if (Physics.Raycast(ray, _distToPlayer, layerMask))
            {
                Shoot();
            }

        }


        private void Shoot()
        {
            if (!_isReload)
            {
                Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);

                _isReload = true;
                Invoke("Reload", 1);
            }
        }

        private void Reload()
        {
            _isReload = false;
        }
    }
}