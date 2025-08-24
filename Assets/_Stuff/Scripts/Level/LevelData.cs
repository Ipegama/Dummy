using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New/Level")]
public class LevelData : ScriptableObject
{
    public MapData MapData;
    public List<PlayerData> Hand;
    public EnemyData Bounty;
}

