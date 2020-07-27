using UnityEngine;

namespace ApoProject
{
    public class DmgGrenade : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ParticleSystem _particleBoom;
        [SerializeField] private AudioClip _boomSFX;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _lifetimeBullet;
        [SerializeField] private float _speedBullet;

        private Rigidbody _rigidbody;
        private int _damage = 50;
        private bool _isTimer;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            Destroy(gameObject, _lifetimeBullet);

            var impulse = transform.forward * _rigidbody.mass * _speedBullet;
            _rigidbody.AddForce(impulse * _speedBullet, ForceMode.Impulse);
        }

        #endregion


        #region OnTrigger

        private void OnTriggerEnter(Collider other)
        {
            _isTimer = true;

            other.GetComponent<Rigidbody>().AddExplosionForce(200f, transform.position, 300f);

            EnemyTest enemyTest = other.gameObject.GetComponent<EnemyTest>();
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy) enemy.OnHit(_damage);

            if (enemyTest)
            {
                enemyTest.OnHit(_damage);
            }



        }

        #endregion


    }
}