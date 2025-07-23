using UnityEngine;

public class Combat : Singleton<Combat>
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    public TileButton CurrentTile { get; private set; }
    public PlayerData CurrentBuild { get; private set; }
    public bool IsInFight { get; private set; } = false;

    private void Start()
    {
        player.Initialize(10);
    }

    public void SetCurrentTile(TileButton tile)
    {
        CurrentTile = tile;
    }

    public void StartFight(TileButton tile)
    {
        CurrentTile = tile;
        IsInFight = true;

        EnemyData enemyData = tile.EnemyData;
        if (enemyData == null)
        {
            Debug.LogWarning("No enemy on this tile! Unlocking neighbors...");
            MapManager.Instance.UnlockNeighbors(tile.X, tile.Y);
            IsInFight = false;
            return;
        }

        CurrentBuild = null;  // Brak builda na starcie walki

        LoadFight(enemyData);
        StateManager.Instance.ShowFight();
    }

    public void ChangeBuild(PlayerData newBuild)
    {
        if (!IsInFight)
        {
            Debug.LogWarning("Cannot change build, not in fight.");
            return;
        }

        CurrentBuild = newBuild;
        player.Setup(newBuild);

        // Prze³aduj sloty z nowym buildem i tym samym enemy
        Board.Instance.SetupFight(newBuild, CurrentTile.EnemyData);

        Debug.Log($"Player build changed to {newBuild.name}");
    }

    public void LoadFight(EnemyData enemyData)
    {
        Board.Instance.CloseFight();

        enemy.Setup(enemyData);
        Board.Instance.SetupFight(CurrentBuild, enemyData);
    }

    public void EndFight()
    {
        IsInFight = false;
        CurrentBuild = null;
        CurrentTile = null;

        Board.Instance.CloseFight();
    }

    public void ResetBuild()
    {
        CurrentBuild = null;
    }
}
