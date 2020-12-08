using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This script controls the AI's auto attacking animation. Controls is there a character in the attack range.
    If there is an attackable target and the time is suitable(Not in duration) then AI agent attacks.

*/
[System.Serializable]
public enum AttackType
{
        MELEE,RANGE
}
[RequireComponent(typeof(Collider2D))]
public class AgentsAutoAttackComponent : MonoBehaviour
{
    [SerializeField] private AgentsAnimationController attackersAnimationController;//to run attack anim.
    [SerializeField] private StatsComponent attackersStatsComponent;//calc. damage of the attack
    [SerializeField] private AttackType attackersAttackType;  //
    [SerializeField] private TeamComponent attackersTeamComponent;
    [SerializeField] private IDamageFormula damageFormula;//to calc. the damage by a formula
    [SerializeField] private GameObject bulletPrefab;//for blood particular effect
    
    private float lastAttackTime; // time of the last attack;
    private float timeBetweenTwoAttack = 2.0f;
    private void Awake()
    {
        lastAttackTime = Time.time;
    }
    private void OnTriggerStay2D(Collider2D collidedObject)
    {
        if(Time.time - lastAttackTime >= timeBetweenTwoAttack)//is the time is ok to attack ?
        {
            if(collidedObject.GetComponent<TeamComponent>() == null || //if not has team disgard it
                collidedObject.GetComponent<AttackableComponent>() == null)return;//if not attackable disgard it
            TeamComponent collidedTeamComponent = collidedObject.GetComponent<TeamComponent>();
            AttackableComponent collidedAtackableComponent = collidedObject.GetComponent<AttackableComponent>();
            if((attackersTeamComponent.getTeam() == collidedTeamComponent.getTeam())//not enemy if in the same team
                || collidedTeamComponent.getTeam() == Team.UNDANGEROUS)return;//not enemy if undangerous
            lastAttackTime = Time.time; //attack time = now;
            //then attack...
            if(attackersAttackType == AttackType.MELEE)
            {
                MeleeAttack(collidedAtackableComponent);
                attackersAnimationController.runMeleeAttackAnimation();
            }
            else // has not been added a range attack func. yet. But the code designed flex enough to  add later
            {
                RangeAttack(collidedAtackableComponent);
                //run range attack animation
            }
        }
    }
    //calc. damage with a formula and --> send it as an atack damge to defender to defend it.
    private void MeleeAttack(AttackableComponent attackableComponent)
    {
        float damage = damageFormula.calculateDamage(attackersStatsComponent.getStats());
        attackableComponent.defend(damage);
    }
    // has not  added.
    private void RangeAttack(AttackableComponent attackableComponent)
    {
        float damage = damageFormula.calculateDamage(attackersStatsComponent.getStats());
        //GameObject bullet = Instantiate(bulletPrefab,firepoint.position,firepoint.rotation)
        //Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        //send the required values(like damage) to a component kind of--> <BulletMovementAndCollision>
        // range of bullet will be more than the distance between defenders.position and firepoint.position 
        // the bullet will only go the direction of the (firepoint-defenders)position.normalized
        // the bullet wont be too fast to escape from...
        // bulletRigidbody.AddForce()
    }
    public void setTimeBetweenTwoAttack(float time)
    {
        timeBetweenTwoAttack = time;
    }
}
