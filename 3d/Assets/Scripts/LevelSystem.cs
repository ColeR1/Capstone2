using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public int exp;
    public PlayerHealthController player;
    public AttackArea attack;

    public  const int BaseHealthIncrease = 10;
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
        player.maxHealth = player.maxHealth +10 * level;
        player.UpdateHealthUI();
        attack.damage = attack.damage + 5;
    }

    
}
