using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyStats
{
    public EnemyLevelSystem.EnemyLevel level;
    public int xpReward; // Amount of XP awarded to the player when defeated
    public int maxHealth;
    public int attackDamage;

}

