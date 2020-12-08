using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This item is a kind of weapon which is useful when the enemy is too close..
[CreateAssetMenu(fileName="MeleeWeapon",menuName="ScriptableObjects/Weapons/MeleeWeapon")]
public class MeleeWeapon : Weapon
{
    public override float getDamage()
    {
        return this.damage;
    }
}
