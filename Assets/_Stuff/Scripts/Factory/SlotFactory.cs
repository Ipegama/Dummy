using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New/Factory/Slot Factory")]
public class SlotFactory : ScriptableObject
{
    [SerializeField] private Slot slotPrefab;

    [SerializeField] Color playerColor, enemyColor;

    public Slot CreateSlot(Board board, Transform parent, bool isEnemy)
    {
        Slot slot = Instantiate(slotPrefab);
        slot.transform.SetParent(parent, false);
        slot.Setup(board);
        slot.BaseColor = isEnemy ? enemyColor : playerColor;

        return slot;
    }
}
