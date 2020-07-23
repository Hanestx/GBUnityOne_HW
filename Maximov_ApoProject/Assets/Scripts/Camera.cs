using UnityEngine;

namespace ApoProject 
{
    public class Camera : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _target;

        #endregion


        #region UnityMethods

        private void FixedUpdate()
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, _target.localPosition, 5f * Time.deltaTime);
        }

        #endregion
    }
}