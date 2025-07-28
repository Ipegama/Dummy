using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Deal Damage Equal To Armor")]
public class DealDamageEqualToArmorEffect : Effect
{
    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);

        int amount = owner.GetStatusEffectStacks(StatusEffectType.ARMOR);
        rival.TakeDamage(amount);
        yield return new WaitForSeconds(0.25f);
    }
}
