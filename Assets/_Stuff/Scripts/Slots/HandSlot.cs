using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandSlot : DragSlot
{
    public List<Card> Cards { get; private set; } = new();

    public override void OnDrop(PointerEventData eventData)
    {
        if (IsLocked) return;

        base.OnDrop(eventData);

        Card droppedCard = eventData.pointerDrag.GetComponent<Card>();
        if (droppedCard != null)
        {
            AddCard(droppedCard);
        }
    }

    public void AddCard(Card newCard)
    {
        if (IsLocked) return;

        Cards.Add(newCard);
        newCard.transform.SetParent(transform);
        newCard.transform.localPosition = Vector3.zero;

        var draggable = newCard.GetComponent<DraggableItem>();
        if (draggable != null)
        {
            draggable.ParentAfterDrag = transform;
        }
    }

    public void RemoveCard(Card card)
    {
        if (Cards.Contains(card))
        {
            Cards.Remove(card);
        }
    }
    public void Clear()
    {
        for (int i = Cards.Count - 1; i >= 0; i--)
        {
            if (Cards[i] != null)
            {
                Destroy(Cards[i].gameObject);
            }
        }       

        Cards.Clear();
    }
}
