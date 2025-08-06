using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Combatant : MonoBehaviour
{
    public virtual int BaseHealth { get; set; }
    [SerializeField] TMP_Text hpText;
    [SerializeField] Image combatantImage;
    [SerializeField] StatusEffectsUI statusEffectsUI;
    public virtual int CurrentHealth { get;  set; }
    public Vector3 OriginalPosition { get; set; }

    protected Dictionary<StatusEffectType, int> statusEffects = new();

    private void Start()
    {
        OriginalPosition = transform.position;
    }
    public void SetupUI(Sprite sprite)
    {
        combatantImage.sprite = sprite;
        UpdateUI();
    }
    public void UpdateUI()
    {
        hpText.text = $"{CurrentHealth}/{BaseHealth}";
    }
    public void TakeDamage(int amount)
    {
        int remainingDamage = amount;
        int currentArmor = GetStatusEffectStacks(StatusEffectType.ARMOR);
        if (currentArmor > 0)
        {
            if(currentArmor >= amount)
            {
                RemoveStatusEffect(StatusEffectType.ARMOR, remainingDamage);
                remainingDamage = 0;
            }
            else if (currentArmor < amount)
            {
                RemoveStatusEffect(StatusEffectType.ARMOR, currentArmor);
                remainingDamage -= currentArmor;
            }
        }
        if(remainingDamage > 0)
        {
            CurrentHealth -= remainingDamage;
        }
        UpdateUI();
    }
    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }

    public void AddStatusEffect(StatusEffectType type, int stackCount)
    {
        if(statusEffects.ContainsKey(type))
        {
            statusEffects[type] += stackCount;
        }
        else
        {
            statusEffects.Add(type, stackCount);
        }
        statusEffectsUI.UpdateStatusEffectUI(type, GetStatusEffectStacks(type));
    }

    public void RemoveStatusEffect(StatusEffectType type, int stackCount)
    {
        if (statusEffects.ContainsKey(type))
        {
            statusEffects[type] -= stackCount;
            if (statusEffects[type] <= 0)
            {
                statusEffects.Remove(type);
            }
        }
        statusEffectsUI.UpdateStatusEffectUI(type, GetStatusEffectStacks(type));
    }

    public int GetStatusEffectStacks(StatusEffectType type)
    {
        if(statusEffects.ContainsKey(type)) return statusEffects[type];
        else return 0;
    }
}
