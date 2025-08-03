using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    public EnemyData EnemyData { get; private set; }
    public void Setup(EnemyData enemyData)
    {
        EnemyData = enemyData;
        baseHealth = enemyData.BaseHealth;
        CurrentHealth = baseHealth;
        SetupUI(enemyData.Sprite);
        UpdateUI();
    }
}
