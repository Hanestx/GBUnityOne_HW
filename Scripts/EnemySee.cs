using UnityEngine;


namespace ApoProject
{
    public class EnemySee : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _target;
        private float _health = 10;

        #endregion


        #region UnityMetods
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            transform.LookAt(_target.transform);
            if (_health <= 0) Destroy(gameObject);
        }

        #endregion
    }
}
