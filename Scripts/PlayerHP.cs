using ApoProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    [SerializeField] private int _hpPlayer = 100;
    MineTurretSpawner _mineTurretSpawner;
    Animator _animator;

    private void Start()
    {
        _mineTurretSpawner = GetComponent<MineTurretSpawner>();
       
    }


    #region GetSet

    public int HpPlayerCurrent { get { return _hpPlayer; } }

    #endregion

    public void OnHit(int damage)
    {
        _hpPlayer -= damage;
        if (_hpPlayer <= 0)
        {
            _hpPlayer = 0;
            _mineTurretSpawner.UI = _hpPlayer;
        }
        _mineTurretSpawner.UI = _hpPlayer;
    }

    public void HealthPlus(int hpPlus)
    {
        _hpPlayer = _hpPlayer + hpPlus;

        if (_hpPlayer > 200)
        {
            _hpPlayer = 200;
        }
    }

}
