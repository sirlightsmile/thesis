using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject _currentDoorEnemyActive;
	void OnTriggerEnter (Collider other){
		if (other.tag == "DoorObject") {
			//open door automatic
			if(other.gameObject.GetComponent<Door>()._isOpen==false){
				other.gameObject.GetComponent<Door>().DoorInteractive("Enemy");

				_currentDoorEnemyActive=other.gameObject;

			}
			//fix bug run toward and make door away
			if(other.gameObject.GetComponent<Door>()._isOpen==true
			   && gameObject.GetComponentInParent<EnemySight> ().playerInSight == true){
				other.gameObject.GetComponent<BoxCollider>().isTrigger=true;
			}
		}//with door

		if (other.tag == "Player") {
			if(gameObject.GetComponentInParent<EnemySight> ().playerInSight == false){

				gameObject.GetComponentInParent<EnemySight>().playerInSight=true;
				transform.parent.gameObject.transform.LookAt(other.transform);
				//animate
				Animator _EnemyAnimator;
				_EnemyAnimator = gameObject.GetComponentInParent<Animator> ();
				if (_EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("attack")!=true){
					_EnemyAnimator.SetBool ("Attack", true);
				}
			}

			Debug.Log ("Player Dead");
			gameObject.GetComponentInParent<NavMeshAgent>().Stop();
			other.GetComponent<OVRPlayerController>().enabled=false;
			StartCoroutine(PlayerDead());
		}
	}//TriggerEnter

	void OnTriggerExit (Collider _col){
		if (_col.name == "DoorZone" && _currentDoorEnemyActive!=null ){

			if(_currentDoorEnemyActive.GetComponent<Door>()._isAutomaticClose==true
		    && _currentDoorEnemyActive.GetComponent<Door>()._isOpen==true
		    && _col.transform.parent.name == _currentDoorEnemyActive.transform.parent.name){

			_currentDoorEnemyActive.gameObject.GetComponent<Door>().DoorInteractive("Enemy");
			_currentDoorEnemyActive=null;

			}
		}
		/*
		if(_col.tag=="DoorObject" && _col.gameObject.GetComponent<Door>()._isOpen==true && _col.gameObject.GetComponent<BoxCollider>().isTrigger==false
		   && gameObject.GetComponentInParent<EnemySight> ().playerInSight == true){
			_col.gameObject.GetComponent<BoxCollider>().isTrigger=false;
		}*/
	}//TriggerExit

	IEnumerator PlayerDead(){
		yield return new WaitForSeconds (1f);
		Menu._GameOver = true;
	}
}
