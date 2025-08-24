using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    public void Initialize(int baseHp)
    {
        BaseHealth = baseHp;
        CurrentHealth = BaseHealth;
        UpdateUI();
    }

    public void Setup(PlayerData playerData)
    {
        SetupUI(playerData.Sprite);
        UpdateUI();
    }

    public void LevelUp(int newHp)
    {
        BaseHealth = newHp;
        CurrentHealth = BaseHealth;
        UpdateUI();
    }
}
