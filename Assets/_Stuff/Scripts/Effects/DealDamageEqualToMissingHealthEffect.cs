using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Deal Damage Equal To Missing Health")]
public class DealDamageEqualToMissingHealthEffect : Effect
{

    public AudioClip audioClip;
    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);

        int amount = owner.BaseHealth - owner.CurrentHealth;
        rival.TakeDamage(amount);
        SoundManager.Instance.PlaySound(audioClip);
        yield return new WaitForSeconds(0.25f);
    }
}
