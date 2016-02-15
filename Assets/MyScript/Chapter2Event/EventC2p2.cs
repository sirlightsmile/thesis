using UnityEngine;
using System.Collections;

public class EventC2p2 : MonoBehaviour {
	public GameObject _soundSource;
	public GameObject _Door;
	public GameObject _DoorUnlock;
	public GameObject _AIracheal;

	void OnTriggerEnter(){
		if (_Door.GetComponent<Door> ()._isOpen == true) {
			_Door.GetComponent<Door>().DoorInteractive("Player");
		}
		StartCoroutine (C2p2Active ());
		gameObject.GetComponent<BoxCollider> ().enabled = false;
	}
	
	IEnumerator C2p2Active(){
		yield return new WaitForSeconds(3f);
		_soundSource.SetActive (true);
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = true;
		yield return new WaitForSeconds(1f);
		FaceToEvent._turning = false;
		yield return new WaitForSeconds(6.2f);
		_DoorUnlock.GetComponent<Door> ()._Locked = false;
		Destroy (_soundSource);
		yield return new WaitForSeconds (1.5f);
		_AIracheal.SetActive (true);
		_DoorUnlock.GetComponent<Door> ().DoorInteractive ("Player");
		_Door.GetComponent<Door>().DoorInteractive("Player");
		Destroy (this.gameObject);
	}//C2p1
}
