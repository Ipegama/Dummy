using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New/Factory/Slot Factory")]
public class SlotFactory : ScriptableObject
{
    [SerializeField] private BoardSlot boardSlotPrefab;

    [SerializeField] Color playerColor, enemyColor;

    public BoardSlot CreateSlot(Board board, Transform parent, bool isEnemy)
    {
        BoardSlot boardSlot = Instantiate(boardSlotPrefab);
        boardSlot.transform.SetParent(parent, false);
        boardSlot.Setup(board);
        boardSlot.BaseColor = isEnemy ? enemyColor : playerColor;
        if (isEnemy) boardSlot.LockSlot();

        return boardSlot;
    }
}
