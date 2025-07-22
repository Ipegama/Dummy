using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Deal Damage")]
public class DealDamageEffect : Effect
{
    public int amount;
    public RectTransform explosionVFX;
    public AudioClip audioClip;

    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);
        owner.AttackAnimation(owner, rival);

        SoundManager.Instance.PlaySound(audioClip);

        yield return new WaitForSeconds(0.25f);
        rival.TakeDamage(amount);
    }
}
