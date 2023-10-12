using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 3;
    
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
            enemyhealth.Damage(damage);
        }
    }
}
