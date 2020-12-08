using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IDamageFormula : ScriptableObject
{
    public abstract float calculateDamage(Stats attackerStats,Weapon weapon=null);
}
