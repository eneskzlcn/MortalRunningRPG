using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*This is a qualitative component. Many thing like speed,attackspeed,criticalrate,magic resistance etc. they
  they are all kind of qualitative properties and it is possible to keep them in here.
  Simply it keeps each stats for game character it does not matter it is ai or character 
  --> keeps the stats below and control them.
*/
[System.Serializable]
public struct Stats
{
    public float armor;
    public float damage;
    public float health;
}
public class StatsComponent : MonoBehaviour
{
    [SerializeField] private Stats stats;
    private System.Action<float> onHealthDecrease;
    private System.Action<float> onHealthIncrease;
    public Stats getStats()
    {
        return stats;
    }
    public float getDamage()
    {
        return stats.damage;
    }
    public float getArmor()
    {
        return stats.armor;
    }
    public float getHealth()
    {
        return stats.health;
    }
    public void decreaseHealth(float decreaseAmount)
    {
        stats.health-= decreaseAmount;
        onHealthDecrease.Invoke(stats.health);
    }
    public void increaseHealth(float increaseAmount)
    {
        stats.health += increaseAmount;
        onHealthIncrease.Invoke(stats.health);
    }
    public void addOnHealthDecreaseListener(System.Action<float> action)
    {
        onHealthDecrease+=action;
    }
    public void addOnHealthIncreaseListener(System.Action<float> action)
    {
        onHealthIncrease+=action;
    }
}
