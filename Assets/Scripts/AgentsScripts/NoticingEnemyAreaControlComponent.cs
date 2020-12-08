using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using go as gameobject in that paragraph
//These script starts the following operation of an AI (which is the scripts belongs,attached to)
//Decides if there is en enemy in the area --> then follow  or exited from the area --> then stop following.
//In this following control, it sets the target transform which is the EnemyAI scripts using to follow it.
//Until there is a trigger enter in this script, the enemyAI scripts target transform is null. 
//So, the AI go this script and EnemyAI script attached to doesnt moves until this script notice an enemy to follow.

public class NoticingEnemyAreaControlComponent : MonoBehaviour
{
   //[SerializeField] private EnemyAI enemyAI;//defined to set the target of this enemy ai

   //private void OnTriggerEnter2D(Collider2D hit)
   //{
   //    if(hit.gameObject.GetComponent<TeamComponent>()== null) return;
   //    if(hit.gameObject.GetComponent<TeamComponent>().getTeam() != Team.PLAYER) return;
   //    enemyAI.setTarget(hit.gameObject.transform);

   //}
   //private void OnTriggerExit2D(Collider2D hit)
   //{
   //    enemyAI.setTarget(gameObject.transform);
   //}
}
