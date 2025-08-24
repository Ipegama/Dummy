using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform gridParent;
    [SerializeField] private float tileSize = 100f;

    private List<TileButton> spawnedTiles = new List<TileButton>();


    public void GenerateMap(MapData mapData)
    {
        foreach (TileData tileData in mapData.tiles)
        {
            GameObject tileObj = Instantiate(tilePrefab, gridParent);
            RectTransform rect = tileObj.GetComponent<RectTransform>();
            rect.anchoredPosition = tileData.position * tileSize;

            TileButton tile = tileObj.GetComponent<TileButton>();
            tile.Setup(tileData);

            if (tileData.isInitiallyUnlocked)
            {
                tile.Unlock();
            }

            spawnedTiles.Add(tile);
        }
    }

    public void OnTileClicked(TileButton tile)
    {
        if (tile.EnemyData == null)
        {
            UnlockNeighbors(tile.X, tile.Y);
        }
        else
        {
            Combat.Instance.ResetBuild();
            Combat.Instance.StartFight(tile);
        }
    }

    public void UnlockNeighbors(int x, int y)
    {
        RemoveEnemy(x,y);
        TryUnlock(x + 1, y);
        TryUnlock(x - 1, y);
        TryUnlock(x, y + 1);
        TryUnlock(x, y - 1);
    }

    private void RemoveEnemy(int x, int y)
    {
        foreach (TileButton tile in spawnedTiles)
        {
            if (tile.X == x && tile.Y == y)
            {
                tile.RemoveEnemy();
            }
        }
    }

    private void TryUnlock(int x, int y)
    {
        foreach (TileButton tile in spawnedTiles)
        {
            if (tile.X == x && tile.Y == y && !tile.IsUnlocked)
            {
                tile.Unlock();
                break;
            }
        }
    }
}
