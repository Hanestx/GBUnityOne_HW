using UnityEngine;

namespace ApoProject
{
    public class TurretEnemy : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawn;
        [SerializeField] private ParticleSystem _particleShot;
        [SerializeField] private AudioClip _shotSFX;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private float _damage;

        private bool _isReload;

        #endregion


        #region OnTrigger

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) _audio.Play();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transform.LookAt(other.transform);
                Shoot();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) _audio.Stop();
        }

        #endregion


        #region MyMethods

        private void Shoot()
        {
            if (!_isReload)
            {
                Instantiate(_bullet, _bulletSpawn.position, _bulletSpawn.rotation);

                _audio.PlayOneShot(_shotSFX);
                _particleShot.Play();

                _isReload = true;
                Invoke("Reload", 3);
            }
        }

        private void Reload()
        {
            _isReload = false;
        }

        #endregion
    }
}
