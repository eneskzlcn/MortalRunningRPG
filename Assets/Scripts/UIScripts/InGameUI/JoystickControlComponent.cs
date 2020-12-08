using UnityEngine;
using UnityEngine.UI;

/*  This script control the joystick which is UI element.
    This script only controls the joystick objects movement with button dragging actions.
    Control the button to keep it in the joystick area and move it according to the mouse.
*/
public class JoystickControlComponent : MonoBehaviour
{
    [SerializeField] private Button joystickButton;
    [SerializeField] private float radiusOfJoystickMovementArea;
    private Vector3 centerPositionOfJoystick;
    private bool isJoystickOnPress = false;
    private float howJoystickFarFromCenter;
    private Vector3 joystickMovementDirectionVector;
    private void Update()
    {
        if(isJoystickOnPress)
        {
            JoystickButtonMovement();
        }
    }
    private void Awake()
    {
        centerPositionOfJoystick = joystickButton.transform.position;
    }
    private void JoystickButtonMovement()
    {
        //mouse position- joystick position gives the difference vector from joystick to mouse
        Vector3 joystickPosAndMousePosDifferenceVector = Input.mousePosition - joystickButton.transform.position;
        float magnitudeOfTheDifferenceVector = joystickPosAndMousePosDifferenceVector.magnitude;
         //should not move if mouse at center
        if(magnitudeOfTheDifferenceVector == 0)return;
        //Normally follow the mouse if it is not out of the joystick area
        if((Input.mousePosition-centerPositionOfJoystick).magnitude <= radiusOfJoystickMovementArea)
        {
            joystickButton.transform.position = Input.mousePosition;
            howJoystickFarFromCenter = (Input.mousePosition-centerPositionOfJoystick).magnitude;
        }
        //if mouse in the outside
        else
        {
            //Now joystick on its max far point (magnitude = radius) --So-->
            howJoystickFarFromCenter = radiusOfJoystickMovementArea;
            Vector3 joystickMovement = 
                (Input.mousePosition-centerPositionOfJoystick).normalized *radiusOfJoystickMovementArea;
                    joystickButton.transform.position = new Vector3(centerPositionOfJoystick.x+joystickMovement.x,
                        centerPositionOfJoystick.y+joystickMovement.y,joystickButton.transform.position.z);
        }
        //the direction movement which joystick just moved
        joystickMovementDirectionVector = (joystickButton.transform.position-centerPositionOfJoystick).normalized;
    }

    public void OnJoystickPressed()
    {
        isJoystickOnPress = true;
    }

    public void OnJoystickExit()
    {
        isJoystickOnPress = false;
        joystickButton.transform.position = centerPositionOfJoystick;
        joystickMovementDirectionVector = Vector3.zero;
    }
    public float getHowJoystickFarFromCenter()
    {
        return howJoystickFarFromCenter;
    }
    public Vector3 getJoystickMovementDirectionVector()
    {
        return joystickMovementDirectionVector;
    }
    public bool IsJoystickOnPress()
    {
        return isJoystickOnPress;
    }
}
