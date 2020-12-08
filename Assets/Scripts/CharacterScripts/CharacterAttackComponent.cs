using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This script is the attack funtionality of the character.
*/
public class CharacterAttackComponent : MonoBehaviour
{
    [SerializeField] private StatsComponent attackerStats;
    [SerializeField] private EquipmentsComponent attackerEquipments;
    [SerializeField] private Transform punchPoint;
    [SerializeField] private Transform weaponAttackPoint;
    [SerializeField] private TeamComponent attackerTeamComponent;
    [SerializeField] private float punchRange;
    [SerializeField] private float meleeAttackRange;
    [SerializeField] private float rangeAttackRange;
    [SerializeField] private IDamageFormula arithmeticDamageFormula;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private CharacterAnimationController characterAnimationController;


    //Attack
    public void Attack()
    {
        Weapon attackerWeapon = 
            (Weapon)(attackerEquipments.getEquipmentSlotBySlotType(SlotType.WEAPON).getEquipment());
        if(attackerWeapon == null)
        {
            Punch();
        }
        else if(attackerWeapon is RangeWeapon)
        {
            RangeAttack((RangeWeapon)attackerWeapon);
        }
        else if (attackerWeapon is MeleeWeapon)
        {
            MeleeAttack((MeleeWeapon)attackerWeapon);
        }
    }

    public void RangeAttack(RangeWeapon weapon)
    {
        //run range animation (not added visually perfect. Can be done a anim. like fire when range attack happens)
        characterAnimationController.runRangeAttackAnimation();
        //create a bullet 
        GameObject bullet = Instantiate(bulletPrefab,weaponAttackPoint.position,weaponAttackPoint.rotation);
        // take bullet controller component to configure it as damage,shooterTeam...
        BulletMovementAndCollisionController movColController = 
            bullet.GetComponent<BulletMovementAndCollisionController>();
        /*after fire the bullet, now the character or ai or sth. who has the attack gives its demage
          to bullet --> it means the damage calc as  weapon + attackers damage at the time bullet get fired
          by the damage formula. So when the bullet hit its enemy, it gives this calculated damage.

        */
        movColController.setDamage(
            arithmeticDamageFormula.calculateDamage(attackerStats.getStats(),weapon));
        //bullet carries a Team which is its owner(person fires this bullet) has.
        movColController.setShooterTeam(attackerTeamComponent);
        //bullet range is amount of its owners rangeattack range.
        movColController.setBulletRange(this.rangeAttackRange);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        //move the bullet
        bulletRigidbody.AddForce(weaponAttackPoint.right*40.0f,ForceMode2D.Impulse);
    }
    public void Punch()
    {
        characterAnimationController.runPunchAnimation();
        //control which objects in the area of punch range
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(punchPoint.position,punchRange);
        foreach (Collider2D hit in hitObjects)
        {
            TeamComponent defendersTeamComponent = hit.GetComponent<TeamComponent>();
            if(defendersTeamComponent== null)return;
            if(defendersTeamComponent.getTeam() == Team.UNDANGEROUS)return;
            if(attackerTeamComponent.getTeam() == defendersTeamComponent.getTeam())return;
            if(hit.GetComponent<AttackableComponent>() == null) return;
            (hit.GetComponent<AttackableComponent>()).defend(
                arithmeticDamageFormula.calculateDamage(attackerStats.getStats())
            );
        }
    }
    /* Very similar to RangeAttack. Just not firing a bullet. Character gives the damage by its own.
    */
    public void MeleeAttack(MeleeWeapon weapon)
    {
        characterAnimationController.runMeleeAttackAnimation();
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(weaponAttackPoint.position,meleeAttackRange);
        foreach (Collider2D hit in hitObjects)
        {
            TeamComponent defendersTeamComponent = hit.GetComponent<TeamComponent>();
            if(defendersTeamComponent== null)return;
            if(defendersTeamComponent.getTeam() == Team.UNDANGEROUS)return;
            if(attackerTeamComponent.getTeam() == defendersTeamComponent.getTeam())return;
            if(hit.GetComponent<AttackableComponent>() == null) return;
            Debug.Log("Damage given by melee weapon " + arithmeticDamageFormula.calculateDamage(attackerStats.getStats(),weapon));
            (hit.GetComponent<AttackableComponent>()).defend(
                arithmeticDamageFormula.calculateDamage(attackerStats.getStats(),weapon)
            );
        }
    }
    
}
