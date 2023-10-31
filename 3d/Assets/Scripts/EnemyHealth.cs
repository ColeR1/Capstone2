using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //this 
    [System.Serializable]
    public class DropItem
    {   
        public GameObject prefab;
        [Range(0.0f, 100.0f)]
        public float dropChancePercentage;
    }

    public int health = 100; //currenthealth
    private int maxHealth; // maxhealth
    public LevelSystem playerLevel; //reference to the players levelsystem

    public int enemyLevel; //Holds the enemy's level

    public DropItem[] dropItems; // Array of DropItem structs for each item
    private void Start() {
        maxHealth = health;
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > maxHealth;

        if (wouldBeOverMaxHealth)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
         Debug.Log("I am Dead!");

        if (enemyLevel >= 1 && enemyLevel <= 5) // Assuming level range 1-5
        {
            int expDrop = 100 * enemyLevel; // Adjust experience calculation as needed

            playerLevel.exp += expDrop;
            Debug.Log("Dropped " + expDrop + " experience points.");
        }
        else
        {
            Debug.LogWarning("Enemy level out of range (1-5)!");
        }

        // Calculate the total drop chance percentage for all items
        float totalChance = 0.0f;
        foreach (var item in dropItems)
        {
            totalChance += item.dropChancePercentage;
        }

        // Randomly determine which item to drop based on their chances
        float randomValue = Random.Range(0.0f, totalChance);
        float accumulatedChance = 0.0f;

        foreach (var item in dropItems)
        {
            if (randomValue <= item.dropChancePercentage + accumulatedChance)
            {
                if (item.prefab != null)
                {
                    Instantiate(item.prefab, transform.position, Quaternion.identity);
                }
                break;
            }
            accumulatedChance += item.dropChancePercentage;
        }

        Destroy(gameObject);
    }
}


