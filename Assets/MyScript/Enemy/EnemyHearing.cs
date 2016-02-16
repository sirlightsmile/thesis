using UnityEngine;
using System.Collections;

public class EnemyHearing : MonoBehaviour {
	private GameObject _EnemyPoint;

	void OnTriggerStay (Collider other)
	{		
		// If the player has entered the trigger sphere...
		if (other.gameObject.tag =="Player") {			
			//Hearing normal
			if(other.GetComponent<OVRPlayerController>()._FastWalk==true && 
			   gameObject.GetComponentInParent<EnemySight>().playerInSight==false){
				//ALERTTTT
				if(gameObject.GetComponentInParent<EnemyWalkpath>()._SearchingState==true){
					gameObject.GetComponentInParent<EnemyWalkpath>().enemyFoundPlayer();
				}
				if(_EnemyPoint==null){
					_EnemyPoint = GameObject.Find ("EnemyPoint");
				}
				_EnemyPoint.transform.position=new Vector3(other.transform.position.x,1.2f,other.transform.position.z);
				
				if(gameObject.GetComponentInParent<EnemyWalkpath>()._ALERT!=true){
					gameObject.GetComponentInParent<EnemyWalkpath>().AlertState();
				}
				
			}
			//Hearing on Alert //Maybe not
			//if wanna put in , add condition of Alert == false in upper if.
			/*
			else if(OVRPlayerController._isSneaking==false
			        && other.GetComponent<OVRPlayerController>()._isWalking==true &&
			         gameObject.GetComponentInParent<EnemySight>().playerInSight==false
			         && gameObject.GetComponentInParent<EnemyWalkpath>()._ALERT==true){
				//ALERTTTT
				if(gameObject.GetComponentInParent<EnemyWalkpath>()._SearchingState==true){
					gameObject.GetComponentInParent<EnemyWalkpath>().enemyFoundPlayer();
				}
				if(_EnemyPoint==null){
					_EnemyPoint = GameObject.Find ("EnemyPoint");
				}
				_EnemyPoint.transform.position=new Vector3(other.transform.position.x,1.2f,other.transform.position.z);
				
				if(gameObject.GetComponentInParent<EnemyWalkpath>()._ALERT!=true){
					gameObject.GetComponentInParent<EnemyWalkpath>().AlertState();
				}
			}
			*/


		}
	}//OnTriggerStay
}
