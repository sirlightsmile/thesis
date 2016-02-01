using UnityEngine;
using System.Collections;

public class ClueActive : MonoBehaviour {
	public GameObject _enemy;
	// Use this for initialization


	public void EventStart () {
		_enemy.SetActive (true);
	}
	/*
	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player") {
			PlayerRaycast._clueHit=true;
		}

	}
	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			PlayerRaycast._clueHit=false;
		}
	}*/
}
