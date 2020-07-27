using UnityEngine;
using UnityEngine.AI;

namespace ApoProject
{
    public class EnemyTest : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _hp = 100;




        #endregion


        #region GetSet

        public string HpCurrent { get { return _hp.ToString(); } }

        #endregion



        #region MyMethods

        public void OnHit(int damage)
        {
            _hp -= damage;
            GetComponentInChildren<EnemyHpUI>().HpShow = HpCurrent;

            if (_hp <= 0)
            {
                Destroy(gameObject);
            }

        }


        #endregion
    }
}