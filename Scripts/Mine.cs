using UnityEngine;


namespace ApoProject
{
    public class Mine : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int _damage;

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
