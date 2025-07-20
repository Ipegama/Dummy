using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract IEnumerator Use(Combatant owner, Combatant rival);
}
