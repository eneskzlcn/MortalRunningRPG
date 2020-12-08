using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Movement of a character. It
[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float thrust;
    private Vector3 directionOfMovement;
    [SerializeField] private float movementSensivity;
    private void Awake()
    {
        directionOfMovement = Vector3.zero;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        rigidbody2D.AddForce(thrust*directionOfMovement);
    }
    public void setDirectionOfMovement(Vector3 direction)
    {
        directionOfMovement = direction;
    }
    public void setThrust(float thrust)
    {
        this.thrust = thrust;
    }
    public float getThrust()
    {
        return thrust;
    }
    public float getMovementSensivity()
    {
        return this.movementSensivity;
    }
}
