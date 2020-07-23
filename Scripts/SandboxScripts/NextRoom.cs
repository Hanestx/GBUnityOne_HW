using UnityEngine;


namespace ApoProject
{
    public class NextRoom : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameObject _wall;

        #endregion


        #region OnTriggers

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(_wall.gameObject);
            }
        }

        #endregion
    }
}