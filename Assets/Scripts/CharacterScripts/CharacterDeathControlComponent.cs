using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Not a good way do control death. Just used basically finish the game for now...
*/
[RequireComponent(typeof(StatsComponent))]
public class CharacterDeathControlComponent : MonoBehaviour
{
    private StatsComponent characterStats;
    [SerializeField] private GameObject deathText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject characterHealthBar;
    [SerializeField] private GameObject characterSprite;
    void Awake()
    {
        characterStats = GetComponent<StatsComponent>();
    }
    void Start()
    {
        characterStats.addOnHealthDecreaseListener(deathHandler);//to listen if health is less then 0
    }    
    void deathHandler(float currentHealth)//basically handling the death...
    {
        if(currentHealth<=0)
        {
           deathText.SetActive(true);
           gameOverScreen.SetActive(true);
           characterHealthBar.SetActive(false);
           characterSprite.SetActive(false);
        }
    }
}
