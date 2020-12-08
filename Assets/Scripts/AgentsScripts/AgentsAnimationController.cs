using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using go as gameobject;
//The script is using the control which animation AI(go which this script is attached to) is going to realize. 
public class AgentsAnimationController : MonoBehaviour
{   
    [SerializeField] private Animator agentAnimator;
    [SerializeField] private StatsComponent agentStatsComponent;
    [SerializeField] private Rigidbody2D agentRB;
    void Awake()
    {
        agentStatsComponent.addOnHealthDecreaseListener((float health)=>{
            if(health<=0)
            {
                runDeathAnimation();
            }
        });

    }
    void LateUpdate()
    {
        runRunningAnimation();
    }
    public void runDeathAnimation()
    {
        agentAnimator.SetTrigger("Death");
    }
    private void runRunningAnimation()
    {
        agentAnimator.SetFloat("Speed",agentRB.velocity.magnitude);//(x) => if x > speed --> run;
    }
    public void runMeleeAttackAnimation()
    {
        agentAnimator.SetTrigger("AttackMelee");
    }   
}
