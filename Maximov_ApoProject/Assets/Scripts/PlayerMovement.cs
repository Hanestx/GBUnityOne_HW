using UnityEngine;


namespace ApoProject
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speedRotate;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _jumpPower;
        private float _curVertSpeed;
        private float _distToHit;

        bool _isGrounded;
        int _hpPlayerText;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private Vector3 _direction;
        AudioSource _audio;
        [SerializeField] AudioClip _walk;
        PlayerHP _playerHP;



        #endregion




        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _playerHP = GetComponent<PlayerHP>();


        }

        private void Update()
        {

            _distToHit = 0f;
            _curVertSpeed = GetComponent<Rigidbody>().velocity.y;
            Ray ray = new Ray(GetComponent<Collider>().bounds.center, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _distToHit = Vector3.Distance(GetComponent<Collider>().bounds.center, hit.point);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && _playerHP.HpPlayerCurrent >= 1)
            {
                _animator.SetBool("run", true);


                if (Input.GetKeyDown(KeyCode.Space) && _distToHit < 0.95f)
                {
                    Jump();
                }
            }

            else if (Input.GetKeyDown(KeyCode.Space) && _distToHit < 0.95f && _playerHP.HpPlayerCurrent >= 1)
            {
                Jump();
            }

            else
            {
                _animator.SetBool("run", false);
                _animator.SetBool("rifle", false);
                _animator.SetBool("jump", false);

                if (_playerHP.HpPlayerCurrent <= 0)
                {
                    _animator.SetBool("death", true);

                    GetComponent<PlayerMovement>().enabled = false;
                }
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
