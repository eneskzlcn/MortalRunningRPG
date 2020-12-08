using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This scripts provides character movement and rotation by the Joystick movement
*/
public class CharacterPhysicalControlByJoystick : MonoBehaviour
{
    private MovementComponent characterMovementComponent;
    [SerializeField] private JoystickControlComponent joystickControlComponent;
    private RotationComponent characterRotationComponent;
    void Awake()
    {
        characterMovementComponent = GetComponent<MovementComponent>();
        characterRotationComponent = GetComponent<RotationComponent>();
    }
    void Update()
    {   
        ConfigureCharacterMovement();
        if(joystickControlComponent.IsJoystickOnPress())
        {
            ConfigureCharacterRotation();
        }
    }
    private void ConfigureCharacterMovement()
    {  
         //character will move in direction which joystick move
        characterMovementComponent.setDirectionOfMovement(
            joystickControlComponent.getJoystickMovementDirectionVector());

        //character movement thrust depends on how joystick far from center
        characterMovementComponent.setThrust(
            characterMovementComponent.getMovementSensivity()
                *joystickControlComponent.getHowJoystickFarFromCenter());
    }
    private void ConfigureCharacterRotation()
    {
        //Character should looks to its going way...
        characterRotationComponent.setRotationDirection(
            joystickControlComponent.getJoystickMovementDirectionVector());
    }
}
