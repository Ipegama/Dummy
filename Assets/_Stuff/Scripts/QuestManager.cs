using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(LoadMenu());
        }
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
