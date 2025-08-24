using System.Collections.Generic;
using UnityEngine;

public class HandManager : Singleton<HandManager>
{
    [SerializeField] private List<PlayerData> hand = new List<PlayerData>();

    public List<PlayerData> Hand => hand;

    public void Setup(List<PlayerData> newHand)
    {
        foreach (PlayerData hand in newHand)
        {
            AddToHand(hand);
        }
    }

    public void AddToHand(PlayerData build)
    {
        hand.Add(build);
        HandUI.Instance.UpdateBuilds();
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
