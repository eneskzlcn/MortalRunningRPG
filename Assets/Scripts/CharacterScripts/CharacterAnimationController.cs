using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator characterSpriteAnimator;
    [SerializeField] private Rigidbody2D characterRigidbody;
    [SerializeField] private StatsComponent characterStats;
    [SerializeField] private GameObject deathText;//just writing K.O. on the character.
    
    void LateUpdate()
    {
        runRunningAnimation();
    }
    // simply writed (if the game keep going improving detailly,this code will change)
    public void runDeathAnimation()
    {           
        Debug.Log("Game Over!");
        gameObject.SetActive(false);
        deathText.SetActive(true);
    }

    private void runRunningAnimation()
    {
        float speed = characterRigidbody.velocity.magnitude;
         characterSpriteAnimator.SetFloat("Speed",speed);//(x)--> if speed>x --> run
        
    }
    //Not works visually perfect.Just a simple to control funtionality
    public void runRangeAttackAnimation()
    {
        characterSpriteAnimator.SetTrigger("RangeAttack");
    }
    
    public void runPunchAnimation()
    {
        characterSpriteAnimator.SetTrigger("Punch");
    }
    public void runMeleeAttackAnimation()
    {
        characterSpriteAnimator.SetTrigger("MeleeAttack");
    }
}
