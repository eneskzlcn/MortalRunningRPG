using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This component allows a character to rotate in a direction
public class RotationComponent : MonoBehaviour
{
    private Vector3 rotationDirection;
    [SerializeField] private Transform transformToRotate;
        
    void LateUpdate()
    {
        Rotate();
    }
    public void setRotationDirection(Vector3 direction)
    {
        rotationDirection = direction;
    }
    private void Rotate()
    {
        float rotationAngle = Mathf.Atan2(rotationDirection.y,rotationDirection.x)*Mathf.Rad2Deg;
         transformToRotate.eulerAngles = 
            new Vector3(transformToRotate.rotation.x,
                transformToRotate.rotation.y,transformToRotate.rotation.z+rotationAngle);
    }
}
