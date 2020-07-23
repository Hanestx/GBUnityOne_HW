using UnityEngine;


namespace ApoProject
{
    public class ButtonDoor : MonoBehaviour
    {
        #region Fields

        [SerializeField] GameObject _wall;

        #endregion


        #region OnTriggers

        private void OnTriggerStay(Collider other) 
        {
            if (other.gameObject.CompareTag("Box"))
            {
                Destroy(_wall.gameObject);
            }
        }

        #endregion
    }
}
