using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//That damage formula is calculating damage arithmetically ( very simply)
//Attackers Damage + damage of weapon if it is carrying simply creates the damage.
[CreateAssetMenu(menuName="ScriptableObjects/DamageFormulas/ArithmeticDamageFormula",fileName="ArithmeticDamageFormula")]
public class ArithmeticDamageFormula : IDamageFormula
{
    public override float calculateDamage(Stats attackerStats, Weapon weapon = null)
    {
        float damage = (weapon==null)?attackerStats.damage:(attackerStats.damage+weapon.getDamage());
        return damage;
    }
}
