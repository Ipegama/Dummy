using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Combatant : MonoBehaviour
{
    protected int baseHealth;
    [SerializeField] TMP_Text hpText;
    public virtual int CurrentHealth { get;  set; }
        
    public void UpdateUI()
    {
        hpText.text = $"{CurrentHealth}/{baseHealth}";
    }
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        UpdateUI();
    }
    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }

    public Tween AttackAnimation(Combatant attacker, Combatant target)
    {
        RectTransform attackerTranform = attacker.GetComponent<RectTransform>();
        RectTransform targetTransform = target.GetComponent<RectTransform>();
        float attackDistance = 50f;  
        float attackDuration = 0.25f;

        Vector3 direction = (targetTransform.position - attackerTranform.position).normalized;

        Vector3 attackPosition = attackerTranform.position + direction * attackDistance;

        return attackerTranform.DOMove(attackPosition, attackDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }
}
