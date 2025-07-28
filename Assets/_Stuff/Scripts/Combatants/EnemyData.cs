using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Enemy")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public List<CardData> CardDatas;
    public int BaseHealth;
    public Sprite Sprite;
}
