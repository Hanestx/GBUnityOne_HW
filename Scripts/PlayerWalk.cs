using UnityEngine;

namespace MyDark
{
	public class PlayerWalk : MonoBehaviour
	{
		#region Fields

		[SerializeField] private float _speed, _rotSpeed;
		[SerializeField] private Vector3 _direction;

		#endregion


		#region UnityMethods

		void Update()
		{
			_direction.x = Input.GetAxis("Horizontal");
			_direction.z = Input.GetAxis("Vertical");
			_direction.Normalize();

			Vector3 translation = _direction * _speed * Time.deltaTime;
		    transform.Translate(translation);

			//var speed = (_direction.sqrMagnitude > 0) ? _speed : 0;
			//speed = speed * Time.deltaTime;

			//transform.position += transform.forward * speed;

			//Vector3 desiredForward = Vector3.RotateTowards(transform.forward,  _direction, _rotSpeed * Time.deltaTime, 0f);
			//transform.rotation = Quaternion.LookRotation(desiredForward);
		}

		#endregion

		
	}
}
