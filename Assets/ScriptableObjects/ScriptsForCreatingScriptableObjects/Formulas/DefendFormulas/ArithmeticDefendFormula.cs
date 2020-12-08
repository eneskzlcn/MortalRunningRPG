using UnityEngine;

//This formula calculates the damage after defend of an attack.
//Simply takes the defenders stats as an argument , and the damage damager send by.
//Then reduces the damage damager send amount of defenders armors and returns this value

[CreateAssetMenu(fileName="ArithmeticDefendFormula",
menuName="ScriptableObjects/DefendFormulas/ArithmeticDefendFormula")]
public class ArithmeticDefendFormula : IDefendFormula
{
    public override float calculateReducedDamage(Stats defenderStats, float damage)
    {
        // if damage --> be negative then it will heal the enemy.Should not let this happen. minimum-->0
        float reducedDamage = (defenderStats.armor < damage)?(damage-defenderStats.armor):0;
        return reducedDamage;
    }
}
