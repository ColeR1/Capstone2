using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{

    public int level;
    public int exp;
    public PlayerHealthController player;
    public AttackArea attack;
 

    public int BaseHealthIncrease = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }

    void LevelUp()
    {
        if(exp>=Mathf.Pow(level, 2) +100)
        {
            exp = exp - (int)(Mathf.Pow(level,2)+100 );
            level = level + 1;
            exp = 0;
            levelEffect();
        }
    }

    void levelEffect()
    {

        //Increase the max health
        player.maxHealth = player.maxHealth + BaseHealthIncrease;
        //Update the player's current health to the new max health
        player.currentHealth = player.maxHealth;
        // Update the UI and health bar
        player.UpdateHealthUI();
        player._healthbar.UpdateHealthBar(player.maxHealth, player.currentHealth);
        //Increase the BaseHealth Increase
        BaseHealthIncrease = BaseHealthIncrease+(int)(Mathf.Pow(level,2)+5 ); // You can adjust the factor as needed
        //Update the attack damage
          attack.damage = attack.damage + (int)(Mathf.Pow(level, 2) + 5);

    }

    
}
