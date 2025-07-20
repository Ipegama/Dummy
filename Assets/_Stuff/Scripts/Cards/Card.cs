using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardDescription;
    [SerializeField] private Image cardImage;

    public static event Action<CardData,Combatant> OnCardUsed;

    public CardData CardData { get; private set; }

    public IEnumerator UseCard(Combatant owner, Combatant rival)
    {
        foreach(Effect effect in CardData.effects)
        {
            yield return effect.Use(owner, rival);
        }
        OnCardUsed?.Invoke(CardData,owner);
    }

    public void Setup(CardData cardData)
    {
        this.CardData = cardData;
        cardName.text = cardData.cardName;
        cardDescription.text = cardData.cardDescription;
        cardImage.sprite = cardData.cardIcon;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
