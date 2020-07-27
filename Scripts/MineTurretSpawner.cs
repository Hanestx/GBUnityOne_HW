using UnityEngine;
using UnityEngine.UI;

namespace ApoProject
{
    public class MineTurretSpawner : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _grenade;
        [SerializeField] private GameObject _mine;
        [SerializeField] private GameObject _turret;
        [SerializeField] private GameObject _bulletAK47;
        [SerializeField] private GameObject _ak47;
        [SerializeField] private GameObject[] _ui;
        [SerializeField] private Transform _spawnPos;
        [SerializeField] private Transform _grenadePos;
        [SerializeField] private Transform _bulletPos;
        [SerializeField] private int _grenadeCount = 0;
        [SerializeField] private int _mineCount = 0;
        [SerializeField] private int _turretCount = 0;
        [SerializeField] private int _bulletAK47Count = 0;
        [SerializeField] private int _healthValue = 50;

        AudioSource _audioSource;
        [SerializeField] private AudioClip _getAK;
        [SerializeField] private AudioClip _getAmmo;
        [SerializeField] private AudioClip _getHealth;

        PlayerHP _playerHP;
        private int _playerHPInfo;
        private bool _isRateFire;
        bool _isAK;

        #endregion

        #region GetSet

        public bool IsAK { get { return _isAK; } }
        public int UI { set { _ui[4].GetComponent<Text>().text = value.ToString(); } }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _playerHP = GetComponent<PlayerHP>();
            _playerHPInfo = _playerHP.HpPlayerCurrent;
            _ui[4].GetComponent<Text>().text = _playerHPInfo.ToString();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X) && _mineCount > 0)
            {
               
                Instantiate(_mine, _spawnPos.position, _spawnPos.rotation);
                _mineCount--;
                _ui[2].GetComponent<Text>().text = _mineCount.ToString();
            }

            if (Input.GetKeyDown(KeyCode.C) && _turretCount > 0)
            {
                
                Instantiate(_turret, _spawnPos.position, _spawnPos.rotation);
                _turretCount--;
                _ui[0].GetComponent<Text>().text = _turretCount.ToString();
            }

            if (Input.GetKeyDown(KeyCode.G) && _grenadeCount > 0)
            {
                Instantiate(_grenade, _grenadePos.position, _grenadePos.rotation);
                _grenadeCount--;
                _ui[1].GetComponent<Text>().text = _grenadeCount.ToString();
            }

            if (Input.GetButton("Fire1") && _bulletAK47Count > 0 && _isAK)
            {
                Shoot();
            }
        }

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Mine"))
            {
                _mineCount = 5;
                _ui[2].GetComponent<Text>().text = _mineCount.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Turret"))
            {
               
                _turretCount = 5;
                _ui[0].GetComponent<Text>().text = _turretCount.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Grenade"))
            {
                _grenadeCount = 2;
                _ui[1].GetComponent<Text>().text = _grenadeCount.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("AK-47"))
            {
                _audioSource.PlayOneShot(_getAK);
                _isAK = true;
                _ak47.SetActive(true);
                _bulletAK47Count = 100;
                _ui[3].GetComponent<Text>().text = _bulletAK47Count.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ammo"))
            {
                _audioSource.PlayOneShot(_getAmmo);
                _bulletAK47Count += 100;
                _ui[3].GetComponent<Text>().text = _bulletAK47Count.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Health") && _playerHP.HpPlayerCurrent <= 150)
            {
                _audioSource.PlayOneShot(_getHealth);
                _playerHP.HealthPlus(_healthValue);
                _playerHPInfo += 50;

                _ui[4].GetComponent<Text>().text = _playerHPInfo.ToString();
                Destroy(other.gameObject);
            }
        }

        #endregion

        private void Shoot()
        {
            if (!_isRateFire)
            {
                Instantiate(_bulletAK47, _bulletPos.position, _bulletPos.rotation);
                _bulletAK47Count--;
                _ui[3].GetComponent<Text>().text = _bulletAK47Count.ToString();
                _isRateFire = true;
                Invoke("RateFire", 0.1f);
            }
        }

        private void RateFire()
        {
            _isRateFire = false;
        }
    }
}
