using UnityEngine;

namespace ApoProject
{
    public class PlayerSuicide : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _tpPos;

        #endregion


        #region OnTriggers

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.position = _tpPos.position;
            }
        }

        #endregion
    }
}
