using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoardSlot : DragSlot
{
    public Card Card { get; private set; }
    public Color BaseColor { get; set; }

    private Image image;
    private Board board;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = BaseColor;
    }

    public void Setup(Board board)
    {
        this.board = board;
    }

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
        if (Card != null) return;

        Card = newCard;
        newCard.transform.SetParent(transform);
        newCard.transform.localPosition = Vector3.zero;

        var draggable = newCard.GetComponent<DraggableItem>();
        if (draggable != null)
        {
            draggable.ParentAfterDrag = transform;
        }
    }

    public IEnumerator UseSlot(Combatant owner, Combatant rival)
    {
        Highlight(true);

        if (Card == null)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Debug.Log($"{owner} uses card: {Card.name}");
            yield return Card.UseCard(owner, rival);
        }

        Highlight(false);
    }

    public void DetachCard()
    {
        Card = null;
    }
    private void Highlight(bool active)
    {
        if (image == null) return;
        image.color = active ? Color.yellow : BaseColor;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
