using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewMapData", menuName = "New/Map Data")]
public class MapData : ScriptableObject
{
    public List<TileData> tiles;
}
