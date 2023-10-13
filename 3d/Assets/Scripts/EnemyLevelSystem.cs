using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelSystem : MonoBehaviour
{
  public enum EnemyLevel
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    public EnemyLevel level; // Initial level
    public EnemyStats[] levelStats; // Array to define stats for each level

    private EnemyHealth enemyHealth;    
    private EnemyDamage enemyDamage;
    private PlayerHealthController playerHealth; //Reference to the players health;
    private float lastAttackTime;
    private float attackCoolDown = 2.0f;
    private int attackDamage; // Store the enemy's current attack damage



    private void Start()
    {
        
        enemyHealth = GetComponent<EnemyHealth>();
        enemyHealth.health = GetMaxHealthForLevel(level);
        attackDamage = GetAttackDamage(); // Initialize attack damage
        enemyDamage = GetComponent<EnemyDamage>();
        enemyDamage.attackCoolDown = attackCoolDown; // Pass the attack cooldown
        lastAttackTime = Time.time;
    }

    public void SetLevel(EnemyLevel newLevel)
    {
        level = newLevel;
        enemyHealth.health = GetMaxHealthForLevel(newLevel);
        attackDamage = GetAttackDamage(); // Update attack damage
    }

    private int GetMaxHealthForLevel(EnemyLevel level)
    {
        // Find and return max health based on the specified level
        foreach (EnemyStats stats in levelStats)
        {
            if (level == stats.level)
            {
                return stats.maxHealth;
            }
        }

        // Return a default value or handle the case when level not found
        return 0;
    }

   
    public int GetAttackDamage()
    {
        foreach (EnemyStats stats in levelStats)
        {
            if (level == stats.level)
            {
                return stats.attackDamage;
            }
        }
        return 0;
    }
    private void Update()
    {
        // Check if the enemy should level up (you can define your own criteria)
        if (enemyHealth.health <= 0) // Example: If enemy health drops to zero, it levels up
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }


      private void AttackPlayer()
    {
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage); //Deal damage to the player
        }
    }

}
