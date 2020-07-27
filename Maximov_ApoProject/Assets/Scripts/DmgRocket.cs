using UnityEngine;

namespace ApoProject
{
    public class DmgRocket : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speedBullet;
        [SerializeField] private float _lifetimeBullet;

        private EnemyTest _enemy;
        private Rigidbody _rigidbody;
        private int _damage = 50;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            var impulse = transform.forward * _rigidbody.mass * _speedBullet;
            _rigidbody.AddForce(impulse * _speedBullet, ForceMode.Impulse);

            Destroy(gameObject, _lifetimeBullet);
        }

        #endregion


        #region OnTrigger

        private void OnCollisionEnter(Collision collision)
        {
            _enemy = collision.gameObject.GetComponent<EnemyTest>();

            if (_enemy)
            {
                _enemy.OnHit(_damage);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}