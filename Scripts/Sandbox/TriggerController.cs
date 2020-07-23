using UnityEngine;


namespace ApoProject 
{
    public class TriggerController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private bool _isKey;

        #endregion


        #region OnTriggers

        private void OnTriggerStay(Collider other) 
        {
            if (other.CompareTag("Door") && _isKey)
	    	{
	    		if (Input.GetKeyDown(KeyCode.E))
                {
                    Door door = other.GetComponent<Door>();
                    door.IsOpen = !door.IsOpen;
                }
	    	}
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Key"))
	    	{
	    		Destroy(other.gameObject);
	    		_isKey = true;
	    	}
        }

        #endregion
    }

}
