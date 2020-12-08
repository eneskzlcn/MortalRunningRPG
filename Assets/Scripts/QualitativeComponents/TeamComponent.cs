using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This is a another kind of qualitative component. 
    This script provides that the game characters has their own teams.
    An example a character wears PLAYER team and zombie AI's wearing ZOMBIE team.
    This script offers that PLAYER team fights with ZOMBIE team. And every member of team PLAYER,and every member
    of ZOMBIE team will be enemy. If there is an UNDANGEROUS Team member -->  do not do anything...
*/
[System.Serializable]
public enum Team
{
    PLAYER,ZOMBIE,UNDANGEROUS
}
public class TeamComponent : MonoBehaviour
{
    [SerializeField] private Team team;
    
    public Team getTeam()
    {
        return team;
    }
}
