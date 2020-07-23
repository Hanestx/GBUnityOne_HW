using UnityEngine;

namespace ApoProject
{
    public class TurretPlayer : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _enemy;
        [SerializeField] private Transform _bulletSpawn;
        [SerializeField] private ParticleSystem _particleShot;
        [SerializeField] private AudioClip _shotSFX;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _damage;

        private bool _isReload;

        #endregion


        #region OnTrigger

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemy = other.gameObject;
                Shoot();
            }
        }

        #endregion


        #region MyMethods

        private void Shoot()
        {
            if (!_isReload)
            {
                transform.LookAt(_enemy.transform);
                Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);
                _audio.PlayOneShot(_shotSFX);
                _particleShot.Play();

                _isReload = true;

                Invoke("Reload", 2);
            }
        }

        private void Reload()
        {
            _isReload = false;
        }

        #endregion
    }
}