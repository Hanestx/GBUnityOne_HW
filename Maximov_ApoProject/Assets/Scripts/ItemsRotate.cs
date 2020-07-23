using UnityEngine;


namespace ApoProject
{
    public class ItemsRotate : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
    	void Update()
    	{
            transform.Rotate(Vector3.up * _speed * Time.deltaTime, Space.World);
        }

    }
}
