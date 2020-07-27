using UnityEngine;


namespace ApoProject 
{
    public class Door : MonoBehaviour
    {
        #region Fields

        public bool IsOpen;
        public bool IsLocked;

        [SerializeField] private float _openDoor;
        [SerializeField] private float _closeDoor;
        [SerializeField] private float _speed;

        #endregion


        #region UnityMethods

        void Update()
        {
            if (IsOpen) OpenDoor();
            else CloseDoor();
        }

        #endregion


        #region MyMethods

        private void OpenDoor()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, _openDoor, transform.rotation.z), _speed * Time.deltaTime);
        }

        private void CloseDoor()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, _closeDoor, transform.rotation.z), _speed * Time.deltaTime);
        }

        #endregion
    }
}
