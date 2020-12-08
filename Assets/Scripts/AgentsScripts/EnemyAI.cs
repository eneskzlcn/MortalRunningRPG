using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(RotationComponent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 200.0f;
    [SerializeField] private float nextWaypointDistance = 3.0f;
    [SerializeField] private float zombieAttackRange;//the range that zombie starts attacking melee
    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath = false;
    private Rigidbody2D enemyRB;//the rb that an enemy ai has(== this gameobjects rb)
    private Seeker seeker;
    private RotationComponent enemyRotationComponent;
    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyRotationComponent = GetComponent<RotationComponent>();
    }
    private void Start()
    {
        InvokeRepeating("UpdatePath",0f,0.5f);
        if(!seeker.IsDone())
        {
            //setting up the rotation to configure which direction a zombie looks at
            Vector2 rotationDirection = ((Vector2)path.vectorPath[currentWaypoint]-enemyRB.position).normalized;
            enemyRotationComponent.setRotationDirection(rotationDirection);
        }
    }
    private void UpdatePath()
    {
        if(target == null) return;
        if(seeker.IsDone())
            seeker.StartPath(enemyRB.position,target.position,OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void FixedUpdate()
    {
       if(path == null)return;
       //if(target == null) return;
       if(currentWaypoint >= path.vectorPath.Count) //is path completed control
       {
           reachedEndOfPath = true;
           return;
       }
       else
       {
           reachedEndOfPath = false;
       }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]-enemyRB.position).normalized;
        Vector2 force = direction * speed *Time.deltaTime;
        float distance = Vector2.Distance(enemyRB.position,path.vectorPath[currentWaypoint]);
        
            Debug.Log("YEAHAEBOI");
            //rotate it to the direction it moves..--> then addForce to make it move.
            enemyRotationComponent.setRotationDirection((target.position-transform.position).normalized);
            enemyRB.AddForce(force);
        
        if(distance <= nextWaypointDistance)
        {
            currentWaypoint++; 
        }
    }
    public void setTarget(Transform transform)
    {
        target = transform;
    }
}
