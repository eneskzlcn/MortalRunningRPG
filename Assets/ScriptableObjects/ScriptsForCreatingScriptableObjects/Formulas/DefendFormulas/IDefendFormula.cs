using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDefendFormula : ScriptableObject
{
    public abstract float calculateReducedDamage(Stats defenderStats,float damage);
}
