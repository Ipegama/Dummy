using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private List<EnemyData> enemyDatas;

    private bool[] defeatedEnemies;

    private void Start()
    {
        ResetRun();
    }

    public void LoadEnemy(int index)
    {
        board.CloseFight();
        board.CreateSlots(enemyDatas[index].CardDatas);
        enemy.Setup(enemyDatas[index]);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) LoadEnemy(0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) LoadEnemy(1);
        if (Input.GetKeyUp(KeyCode.R)) ResetRun();
    }

    private void ResetRun()
    {
        defeatedEnemies = new bool[enemyDatas.Count];
        player.Setup(playerData);
        LoadEnemy(0);
    }


}

