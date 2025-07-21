using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    public void Setup(PlayerData playerData)
    {
        baseHealth = playerData.BaseHealth;
        CurrentHealth = baseHealth;
        UpdateUI();
    }
}
