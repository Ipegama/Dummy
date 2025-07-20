using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{
    [SerializeField] private HandSlot hand;

    public void Setup(PlayerData playerData)
    {
        baseHealth = playerData.BaseHealth;
        CurrentHealth = baseHealth;
        UpdateUI();

        hand.Clear();

        foreach(CardData cardData in playerData.CardDatas)
        {
            hand.AddCard(cardData.CreateCard());
        }
    }


}
