using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
	public GameObject _player;
	public bool _firstTime=true;
	void Update () {
		transform.LookAt (_player.transform);
	}
	void OnTriggerEnter(Collider _col){
		if (_col.tag == "Player" && _firstTime==true) {
			gameObject.GetComponent<AudioSource>().Play();
			_firstTime=false;
		}
	}//trigger
}
