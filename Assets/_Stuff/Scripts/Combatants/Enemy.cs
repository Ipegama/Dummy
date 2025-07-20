using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    public void Setup(EnemyData enemyData)
    {
        baseHealth = enemyData.BaseHealth;
        CurrentHealth = baseHealth;
        UpdateUI();
    }
}
