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
        private int _damage = 75;
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

        private void OnTriggerStay(Collider other)
        {
            _isTimer = true;

            other.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
            other.GetComponent<Rigidbody>().AddTorque(600f, 200f, 0f);

            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy)
            {
               // Boom();
                enemy.OnHit(_damage);
            }

            //else Boom();
        }

        #endregion


        #region MyMethods

        //void Boom()
        //{
        //    if (!_isTimer)
        //    {
        //        _audio.PlayOneShot(_boomSFX);
        //        _particleBoom.Play();

        //        _isTimer = true;

        //        Invoke("Timer", 3);
        //    }
        //}

        //void Timer()
        //{
        //    _isTimer = false;
        //}

        #endregion
    }
}