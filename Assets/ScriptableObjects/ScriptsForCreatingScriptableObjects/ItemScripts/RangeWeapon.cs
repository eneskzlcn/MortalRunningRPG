using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This item has a kind of bullet to fire on and attack from far over the enemy.
[CreateAssetMenu(fileName="RangeWeapon",menuName="ScriptableObjects/Weapons/RangeWeapon")]
public class RangeWeapon : Weapon
{
    [SerializeField] private Texture2D bulletTexture;
    
    public override float getDamage()
    {
        return this.damage;
    }
    public Texture2D getBulletTexture()
    {
        return this.bulletTexture;
    }
}
