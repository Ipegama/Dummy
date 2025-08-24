using System.Collections;
using UnityEngine;


[CreateAssetMenu(menuName = "New/Effects/Gain Exp")]
public class GainExpEffect : Effect
{
    public int amount;
    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);
        PlayerLevelSystem.Instance.AddExp(amount);
        yield return new WaitForSeconds(0.25f);
    }
}
