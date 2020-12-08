using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public enum BoostType
{
    HEAL,ARMOR,DAMAGE,ELSE // kind of boosts
}

[System.Serializable]
public struct Boost
{
    public BoostType type;
    public float amount;
    public float duration; // use negative numbers as time independent 
                            //boosts like heal. Heal never goes after .. seconds.
}
[CreateAssetMenu(fileName = "Boost Item",menuName="ScriptableObjects/ConsumableItems/Boost Item")]
public class BoostItem : ConsumableItem
{
    [SerializeField] private Boost boost;   
    private System.Action<string> onConsume;
    private StatsComponent consumersStatsComponent;//may be there is a way better then this referencing :(( ??
    
    public void addOnConsumeListener(System.Action<string> action)
    {
        onConsume+= action;
    }
    public override void consume()
    {
        if(consumersStatsComponent == null) return;

        if(boost.type == BoostType.HEAL)
        {
            consumersStatsComponent.increaseHealth(boost.amount);
            
        }
        //The other boosts has not been added yet! But game is flex enough to add this later.
        else if(boost.type == BoostType.ARMOR)
        {
            //consumerStatsComponent.increaseArmor(boost.amount);
            
        }
        else if(boost.type == BoostType.DAMAGE)
        {
            //consumerStatsComponent.increaseDamage(boost.amount);
        }

        onConsume?.Invoke(getName());
    }
    public StatsComponent getConsumerStats()
    {
        return this.consumersStatsComponent;
    } 
    public override string getName()
    {
        return this.name;
    } 
    public void setConsumerStatsComponent(StatsComponent statsComponent)
    {
        this.consumersStatsComponent = statsComponent;
    } 
   
}
