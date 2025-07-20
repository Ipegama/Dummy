using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DragSlot : MonoBehaviour, IDropHandler
{
    public virtual bool IsLocked { get; protected set; } = false;

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (IsLocked) return;

        DraggableItem draggableItem = eventData.pointerDrag?.GetComponent<DraggableItem>();
        if (draggableItem != null)
        {
            draggableItem.ParentAfterDrag = transform;
        }
    }

    public virtual void LockSlot()
    {
        IsLocked = true;
    }

    public virtual void UnlockSlot()
    {
        IsLocked = false;
    }
}
