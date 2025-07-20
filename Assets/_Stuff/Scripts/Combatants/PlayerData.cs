using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Player")]
public class PlayerData : ScriptableObject
{
    public string PlayerName;
    public List<CardData> CardDatas;
    public int BaseHealth;
}
