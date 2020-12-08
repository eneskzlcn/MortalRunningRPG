using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This component is attached to the health bar uı object that each game character has.
//It controls the health bar filling,emptying.
public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private StatsComponent statsComponent;

    private void Awake()
    {
        setMaxHealth(100);
        statsComponent.addOnHealthDecreaseListener(setHealth);
        statsComponent.addOnHealthIncreaseListener(setHealth);
    }
    public void setHealth(float health)
    {
        slider.value = health;
    }
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
