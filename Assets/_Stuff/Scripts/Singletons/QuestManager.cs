using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : Singleton<QuestManager>
{
    private EnemyData enemyToDefeat;
    [SerializeField] private RectTransform gameWonScreen;
    public void SetBounty(EnemyData enemyData)
    {
        enemyToDefeat = enemyData;
    }
    public void EnemyDefeated(EnemyData enemyData)
    {
        if (enemyToDefeat == enemyData)
        {
            gameWonScreen.gameObject.SetActive(true);
            gameWonScreen.transform.DOScale(1.1f, 2f).SetEase(Ease.OutBack);
            StartCoroutine(LoadMenu());
        }
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
