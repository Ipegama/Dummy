using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    public void Initialize(int baseHp)
    {
        baseHealth = baseHp;
        CurrentHealth = baseHealth;
        UpdateUI();
    }

    public void Setup(PlayerData playerData)
    {
        SetupUI(playerData.Sprite);
        UpdateUI();
    }
}
