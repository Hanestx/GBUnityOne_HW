using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;


    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
        }
    }
}
