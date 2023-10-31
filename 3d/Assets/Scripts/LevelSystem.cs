using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    public PlayerHealthController playerhp;
    public AttackArea playerdmg;
    public TextMeshProUGUI levelText;
    public int level;
    public int exp;
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
        if(exp>=Mathf.Pow(level,2)+100)
        {
            exp = exp - (int)(Mathf.Pow(level,2) + 100);
            //increased the players level by 1 when it gets 100 xp
            level = level +1;
            //changes the level Text to display the current level
            levelText.text = "LV:" + level.ToString();
            //Increases the players health and updates the health UI
            playerhp.maxHealth = playerhp.maxHealth + (int)Mathf.Pow(level, 1);
            playerhp.currentHealth = playerhp.maxHealth;
            playerhp.UpdateHealthUI();
            playerhp._healthbar.UpdateHealthBar(playerhp.currentHealth, playerhp.maxHealth);
            //Increases the players damage
            playerdmg.damage = playerdmg.damage + (int)Mathf.Pow(level, 2);

        }
    }

    
}
