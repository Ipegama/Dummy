using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private EnemyData enemyToDefeat;
    [SerializeField] private GameObject gameWonScreen;
    public void EnemyDefeated(EnemyData enemyData)
    {
        if (enemyToDefeat == enemyData)
        {
            Debug.Log("Game Won");
            gameWonScreen.SetActive(true);
                }
    }
}
