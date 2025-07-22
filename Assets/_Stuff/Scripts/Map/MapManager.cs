using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int gridWidth = 5;
    [SerializeField] private int gridHeight = 5;
    [SerializeField] private Transform gridParent;

    private TileButton[,] tiles;
    private const float tileSize = 100f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new TileButton[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject tileObj = Instantiate(tilePrefab, gridParent);
                RectTransform rect = tileObj.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(tileSize, tileSize);
                rect.anchoredPosition = new Vector2(x * tileSize, -y * tileSize); // lewy-górny róg jako punkt startowy

                TileButton tile = tileObj.GetComponent<TileButton>();
                tile.Setup(x, y);
                tiles[x, y] = tile;
            }
        }

        int centerX = gridWidth / 2;
        int centerY = gridHeight / 2;
        tiles[centerX, centerY].Unlock();
    }

    public void UnlockNeighbors(int x, int y)
    {
        TryUnlock(x + 1, y);
        TryUnlock(x - 1, y);
        TryUnlock(x, y + 1);
        TryUnlock(x, y - 1);
    }

    void TryUnlock(int x, int y)
    {
        if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight) return;

        TileButton tile = tiles[x, y];
        if (!tile.IsUnlocked)
        {
            tile.Unlock();
        }
    }

    public void OnTileClicked(TileButton tile)
    {
        Debug.Log($"Clicked tile at ({tile.x}, {tile.y})");

        UnlockNeighbors(tile.x, tile.y);

        StateManager.Instance.ShowFight(); 
    }
}
