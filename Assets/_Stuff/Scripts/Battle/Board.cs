using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : Singleton<Board>
{
    [SerializeField] private List<Slot> slots;

    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [SerializeField] private SlotFactory slotsFactory;

    private Coroutine fightCoroutine;
    private PlayerData usedBuild;
    public void SetupFight(PlayerData playerData, EnemyData enemyData)
    {
        usedBuild = playerData;
        var playerCards = playerData != null ? playerData.CardDatas : new List<CardData>();
        var enemyCards = enemyData != null ? enemyData.CardDatas : new List<CardData>();

        CreateSlots(playerCards, enemyCards);
    }

    private void CreateSlots(List<CardData> playerCards, List<CardData> enemyCards)
    {
        DestroySlots();

        int maxCount = Mathf.Max(playerCards.Count, enemyCards.Count);
        int totalSlots = maxCount * 2;

        for (int i = 0; i < totalSlots; i++)
        {
            bool isEnemy = (i % 2 == 0);
            Slot slot = slotsFactory.CreateSlot(this, transform, isEnemy);
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
        fightCoroutine = StartCoroutine(FightSequence());   
    }

    public void CloseFight()
    {
        if(fightCoroutine != null)
        {
            StopCoroutine(fightCoroutine);
            fightCoroutine = null;
        }
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
        Combat.Instance.ResetBuild();
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

                if (player.IsDead() || enemy.IsDead())
                {
                    break;
                }
            }
        }

        yield return new WaitForSeconds(0.5f);

        if (enemy.IsDead())
        {
            MapManager.Instance.UnlockNeighbors(Combat.Instance.CurrentTile.X, Combat.Instance.CurrentTile.Y);
            HandManager.Instance.RemoveFromHand(usedBuild);
            QuestManager.Instance.EnemyDefeated(enemy.EnemyData);
        }

        FinalizeAndCloseFight();
    }

    private (Combatant owner, Combatant rival) GetCombatantsForSlot(int index)
    {
        return (index % 2 == 0) ? (enemy, player) : (player, enemy);
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
