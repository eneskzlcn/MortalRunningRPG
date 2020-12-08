using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Belongs, attached to the ATTACK button to attack.
public class CharacterAttackControlByButton : MonoBehaviour
{
    [SerializeField] private CharacterAttackComponent attackComponent;
    
    public void Attack()
    {
        attackComponent.Attack();
    }
}
