using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Weapon is the item the character uses to improve attacking
public abstract class Weapon : EquipableItem
{
    [SerializeField] protected float damage;
    public abstract float getDamage();
}