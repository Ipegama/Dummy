using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Combatant
{
    public EnemyData EnemyData { get; private set; }
    public void Setup(EnemyData enemyData)
    {
        EnemyData = enemyData;
        BaseHealth = enemyData.BaseHealth;
        CurrentHealth = BaseHealth;
        SetupUI(enemyData.Sprite);
        UpdateUI();
    }
}
