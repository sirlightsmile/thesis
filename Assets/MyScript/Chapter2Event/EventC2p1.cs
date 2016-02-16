using UnityEngine;
using System.Collections;

public class EventC2p1 : MonoBehaviour {
	public GameObject _soundSource;
	public GameObject _Door;

	void OnTriggerExit(Collider _col){
		if (_col.tag == "Player") {
			StartCoroutine (C2p1Active ());
			gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
	}
	
	IEnumerator C2p1Active(){
		_soundSource.SetActive (true);
		yield return new WaitForSeconds(4f);
		if (_Door.GetComponent<Door> ()._isOpen == false) {
			_Door.GetComponent<Door>().DoorInteractive("Player");
		}
		Destroy (this.gameObject);
	}//C2p1
}
