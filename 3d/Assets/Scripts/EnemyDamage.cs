using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float attackCoolDown; //Time in seconds between each attack;
    public int damageAmount; // amount of damgae the enemy deals to the player;

    private PlayerHealthController playerHealth; //Reference to the players health;
    private float lastAttackTime; //Time since the last attack occured;

    public GameObject player; //reference to the player gameobject;

    private void Start() {
        playerHealth = FindObjectOfType<PlayerHealthController>();
    }
    private void OnCollisionStay(Collision col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");

            //Check if enough time has passed since last attack
            if(Time.time - lastAttackTime >= attackCoolDown)
            {
                AttackPlayer();
                lastAttackTime = Time.time; //Updaet the last attack time
            }
        }
    }

    private void AttackPlayer()
    {
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); //Deal damage to the player
        }
    }

}
