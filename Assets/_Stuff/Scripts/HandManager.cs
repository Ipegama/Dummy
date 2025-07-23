using System.Collections.Generic;
using UnityEngine;

public class HandManager : Singleton<HandManager>
{
    [SerializeField] private List<PlayerData> hand = new List<PlayerData>();

    public IReadOnlyList<PlayerData> Hand => hand;



    public void Initialize(List<PlayerData> startingBuilds)
    {
        hand = new List<PlayerData>(startingBuilds);
    }

    public void AddToHand(PlayerData build)
    {
        hand.Add(build);
    }

    public void RemoveFromHand(PlayerData build)
    {
        if (hand.Contains(build))
        {
            hand.Remove(build);
            HandUI.Instance.UpdateBuilds();
        }
    }

    public bool HasBuilds()
    {
        return hand.Count > 0;
    }
}
