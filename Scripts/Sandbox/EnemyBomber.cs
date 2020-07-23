using UnityEngine;


namespace ApoProject
{

    public class EnemyBomber : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _target;
        [SerializeField] private float _speed = 1;

        #endregion


        #region UnityMethods

        private void Start() 
        {
            Destroy(gameObject, 7f);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }

        #endregion
    }
}
