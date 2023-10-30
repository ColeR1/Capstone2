using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private int maxHealth;
    public LevelSystem playerLevel;




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
        playerLevel.exp = playerLevel.exp + 200;
        Destroy(gameObject);
    }
}
