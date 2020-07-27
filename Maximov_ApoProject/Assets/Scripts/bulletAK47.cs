using UnityEngine;

namespace ApoProject
{
    public class bulletAK47 : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speedBullet;
        [SerializeField] private float _lifetimeBullet;

        private Enemy _enemy;
        private Rigidbody _rigidbody;
        private int _damage = 30;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            var impulse = transform.up * _speedBullet;
            _rigidbody.AddForce(impulse * _speedBullet, ForceMode.Impulse);

            Destroy(gameObject, _lifetimeBullet);
        }

        #endregion


        #region OnTrigger

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 300f);
            other.GetComponent<Rigidbody>().AddTorque(100f, 200f, 100f);
        }
        private void OnCollisionEnter(Collision collision)
        {
            _enemy = collision.gameObject.GetComponent<Enemy>();

            if (_enemy)
            {
                _enemy.OnHit(_damage);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}