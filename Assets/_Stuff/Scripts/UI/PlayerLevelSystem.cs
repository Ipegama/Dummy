using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLevelSystem : Singleton<PlayerLevelSystem>
{
    private int currentExp;
    [SerializeField] private List<int> requiredExp;
    [SerializeField] private Player player;

    [SerializeField] private TMP_Text currentExpText;
    [SerializeField] private TMP_Text nextLevelHpText;

    private void Start()
    {
        UpdateUI();
    }
    public void AddExp(int amount)
    {
        currentExp += amount;

        CheckForLevelUp();
    }

    private void CheckForLevelUp()
    {
        if (requiredExp.Count == 0) return;

        if (currentExp >= requiredExp[0])
        {
            currentExp -= requiredExp[0];
            requiredExp.RemoveAt(0);
            LevelUp(); 
            CheckForLevelUp();
        }
        UpdateUI();
    }

    public void LevelUp()
    {
        player.LevelUp(player.BaseHealth +2 );
    }

    private void UpdateUI()
    {
        if (requiredExp.Count == 0)
        {
            currentExpText.text = $"Max Level";
        }
        else
        {
            currentExpText.text = $"EXP: {currentExp}/{requiredExp[0]}";
        }

        int playerHp = player.BaseHealth > 0 ? player.BaseHealth : 10;
        nextLevelHpText.text = $"Level UP: {playerHp + 2} Total HP";
    }
}
