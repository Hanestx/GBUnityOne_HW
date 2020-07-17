using UnityEngine;


namespace MyDark
{
    public class NextFloor : MonoBehaviour
    {
    	[SerializeField] private Transform _tp;

    	public void Teleport(GameObject player)
    	{
    		player.transform.position = _tp.transform.position;
    	}
    }
}