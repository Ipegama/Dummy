using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private List<PlayerData> playerDatas;
    [SerializeField] private List<EnemyData> enemyDatas;

    private void Start()
    {
        ResetRun();
    }

    public void LoadFight(int enemyIndex, int playerIndex)
    {
        board.CloseFight();

        PlayerData playerData = playerDatas[playerIndex];
        EnemyData enemyData = enemyDatas[enemyIndex];

        player.Setup(playerData);
        enemy.Setup(enemyData);

        board.CreateSlots(playerData.CardDatas, enemyData.CardDatas);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) LoadFight(0, 0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) LoadFight(1, 0);
        if (Input.GetKeyUp(KeyCode.R)) ResetRun();
    }

    private void ResetRun()
    {
        LoadFight(0, 0);
    }
}

