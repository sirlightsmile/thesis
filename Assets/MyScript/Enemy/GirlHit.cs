using UnityEngine;
using System.Collections;

public class GirlHit : MonoBehaviour {
	public GameObject _currentDoorEnemyActive;

	void OnTriggerEnter (Collider other){
		if (other.tag == "DoorObject") {
			//open door automatic
			if(other.gameObject.GetComponent<Door>()._isOpen==false){
				other.gameObject.GetComponent<Door>().DoorInteractive("Enemy");
				_currentDoorEnemyActive=other.gameObject;
			}
		}

		if (other.tag == "Player") {
				transform.parent.gameObject.transform.LookAt(other.transform);
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
	}//TriggerExit
}
