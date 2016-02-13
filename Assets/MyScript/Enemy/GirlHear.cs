﻿using UnityEngine;
using System.Collections;

public class GirlHear : MonoBehaviour {
	public GameObject _EnemyPoint;
	public GameObject _Enemy;

	void OnTriggerStay (Collider other)
	{		
		if(_EnemyPoint==null){
			_EnemyPoint = GameObject.Find ("EnemyPoint");
		}
		if (_Enemy == null) {
			_Enemy = GameObject.Find ("Enemy");
		}
		// If the player has entered the trigger sphere...
		if (other.gameObject.tag =="Player") {			
			//Hearing
			if(OVRPlayerController._isSneaking==false && 
			   other.gameObject.GetComponent<OVRPlayerController>()._isWalking==true &&
			   _Enemy.GetComponent<EnemySight>().playerInSight==false){
				//ALERTTTT
				var lookPos = other.transform.position - transform.parent.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, rotation, Time.deltaTime * 10f);

				if(_Enemy.GetComponent<EnemyWalkpath>()._SearchingState==true){
					_Enemy.GetComponent<EnemyWalkpath>().enemyFoundPlayer();
				}

				_EnemyPoint.transform.position=new Vector3(other.transform.position.x,1.2f,other.transform.position.z);
				
				if(_Enemy.GetComponent<EnemyWalkpath>()._ALERT!=true){
					_Enemy.GetComponent<EnemyWalkpath>().AlertState();
				}
				
			}
		}
	}//OnTriggerStay
}