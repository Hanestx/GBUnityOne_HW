using UnityEngine;
using UnityEngine.AI;

namespace ApoProject
{
    public class Enemy : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _hp;
        [SerializeField] Transform _lookDeath;
        Animator _animator;
        [SerializeField] GameObject _killCountObj;
        KillCount _killCount;



        #endregion


        #region GetSet

        public string HpCurrent { get { return _hp.ToString(); } }

        #endregion


        private void Start()
        {
            _animator = GetComponent<Animator>();
            _killCountObj = GameObject.FindGameObjectWithTag("KillCount");
            _killCount = _killCountObj.GetComponent<KillCount>();


        }


        #region MyMethods

        public void OnHit(int damage)
        {
            _animator.SetBool("hit", true);
            _hp -= damage;
            GetComponentInChildren<EnemyHpUI>().HpShow = HpCurrent;

            if (_hp <= 0)
            {
                _hp = 0;
                GetComponentInChildren<EnemyHpUI>().HpShow = HpCurrent;
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                _animator.SetBool("death", true);
               _killCount.KillCounts(1);
                Destroy(gameObject, 8);
            }
            
        }


        #endregion
    }
}