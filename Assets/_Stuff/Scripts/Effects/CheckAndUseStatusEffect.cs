using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Check And Use Status Effect")]
public class CheckAndUseStatusEffect : Effect
{
    public StatusEffectType StatusEffectType;
    public int Amount;
    public Effect effectToUse;

    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);

        int statusAmount = owner.GetStatusEffectStacks(StatusEffectType);

        if(statusAmount >= Amount)
        {
            owner.RemoveStatusEffect(StatusEffectType, Amount);
            yield return effectToUse.Use(owner, rival);
        }
        yield return new WaitForSeconds(0.25f);
    }
}
