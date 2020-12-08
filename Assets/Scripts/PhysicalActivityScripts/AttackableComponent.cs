using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TeamComponent))]
//if a game object carries this component it means it is able to attack. If not have, can not be attacked.
public class AttackableComponent : MonoBehaviour
{
    private StatsComponent defendersStats;
    [SerializeField] private IDefendFormula arithmeticDefendFormula;
    private Rigidbody2D defenderRigidbody;//used to push the target after damaged.(DO IT TO EFFECTİVE GAMEPLAY)
    [SerializeField] private float pushBackForce = 0.3f;//amount of pushback force
    [SerializeField] private Transform spriteTransform; //only sprite is rotating so its transform neeeded...
    [SerializeField] private HealthBarComponent healthBar;
    [SerializeField] private GameObject bloodSplash;
    [SerializeField] private Transform bloodSpawnTransform;
    [SerializeField] private Animator defendersAnimator;
    private void Awake()
    {
        defendersStats = GetComponent<StatsComponent>();
        defenderRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    public void defend(float unreducedDamage)
    {
        //call formula to calc. damage and decrease defenders health amount of reduced damage(reduced by armor)
        float damageReducedByDefenderStats =
            arithmeticDefendFormula.calculateReducedDamage(defendersStats.getStats(),unreducedDamage);
        defendersStats.decreaseHealth(damageReducedByDefenderStats);
        //blood particles 
        Instantiate(bloodSplash,bloodSpawnTransform.position,Quaternion.identity);
        //this force got put to give an effective playing --> like when you take damage you dragging to the back
        defenderRigidbody.AddForce(-spriteTransform.right * pushBackForce);
    }   
}
