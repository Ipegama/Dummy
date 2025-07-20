using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Card")]
public class CardData : ScriptableObject
{
    public Card cardPrefab;

    public string cardName;
    public string cardDescription;
    public Sprite cardIcon;

    public List<Effect> effects;

    public Card CreateCard()
    {
        Card card = Instantiate(cardPrefab);
        card.Setup(this);
        return card;
    }
}