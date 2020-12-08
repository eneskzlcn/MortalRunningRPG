using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attaching to bullets at the time it get fired from gun

public class BulletMovementAndCollisionController : MonoBehaviour
{  
    private float range;
    private Vector3 startPositionVector;
    private float damage;
    private TeamComponent shootersTeam;
    void Awake()
    {
        startPositionVector = transform.position;
    }
    void Update()
    {
        if((transform.position - startPositionVector).magnitude > range)
        {
            Destroy(gameObject);
        }
    }
    //if the hit item is in enemy team and it is attackable then attack it ...
    private void OnTriggerEnter2D(Collider2D hitCollider)
    {
        AttackableComponent attackableComponent = hitCollider.GetComponent<AttackableComponent>();
        TeamComponent teamComponent = hitCollider.GetComponent<TeamComponent>();
        if(attackableComponent == null || teamComponent == null)return;
        if((teamComponent.getTeam() == Team.UNDANGEROUS) ||
        (teamComponent.getTeam() == shootersTeam.getTeam())) return;
        attackableComponent.defend(damage);
        Destroy(gameObject);
    }
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public void setShooterTeam(TeamComponent teamComponent)
    {
        this.shootersTeam = teamComponent;
    }
    public void setBulletRange(float range)
    {
        this.range = range;
    }
}
