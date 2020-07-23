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
        [SerializeField] private GameObject[] _ui;
        [SerializeField] private Transform _spawnPos;
        [SerializeField] private Transform _grenadePos;
        [SerializeField] private int _grenadeCount = 0;
        [SerializeField] private int _mineCount = 0;
        [SerializeField] private int _turretCount = 0;

        #endregion


        #region UnityMethods

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
        }

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Mine"))
            {
                _mineCount = 10;
                _ui[2].GetComponent<Text>().text = _mineCount.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Turret"))
            {
                _turretCount = 10;
                _ui[0].GetComponent<Text>().text = _turretCount.ToString();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Grenade"))
            {
                _grenadeCount = 10;
                _ui[1].GetComponent<Text>().text = _grenadeCount.ToString();
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}
