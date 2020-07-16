using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")){
            // var enemy = other.GetComponent<MyEnemy>();
            // enemy.Hurt(_damage);
            Destroy(other);
        }
    }
}
