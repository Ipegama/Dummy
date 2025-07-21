using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private List<BoardSlot> slots;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [SerializeField] private SlotFactory slotsFactory;

    private Coroutine fightCoroutine;

    public void CreateSlots(List<CardData> playerCards, List<CardData> enemyCards)
    {
        DestroySlots();

        int maxCount = Mathf.Max(playerCards.Count, enemyCards.Count);
        int totalSlots = maxCount * 2;

        for (int i = 0; i < totalSlots; i++)
        {
            bool isEnemy = (i % 2 == 0); 
            BoardSlot slot = slotsFactory.CreateSlot(this, transform, isEnemy);
            slots.Add(slot);

            int cardIndex = i / 2;

            if (isEnemy)
            {
                if (cardIndex < enemyCards.Count)
                {
                    CardData data = enemyCards[cardIndex];
                    if (data != null)
                    {
                        Card card = data.CreateCard();
                        slot.AddCard(card);
                        card.transform.SetParent(slot.transform, false);
                    }
                }
            }
            else 
            {
                if (cardIndex < playerCards.Count)
                {
                    CardData data = playerCards[cardIndex];
                    if (data != null)
                    {
                        Card card = data.CreateCard();
                        slot.AddCard(card);
                        card.transform.SetParent(slot.transform, false);
                    }
                }
            }
        }
    }



    public void StartFight()
    {
        LockCards();
        LockSlots();
        fightCoroutine = StartCoroutine(FightSequence());   
    }

    public void CloseFight()
    {
        if(fightCoroutine != null)
        {
            StopCoroutine(fightCoroutine);
            fightCoroutine = null;
        }

        ReturnCards();
        DestroySlots();
    }
    public void FinalizeAndCloseFight()
    {
        if (fightCoroutine != null)
        {
            StopCoroutine(fightCoroutine);
            fightCoroutine = null;
        }
        DestroySlots();
    }
    private IEnumerator FightSequence()
    {
        yield return new WaitForSeconds(1f);           

        while (!player.IsDead() && !enemy.IsDead())
        {
            for (int i = 0; i < slots.Count; i++)
            {
                var (owner, rival) = GetCombatantsForSlot(i);

                yield return StartCoroutine(slots[i].UseSlot(owner, rival));               
            }
        }
    }
    private (Combatant owner, Combatant rival) GetCombatantsForSlot(int index)
    {
        return (index % 2 == 0) ? (enemy, player) : (player, enemy);
    }
    private void LockCards()
    {
        foreach (BoardSlot slot in slots)
        {
            if (slot.Card != null)
            {
                DraggableItem draggable = slot.Card.GetComponent<DraggableItem>();
                if (draggable != null)
                {
                    draggable.enabled = false;
                }
            }
        }
    }
    private void LockSlots()
    {
        foreach(BoardSlot slot in slots)
        {
            slot.LockSlot();
        }
    }
    
    private List<Card> ReturnCards()
    {
        List<Card> collectedCards = new List<Card>();

        for (int i = 0; i < slots.Count; i++)
        {
            if (i % 2 != 0)
            {
                if (slots[i].Card != null)
                {
                    collectedCards.Add(slots[i].Card);
                }
            }
        }
        return collectedCards;
    }
    private void DestroySlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Destroy(slots[i].gameObject);
        }

        slots.Clear();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
