using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Card))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;
    public Transform ParentAfterDrag { get; set; }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        ParentAfterDrag = transform.parent;

        BoardSlot slot = ParentAfterDrag.GetComponent<BoardSlot>();
        if (slot != null)
        {
            slot.DetachCard();
        }

        HandSlot handSlot = ParentAfterDrag.GetComponent<HandSlot>();
        if (handSlot != null)
        {
            Card card = GetComponent<Card>();
            handSlot.RemoveCard(card);
        }

        transform.SetParent(transform.root); 
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(ParentAfterDrag);

        HandSlot handSlot = ParentAfterDrag.GetComponent<HandSlot>();
        if (handSlot != null)
        {
            Card card = GetComponent<Card>();
            if (!handSlot.Cards.Contains(card))
            {
                handSlot.Cards.Add(card);
            }
        }
    }
}
