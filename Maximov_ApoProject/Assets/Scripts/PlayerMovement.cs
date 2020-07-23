using UnityEngine;


namespace ApoProject
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speedRotate;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _jumpPower;

        private Rigidbody _rigidbody;
        private Animator _animator;
        private Vector3 _direction;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("run", true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            else
            {
                _animator.SetBool("run", false);
                _animator.SetBool("jump", false);
            }
        }


        private void FixedUpdate()
        {
            _direction.x = Input.GetAxis("Horizontal") * _speedMove;
            _direction.z = Input.GetAxis("Vertical") * _speedMove;
            _direction.Normalize();

           
            var speed = ((Mathf.Abs(_direction.sqrMagnitude) > 0) ? _speedMove : 0);
            speed *= Time.deltaTime;

            var moveDirection = transform.forward * speed;
            _rigidbody.MovePosition(transform.position + (moveDirection * Time.deltaTime));

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _speedRotate * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(desiredForward);
        }

        #endregion


        #region MyMethods

        private void Jump()
        {
            _rigidbody.AddForce(transform.up * _jumpPower, ForceMode.Acceleration);

            _animator.SetBool("run", false);
            _animator.SetBool("jump", true);
        }

        #endregion
    }
}
