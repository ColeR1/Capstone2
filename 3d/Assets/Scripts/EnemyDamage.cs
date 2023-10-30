using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealthController playerHealth; // Reference to the player's health
    public float attackCoolDown; // Time in seconds between each attack
    private float lastAttackTime; // Time since the last attack occurred
    private int attackDamage = 10;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthController>();
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");

            // Check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                AttackPlayer();
                lastAttackTime = Time.time; // Update the last attack time
            }
        }
    }

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
                playerHealth.TakeDamage(attackDamage); // Deal damage to the player
            }
        }
    }   
