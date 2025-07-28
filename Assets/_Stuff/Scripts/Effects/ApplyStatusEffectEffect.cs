using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Apply Effect")]
public class ApplyStatusEffectEffect : Effect
{
    public StatusEffectType StatusEffectType;
    public int Amount;
    public TargetEnum TargetEnum;
    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(1);

        switch (TargetEnum) 
        {
            case TargetEnum.Owner:
                owner.AddStatusEffect(StatusEffectType, Amount);
                break;
            case TargetEnum.Rival:
                rival.AddStatusEffect(StatusEffectType, Amount);
                break;
            case TargetEnum.Both:
                owner.AddStatusEffect(StatusEffectType, Amount);
                rival.AddStatusEffect(StatusEffectType, Amount);
                break;
        }

        yield return new WaitForSeconds(1); 
    }
}
